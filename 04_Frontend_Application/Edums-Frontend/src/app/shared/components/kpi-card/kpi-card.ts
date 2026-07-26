import { ChangeDetectionStrategy, Component, computed, input, output } from '@angular/core';
import { NgClass } from '@angular/common';
import { CardModule } from 'primeng/card';
import { ProgressBarModule } from 'primeng/progressbar';
import { Skeleton } from 'primeng/skeleton';

export type KpiTrend = 'up' | 'down' | 'stable';
export type KpiSeverity = 'primary' | 'success' | 'info' | 'warning' | 'danger';
export type KpiFormat = 'number' | 'percentage' | 'currency';

@Component({
  selector: 'app-kpi-card',
  imports: [CardModule, ProgressBarModule, Skeleton, NgClass],
  templateUrl: './kpi-card.html',
  styleUrl: './kpi-card.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class KpiCard {
  readonly title = input.required<string>();
  readonly value = input<string | number>('');
  readonly icon = input('');
  readonly iconBgColor = input('');
  readonly trend = input<KpiTrend | null>(null);
  readonly trendValue = input(0);
  readonly progressValue = input(0);
  readonly progressColor = input('');
  readonly subtitle = input('');
  readonly loading = input(false);
  readonly clickable = input(false);
  readonly severity = input<KpiSeverity>('primary');
  readonly format = input<KpiFormat>('number');

  readonly onClick = output<void>();

  readonly severityColors: Record<KpiSeverity, { bg: string; iconBg: string; border: string; progress: string }> = {
    primary: { bg: '#eef4fb', iconBg: '#006699', border: '#00669922', progress: '#006699' },
    success: { bg: '#f0fdf4', iconBg: '#16a34a', border: '#16a34a22', progress: '#16a34a' },
    info: { bg: '#ecfeff', iconBg: '#0284c7', border: '#0284c722', progress: '#0284c7' },
    warning: { bg: '#fefce8', iconBg: '#ca8a04', border: '#ca8a0422', progress: '#ca8a04' },
    danger: { bg: '#fef2f2', iconBg: '#dc2626', border: '#dc262622', progress: '#dc2626' },
  };

  readonly currentColors = computed(() => this.severityColors[this.severity()]);

  readonly displayValue = computed(() => {
    const v = this.value();
    if (typeof v === 'number') {
      switch (this.format()) {
        case 'percentage': return `${v}%`;
        case 'currency': return new Intl.NumberFormat('ar-SA', { style: 'currency', currency: 'SAR' }).format(v);
        default: return new Intl.NumberFormat('ar-SA').format(v);
      }
    }
    return v;
  });

  readonly trendIcon = computed(() => {
    const t = this.trend();
    if (t === 'up') return 'pi pi-arrow-up';
    if (t === 'down') return 'pi pi-arrow-down';
    return 'pi pi-minus';
  });

  readonly trendClass = computed(() => {
    const t = this.trend();
    if (t === 'up') return 'trend-up';
    if (t === 'down') return 'trend-down';
    return 'trend-stable';
  });
}
