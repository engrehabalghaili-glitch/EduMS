import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DatePipe, DecimalPipe } from '@angular/common';
import { StatsCardComponent } from '../../../../../shared/components/stats-card/stats-card.component';
import { AppCard } from '../../../../../shared/components/card/card.component';
import { AppChart } from '../../../../../shared/components/chart/chart.component';
import { AppDrawer } from '../../../../../shared/components/drawer/drawer.component';
import { AssetStatusBadge } from '../../../../../shared/components/asset-status-badge/asset-status-badge.component';
import { AssetInfoGrid } from '../../../../../shared/components/asset-info-grid/asset-info-grid.component';
import { AppDivider } from '../../../../../shared/components/divider/divider.component';
import { AppButton } from '../../../../../shared/components/button/button.component';
import { AppTag } from '../../../../../shared/components/tag/tag.component';
import { DashboardStore } from '../../store/dashboard.store';

interface NavCard {
  label: string;
  desc: string;
  icon: string;
  route: string;
  color: string;
}

@Component({
  selector: 'app-dashboard-overview',
  standalone: true,
  imports: [
    RouterLink, DatePipe, DecimalPipe,
    StatsCardComponent,
    AppCard, AppChart, AppDrawer,
    AssetStatusBadge, AssetInfoGrid,
    AppDivider, AppButton, AppTag,
  ],
  templateUrl: './dashboard-overview.html',
  styleUrl: './dashboard-overview.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardOverviewComponent implements OnInit {
  readonly store = inject(DashboardStore);

  readonly drawerVisible = signal(false);
  readonly selectedAsset = signal<any | null>(null);

  readonly navCards: NavCard[] = [
    { label: 'تسجيل أصل جديد', desc: 'إضافة أصل مع خطوات التوثيق', icon: 'pi pi-plus-circle', route: '/assets-management/registration', color: 'primary' },
    { label: 'طلبات الصيانة', desc: 'متابعة بلاغات الصيانة والأعطال', icon: 'pi pi-wrench', route: '/assets-management/maintenance', color: 'warn' },
    { label: 'المخزون الاستهلاكي', desc: 'إدارة المواد والحد الطلبات', icon: 'pi pi-warehouse', route: '/assets-management/procurement', color: 'info' },
    { label: 'تقارير الأصول', desc: 'التقارير الدورية وتحليل البيانات', icon: 'pi pi-chart-bar', route: '/assets-management/reports', color: 'success' },
  ];

  ngOnInit(): void {
    void this.store.load();
  }

  assetTypeIcon(cat: string): string {
    const map: Record<string, string> = { technology: 'pi pi-desktop', furniture: 'pi pi-table', vehicle: 'pi pi-car', building: 'pi pi-building' };
    return map[cat] || 'pi pi-box';
  }

  showAssetDetails(asset: any): void {
    this.selectedAsset.set(asset);
    this.drawerVisible.set(true);
  }

  compareWithBureau(): void {
    const report = this.store.bureauReport();
    if (!report) return;
    alert(`نتيجة المقارنة مع كشف مكتب التربية:\n- الأصول المسجلة محلياً: ${report.localCount}\n- الأصول في كشف المكتب: ${report.bureauCount}\n- أصول زائدة: ${report.extraAssets.length}\n- أصول ناقصة: ${report.missingAssets.length}`);
  }

  exportReport(): void {
    alert('تم تصدير تقرير الجرد السنوي بصيغة PDF');
  }
}
