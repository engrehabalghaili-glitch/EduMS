import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { AppDivider } from '../../../../../shared/components/divider/divider.component';
import type { AssetFormData } from '../../models/registration.types';
import { ASSET_TYPE_OPTIONS, CATEGORY_TAG_OPTIONS } from '../../models/registration.constants';

@Component({
  selector: 'app-step-verification',
  standalone: true,
  imports: [DecimalPipe, AppDivider],
  template: `
    <div class="step-content">
      <h2 class="step-title">مراجعة البيانات</h2>
      <p class="verification-hint">يرجى مراجعة البيانات المدخلة قبل التأكيد</p>

      <div class="review-section">
        <h3>المعلومات العامة</h3>
        <div class="review-grid">
          <div><span class="review-label">اسم الأصل</span><span class="review-value">{{ data().generalInfo.name }}</span></div>
          <div><span class="review-label">تاريخ الحصول</span><span class="review-value">{{ data().generalInfo.acquisitionDate }}</span></div>
          <div><span class="review-label">نوع الأصل</span><span class="review-value">{{ assetTypeLabel(data().generalInfo.assetType) }}</span></div>
          <div><span class="review-label">الفئات</span><span class="review-value">{{ categoryTagsLabel(data().generalInfo.subCategory) }}</span></div>
          <div><span class="review-label">القيمة التقريبية</span><span class="review-value">{{ data().generalInfo.estimatedValue | number }} ريال يمني</span></div>
          <div><span class="review-label">ملاحظات</span><span class="review-value">{{ data().generalInfo.notes || '—' }}</span></div>
        </div>
      </div>

      <app-divider />

      <div class="review-section">
        <h3>الموقع والباركود</h3>
        <div class="review-grid">
          <div><span class="review-label">الموقع</span><span class="review-value">{{ data().locationTagging.location }}</span></div>
          <div><span class="review-label">الدور</span><span class="review-value">{{ data().locationTagging.floor || '—' }}</span></div>
          <div><span class="review-label">الغرفة</span><span class="review-value">{{ data().locationTagging.room || '—' }}</span></div>
          <div><span class="review-label">الباركود</span><span class="review-value">{{ data().locationTagging.barcode }}</span></div>
        </div>
      </div>

      <app-divider />

      <div class="review-section">
        <h3>الضمان والشراء</h3>
        <div class="review-grid">
          <div><span class="review-label">تاريخ الشراء</span><span class="review-value">{{ data().warrantyStatus.purchaseDate }}</span></div>
          <div><span class="review-label">التكلفة</span><span class="review-value">{{ data().warrantyStatus.purchaseCost | number }} رس</span></div>
          <div><span class="review-label">رقم الفاتورة</span><span class="review-value">{{ data().warrantyStatus.invoiceNumber }}</span></div>
          <div><span class="review-label">نهاية الضمان</span><span class="review-value">{{ data().warrantyStatus.warrantyEnd || '—' }}</span></div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .step-content { padding: 1rem 0; }
    .step-title { font-size: var(--font-size-lg); color: var(--gray-700); margin: 0 0 1.25rem; }
    .verification-hint { font-size: var(--font-size-sm); color: var(--gray-500); margin: -0.75rem 0 1.25rem; }
    .review-section { h3 { font-size: var(--font-size-base); color: var(--gray-600); margin: 0 0 0.75rem; } }
    .review-grid {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 0.75rem;
    }
    .review-grid > div {
      display: flex;
      flex-direction: column;
      gap: 0.15rem;
    }
    .review-label { font-size: var(--font-size-xs); color: var(--gray-400); }
    .review-value { font-size: var(--font-size-sm); color: var(--gray-700); font-weight: 500; }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StepVerificationComponent {
  readonly data = input.required<AssetFormData>();

  readonly assetTypeOptions = ASSET_TYPE_OPTIONS;
  readonly categoryTagOptions = CATEGORY_TAG_OPTIONS;

  assetTypeLabel(value: string): string {
    return this.assetTypeOptions.find(o => o.value === value)?.label || value;
  }

  categoryTagsLabel(values: string[]): string {
    return values.map(v => this.categoryTagOptions.find(o => o.value === v)?.label || v).join('، ');
  }
}
