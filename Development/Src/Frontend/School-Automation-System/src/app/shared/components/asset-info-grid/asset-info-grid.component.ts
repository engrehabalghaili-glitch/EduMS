import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { DatePipe, DecimalPipe } from '@angular/common';
import { AppTag } from '../tag/tag.component';
import { AssetStatusBadge } from '../asset-status-badge/asset-status-badge.component';
import type { Asset } from '../../models/asset.types';

@Component({
  selector: 'app-asset-info-grid',
  standalone: true,
  imports: [DatePipe, DecimalPipe, AppTag, AssetStatusBadge],
  template: `
    <div class="asset-info-grid" dir="rtl">
      <div class="info-header">
        <app-asset-status-badge [value]="asset().status" mapType="asset" />
        <span class="info-barcode">{{ asset().barcode }}</span>
      </div>
      <h2 class="info-title">{{ asset().name }}</h2>

      <div class="info-section">
        <h3>معلومات عامة</h3>
        <div class="info-grid">
          <div class="info-item">
            <span class="info-label">التصنيف</span>
            <span class="info-value">{{ categoryLabel }}</span>
          </div>
          <div class="info-item">
            <span class="info-label">الموقع</span>
            <span class="info-value">{{ asset().location }}</span>
          </div>
          <div class="info-item">
            <span class="info-label">المسند إلى</span>
            <span class="info-value">{{ asset().assignedTo }}</span>
          </div>
          <div class="info-item">
            <span class="info-label">الدور / القاعة</span>
            <span class="info-value">{{ asset().floor }} · {{ asset().room }}</span>
          </div>
        </div>
      </div>

      <div class="info-section">
        <h3>المعلومات المالية</h3>
        <div class="info-grid">
          <div class="info-item">
            <span class="info-label">تكلفة الشراء</span>
            <span class="info-value">{{ asset().purchaseCost | number }} رس</span>
          </div>
          <div class="info-item">
            <span class="info-label">القيمة الدفترية</span>
            <span class="info-value">{{ asset().currentValue | number }} رس</span>
          </div>
          <div class="info-item">
            <span class="info-label">المورد</span>
            <span class="info-value">{{ asset().supplier }}</span>
          </div>
          <div class="info-item">
            <span class="info-label">رقم الفاتورة</span>
            <span class="info-value">{{ asset().invoiceNumber }}</span>
          </div>
        </div>
      </div>

      <div class="info-section">
        <h3>الضمان</h3>
        <div class="info-grid">
          <div class="info-item">
            <span class="info-label">تاريخ انتهاء الضمان</span>
            <span class="info-value">{{ asset().warrantyEnd | date:'yyyy/MM/dd' }}</span>
          </div>
          <div class="info-item">
            <span class="info-label">حالة الضمان</span>
            <app-tag [value]="asset().warrantyStatus === 'valid' ? 'ساري' : 'منتهي'" [severity]="asset().warrantyStatus === 'valid' ? 'success' : 'danger'" />
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .asset-info-grid { display: flex; flex-direction: column; gap: 1.25rem; }
    .info-header { display: flex; align-items: center; gap: 0.5rem; }
    .info-barcode { font-size: var(--font-size-xs); color: var(--gray-500); font-family: 'Courier New', monospace; }
    .info-title { font-size: var(--font-size-xl); font-weight: 700; color: var(--primary-600); margin: 0; }
    .info-section { }
    .info-section h3 { font-size: var(--font-size-sm); font-weight: 700; color: var(--primary-500); margin: 0 0 10px 0; padding-bottom: 6px; border-bottom: 2px solid var(--gray-200); }
    .info-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 0.75rem; }
    .info-item { display: flex; flex-direction: column; }
    .info-label { font-size: var(--font-size-xs); color: var(--gray-500); }
    .info-value { font-size: var(--font-size-sm); font-weight: 600; color: var(--gray-700); }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetInfoGrid {
  readonly asset = input.required<Asset>();

  get categoryLabel(): string {
    const map: Record<string, string> = { technology: 'أجهزة تقنية', furniture: 'أثاث', vehicle: 'مركبات', building: 'مباني' };
    return map[this.asset().category] || this.asset().category;
  }
}
