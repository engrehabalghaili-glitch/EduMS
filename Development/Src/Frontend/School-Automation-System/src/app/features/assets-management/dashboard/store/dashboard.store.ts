import { Injectable, inject, signal, computed } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { getChartColors } from '../../../../shared/utils/chart.utils';
import type { DashboardData, TopAssetItem } from '../models/dashboard.types';
import type { StatsCardConfig } from '../../../../shared/interfaces/shared.types';

@Injectable()
export class DashboardStore {
  private readonly service = inject(DashboardService);

  readonly data = signal<DashboardData | null>(null);
  readonly loading = signal(false);

  readonly kpiCards = computed<StatsCardConfig[]>(() => {
    const d = this.data();
    if (!d) return [];
    return [
      { value: d.totalAssets, label: 'إجمالي الأصول', icon: 'pi pi-box', color: 'info' },
      { value: d.brokenCount, label: 'أصول عاطلة', icon: 'pi pi-exclamation-triangle', color: 'danger' },
      { value: d.annualDepreciation, label: 'الإهلاك السنوي', icon: 'pi pi-chart-line', color: 'success' },
      { value: d.totalValue, label: 'القيمة الإجمالية', icon: 'pi pi-coin', color: 'primary' },
      { value: d.expiredCount, label: 'أصول منتهية', icon: 'pi pi-clock', color: 'warn' },
    ];
  });

  readonly categoryDistribution = computed(() => {
    const d = this.data();
    if (!d) return { labels: [] as string[], datasets: [] as any[] };
    const colors = getChartColors();
    return {
      labels: d.categoryDistribution.labels,
      datasets: [{
        data: d.categoryDistribution.data,
        backgroundColor: [colors.primary, colors.info, colors.warning, colors.success],
        borderWidth: 0,
      }],
    };
  });

  readonly categoryOptions = {
    cutout: '65%',
    plugins: { legend: { position: 'bottom', rtl: true, labels: { padding: 16, usePointStyle: true } } },
    maintainAspectRatio: false,
  };

  readonly topAssets = computed<TopAssetItem[]>(() => this.data()?.topAssets ?? []);

  readonly depreciationData = computed(() => {
    const d = this.data();
    if (!d) return { labels: [] as string[], datasets: [] as any[] };
    const colors = getChartColors();
    return {
      labels: d.depreciation.labels,
      datasets: [
        {
          label: 'القيمة الدفترية',
          backgroundColor: colors.primary,
          borderRadius: 4,
          data: d.depreciation.bookValues,
        },
        {
          label: 'الإهلاك المتراكم',
          backgroundColor: colors.warning,
          borderRadius: 4,
          data: d.depreciation.accumulatedDepreciation,
        },
      ],
    };
  });

  readonly depreciationOptions = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: { legend: { position: 'bottom', rtl: true, labels: { padding: 16, usePointStyle: true } } },
    scales: {
      x: { grid: { display: false } },
      y: { beginAtZero: true, grid: { color: getChartColors().surface } },
    },
  };

  readonly expiredAssets = computed(() => this.data()?.expiredAssets ?? []);
  readonly bureauReport = computed(() => this.data()?.bureauReport ?? null);

  async load(): Promise<void> {
    if (this.loading()) return;
    this.loading.set(true);
    try {
      const dashboard = await this.service.loadDashboard();
      this.data.set(dashboard);
    } finally {
      this.loading.set(false);
    }
  }
}
