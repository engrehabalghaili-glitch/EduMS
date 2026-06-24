import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { AppInputText } from '../../../../../shared/components/input-text/input-text.component';
import { AppInputTextarea } from '../../../../../shared/components/input-textarea/input-textarea.component';
import { AppButton } from '../../../../../shared/components/button/button.component';
import type { StepGeneralInfo } from '../../models/registration.types';
import type { StepValidationErrors } from '../../models/registration.types';
import { ASSET_TYPE_OPTIONS, CATEGORY_TAG_OPTIONS } from '../../models/registration.constants';

@Component({
  selector: 'app-step-general-info',
  standalone: true,
  imports: [AppInputText, AppInputTextarea, AppButton],
  template: `
    <div class="step-content">
      <div class="form-grid">

        <!-- Row 1: name + acquisitionDate -->
        <div class="field">
          <label for="asset-name">اسم الأصل *</label>
          <app-input-text
            inputId="asset-name"
            [value]="data().name"
            (valueChange)="dataChange.emit({ name: $any($event) })"
            [invalid]="!!errors()?.name"
          />
          @if (errors()?.name; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>
        <div class="field">
          <label for="acquisition-date">تاريخ الحصول *</label>
          <app-input-text
            inputId="acquisition-date"
            type="date"
            [value]="data().acquisitionDate"
            (valueChange)="dataChange.emit({ acquisitionDate: $any($event) })"
            [invalid]="!!errors()?.acquisitionDate"
          />
          @if (errors()?.acquisitionDate; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>

        <!-- Row 2: assetType radio cards -->
        <div class="field full-width">
          <label>نوع الأصل *</label>
          <div class="asset-type-group">
            @for (type of assetTypeOptions; track type.value) {
              <label class="asset-type-card" [class.selected]="data().assetType === type.value">
                <input type="radio" name="assetType" [value]="type.value"
                  [checked]="data().assetType === type.value"
                  (change)="dataChange.emit({ assetType: type.value })" />
                <i [class]="type.icon"></i>
                <span>{{ type.label }}</span>
              </label>
            }
          </div>
          @if (errors()?.assetType; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>

        <!-- Row 3: subCategory tags -->
        <div class="field full-width">
          <label>فئات الأصل *</label>
          <div class="category-tags">
            @for (cat of categoryTagOptions; track cat.value) {
              <button type="button" class="category-tag"
                [class.selected]="data().subCategory.includes(cat.value)"
                (click)="toggleCategory(cat.value)">
                <i [class]="cat.icon"></i>
                <span>{{ cat.label }}</span>
              </button>
            }
          </div>
          @if (errors()?.subCategory; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>

        <!-- Row 4: estimatedValue with currency suffix -->
        <div class="field full-width">
          <label for="estimated-value">القيمة التقريبية *</label>
          <div class="currency-input-wrapper">
            <app-input-text
              inputId="estimated-value"
              type="number"
              [value]="data().estimatedValue ?? undefined"
              (valueChange)="dataChange.emit({ estimatedValue: $any($event) })"
              [invalid]="!!errors()?.estimatedValue"
            />
            <span class="currency-suffix">ريال يمني</span>
          </div>
          @if (errors()?.estimatedValue; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>

        <!-- Row 5: notes full-width -->
        <div class="field full-width">
          <label for="asset-notes">ملاحظات إضافية / الوصف</label>
          <app-input-textarea
            inputId="asset-notes"
            [value]="data().notes"
            (valueChange)="dataChange.emit({ notes: $any($event) })"
            [rows]="3"
          />
        </div>
      </div>
    </div>

    <!-- Form Actions -->
    <div class="form-actions">
      <app-button label="إلغاء" styleClass="p-button-text" (click)="cancel.emit()" />
      <div class="form-actions-left">
        <app-button label="تحقق تلقائي" icon="pi pi-check" styleClass="p-button-outlined" (click)="validate.emit()" />
        <app-button label="التالي" icon="pi pi-chevron-left" iconPos="right" (click)="next.emit()" />
      </div>
    </div>

    <!-- Hint Cards -->
    <div class="hint-cards">
      <div class="hint-card">
        <i class="pi pi-lightbulb"></i>
        <div>
          <strong>تلميح سريع</strong>
          <p>يمكنك تعديل البيانات لاحقاً من صفحة الأصول</p>
        </div>
      </div>
      <div class="hint-card">
        <i class="pi pi-qrcode"></i>
        <div>
          <strong>الجرد الآلي</strong>
          <p>سيتم إنشاء باركود فريد لكل أصل تلقائياً</p>
        </div>
      </div>
      <div class="hint-card">
        <i class="pi pi-shield"></i>
        <div>
          <strong>أمن البيانات</strong>
          <p>جميع البيانات مشفرة ومحمية حسب أعلى المعايير</p>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .step-content { padding: 1rem 0; }
    .form-grid {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 1.25rem;
    }
    .field {
      display: flex;
      flex-direction: column;
      gap: 0.35rem;
    }
    .field.full-width { grid-column: 1 / -1; }
    .field label { font-size: var(--font-size-sm); font-weight: 600; color: var(--gray-600); }
    .field-error { font-size: var(--font-size-xs); color: var(--danger-500); }

    .asset-type-group {
      display: flex;
      gap: 0.75rem;
      flex-wrap: wrap;
    }
    .asset-type-card {
      display: flex;
      flex-direction: column;
      align-items: center;
      gap: 0.4rem;
      padding: 0.75rem 1.25rem;
      border: 2px solid var(--surface-border);
      border-radius: var(--border-radius-lg);
      cursor: pointer;
      transition: all 0.2s;
      background: var(--surface-card);
      min-width: 90px;
    }
    .asset-type-card input { display: none; }
    .asset-type-card i { font-size: 1.5rem; color: var(--text-color-secondary); }
    .asset-type-card span { font-size: var(--font-size-xs); font-weight: 600; color: var(--text-color-secondary); white-space: nowrap; }
    .asset-type-card:hover { border-color: var(--primary-300); background: var(--primary-50); }
    .asset-type-card.selected { border-color: var(--primary-color); background: var(--primary-50); }
    .asset-type-card.selected i { color: var(--primary-color); }
    .asset-type-card.selected span { color: var(--primary-color); }

    .category-tags {
      display: flex;
      gap: 0.5rem;
      flex-wrap: wrap;
    }
    .category-tag {
      display: inline-flex;
      align-items: center;
      gap: 0.35rem;
      padding: 0.45rem 0.85rem;
      border: 1px solid var(--surface-border);
      border-radius: var(--border-radius-xl);
      cursor: pointer;
      transition: all 0.2s;
      background: var(--surface-card);
      font-size: var(--font-size-xs);
      font-weight: 600;
      color: var(--text-color-secondary);
    }
    .category-tag i { font-size: 0.85rem; }
    .category-tag:hover { border-color: var(--primary-300); background: var(--primary-50); color: var(--primary-color); }
    .category-tag.selected { background: var(--primary-color); border-color: var(--primary-color); color: var(--primary-color-text); }
    .category-tag.selected i { color: var(--primary-color-text); }

    .currency-input-wrapper {
      display: flex;
      align-items: center;
      gap: 0.5rem;
      max-width: 320px;
    }
    .currency-input-wrapper app-input-text { flex: 1; }
    .currency-suffix {
      font-size: var(--font-size-xs);
      font-weight: 700;
      color: var(--primary-color);
      white-space: nowrap;
    }

    .form-actions {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-top: 1.5rem;
      padding-top: 1rem;
      border-top: 1px solid var(--surface-border);
    }
    .form-actions-left { display: flex; gap: 0.75rem; align-items: center; }

    .hint-cards {
      display: grid;
      grid-template-columns: 1fr 1fr 1fr;
      gap: 1rem;
      margin-top: 1.25rem;
    }
    .hint-card {
      display: flex;
      align-items: flex-start;
      gap: 0.75rem;
      padding: 1rem;
      background: var(--surface-ground);
      border-radius: var(--border-radius-lg);
      border: 1px solid var(--surface-border);
    }
    .hint-card i { font-size: 1.5rem; color: var(--primary-color); margin-top: 0.15rem; }
    .hint-card strong { font-size: var(--font-size-sm); color: var(--gray-700); display: block; margin-bottom: 0.2rem; }
    .hint-card p { margin: 0; font-size: var(--font-size-xs); color: var(--gray-500); line-height: 1.5; }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StepGeneralInfoComponent {
  readonly data = input.required<StepGeneralInfo>();
  readonly errors = input<StepValidationErrors<StepGeneralInfo> | undefined>(undefined);

  readonly dataChange = output<Partial<StepGeneralInfo>>();
  readonly cancel = output<void>();
  readonly validate = output<void>();
  readonly next = output<void>();

  readonly assetTypeOptions = ASSET_TYPE_OPTIONS;
  readonly categoryTagOptions = CATEGORY_TAG_OPTIONS;

  toggleCategory(value: string): void {
    const current = this.data().subCategory;
    const updated = current.includes(value)
      ? current.filter(v => v !== value)
      : [...current, value];
    this.dataChange.emit({ subCategory: updated });
  }
}
