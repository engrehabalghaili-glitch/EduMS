import { Injectable, inject, signal, computed } from '@angular/core';
import { AssetService } from '../services/assets.service';
import { getChartColors } from '../../../shared/utils/chart.utils';
import type { Asset, MaintenanceRequest, PreventiveMaintenance, InventoryItem, DepreciationInfo, AssetActivity, MaintenanceStatus } from '../models/assets.model';

@Injectable()
export class AssetStore {
  private readonly service = inject(AssetService);

  readonly assets = signal<Asset[]>([]);
  readonly maintenanceRequests = signal<MaintenanceRequest[]>([]);
  readonly preventiveMaintenance = signal<PreventiveMaintenance[]>([]);
  readonly inventory = signal<InventoryItem[]>([]);
  readonly depreciation = signal<DepreciationInfo[]>([]);
  readonly expiredAssets = signal<{ name: string; category: string; purchaseYear: number; replacementCost: number; reason: string }[]>([]);
  readonly bureauReport = signal<{ localCount: number; bureauCount: number; extraAssets: string[]; missingAssets: string[]; lastSyncDate: string; status: string }>({
    localCount: 0, bureauCount: 0, extraAssets: [], missingAssets: [], lastSyncDate: '', status: '',
  });
  readonly selectedAssetActivities = signal<AssetActivity[]>([]);

  readonly loading = signal(false);
  readonly selectedAsset = signal<Asset | null>(null);

  private readonly chartColors = getChartColors();

  readonly kpiCards = computed(() => [
    { value: this.assets().length, label: 'إجمالي الأصول', icon: 'pi pi-box', color: 'info' as const },
    { value: this.assets().filter(a => a.status === 'broken').length, label: 'أصول عاطلة', icon: 'pi pi-exclamation-triangle', color: 'danger' as const },
    { value: this.maintenanceRequests().filter(r => r.status === 'pending' || r.status === 'in-progress').length, label: 'طلبات صيانة مفتوحة', icon: 'pi pi-wrench', color: 'warn' as const },
    { value: this.inventory().filter(i => i.currentQuantity <= i.minThreshold).length, label: 'مخزون حرج', icon: 'pi pi-warehouse', color: 'gray' as const },
    { value: this.depreciation().reduce((s, d) => s + d.annualDepreciation, 0), label: 'الإهلاك السنوي', icon: 'pi pi-chart-line', color: 'success' as const },
  ]);

  readonly assetCategoryData = computed(() => ({
    labels: ['أجهزة تقنية', 'أثاث', 'مركبات', 'مباني'],
    datasets: [{
      data: [
        this.assets().filter(a => a.category === 'technology').length,
        this.assets().filter(a => a.category === 'furniture').length,
        this.assets().filter(a => a.category === 'vehicle').length,
        this.assets().filter(a => a.category === 'building').length,
      ],
      backgroundColor: [this.chartColors.primary, this.chartColors.info, this.chartColors.warning, this.chartColors.success],
      borderWidth: 0,
    }],
  }));

  readonly depreciationData = computed(() => ({
    labels: ['أجهزة تقنية', 'أثاث', 'مركبات', 'مباني'],
    datasets: [
      {
        label: 'القيمة الدفترية',
        backgroundColor: this.chartColors.primary,
        borderRadius: 4,
        data: this.depreciation().map(d => d.bookValue),
      },
      {
        label: 'الإهلاك المتراكم',
        backgroundColor: this.chartColors.warning,
        borderRadius: 4,
        data: this.depreciation().map(d => d.accumulatedDepreciation),
      },
    ],
  }));

  readonly topAssets = computed(() => [...this.assets()].sort((a, b) => b.purchaseCost - a.purchaseCost).slice(0, 5));

  get assetCategoryOptions() {
    return {
      cutout: '65%',
      plugins: { legend: { position: 'bottom', rtl: true, labels: { padding: 16, usePointStyle: true } } },
      maintainAspectRatio: false,
    };
  }

  get depreciationOptions() {
    return {
      responsive: true,
      maintainAspectRatio: false,
      plugins: { legend: { position: 'bottom', rtl: true, labels: { padding: 16, usePointStyle: true } } },
      scales: {
        x: { grid: { display: false } },
        y: { beginAtZero: true, grid: { color: getChartColors().surface } },
      },
    };
  }

  async loadAll(): Promise<void> {
    if (this.loading()) return;
    this.loading.set(true);
    try {
      const [assets, maintenance, preventive, inventory, depreciation, expired, report] = await Promise.all([
        this.service.getAssets(),
        this.service.getMaintenanceRequests(),
        this.service.getPreventiveMaintenance(),
        this.service.getInventory(),
        this.service.getDepreciation(),
        this.service.getExpiredAssets(),
        this.service.getBureauReport(),
      ]);
      this.assets.set(assets);
      this.maintenanceRequests.set(maintenance);
      this.preventiveMaintenance.set(preventive);
      this.inventory.set(inventory);
      this.depreciation.set(depreciation);
      this.expiredAssets.set(expired);
      this.bureauReport.set(report);
    } finally {
      this.loading.set(false);
    }
  }

  requestsByStatus(status: string): MaintenanceRequest[] {
    return this.maintenanceRequests().filter(r => r.status === status);
  }

  async updateMaintenanceStatus(id: string, status: MaintenanceStatus): Promise<void> {
    await this.service.updateMaintenanceStatus(id, status);
    this.maintenanceRequests.update(list =>
      list.map(r => r.id === id ? { ...r, status } : r)
    );
  }

  async createAsset(asset: Omit<Asset, 'id'>): Promise<void> {
    const created = await this.service.createAsset(asset);
    this.assets.update(list => [created, ...list]);
  }

  async selectAsset(asset: Asset): Promise<void> {
    this.selectedAsset.set(asset);
    const activities = await this.service.getAssetActivities(asset.id);
    this.selectedAssetActivities.set(activities);
  }
}
