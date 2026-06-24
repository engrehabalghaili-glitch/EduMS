import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppInputText } from '../../../../../shared/components/input-text/input-text.component';
import type { StepWarrantyStatus } from '../../models/registration.types';
import type { StepValidationErrors } from '../../models/registration.types';

@Component({
  selector: 'app-step-warranty-status',
  standalone: true,
  imports: [FormsModule, AppInputText],
  template: `
    <div class="step-content">
      <h2 class="step-title">الضمان والشراء</h2>
      <div class="form-grid">
        <div class="field">
          <label for="asset-purchase-date">تاريخ الشراء *</label>
          <app-input-text
            inputId="asset-purchase-date"
            type="date"
            [value]="data().purchaseDate"
            (valueChange)="dataChange.emit({ purchaseDate: $any($event) })"
            [invalid]="!!errors()?.purchaseDate"
          />
          @if (errors()?.purchaseDate; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>
        <div class="field">
          <label for="asset-cost">تكلفة الشراء (رس) *</label>
          <app-input-text
            inputId="asset-cost"
            type="number"
            [value]="data().purchaseCost ?? undefined"
            (valueChange)="dataChange.emit({ purchaseCost: $any($event) })"
            [invalid]="!!errors()?.purchaseCost"
          />
          @if (errors()?.purchaseCost; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>
        <div class="field">
          <label for="asset-invoice">رقم الفاتورة *</label>
          <app-input-text
            inputId="asset-invoice"
            [value]="data().invoiceNumber"
            (valueChange)="dataChange.emit({ invoiceNumber: $any($event) })"
            [invalid]="!!errors()?.invoiceNumber"
          />
          @if (errors()?.invoiceNumber; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>
        <div class="field">
          <label for="asset-warranty-end">نهاية الضمان</label>
          <app-input-text
            inputId="asset-warranty-end"
            type="date"
            [value]="data().warrantyEnd"
            (valueChange)="dataChange.emit({ warrantyEnd: $any($event) })"
          />
        </div>
      </div>
    </div>
  `,
  styles: [`
    .step-content { padding: 1rem 0; }
    .step-title { font-size: var(--font-size-lg); color: var(--gray-700); margin: 0 0 1.25rem; }
    .form-grid {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 1rem;
    }
    .field {
      display: flex;
      flex-direction: column;
      gap: 0.35rem;
    }
    .field label { font-size: var(--font-size-sm); font-weight: 600; color: var(--gray-600); }
    .field-error { font-size: var(--font-size-xs); color: var(--danger-500); }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StepWarrantyStatusComponent {
  readonly data = input.required<StepWarrantyStatus>();
  readonly errors = input<StepValidationErrors<StepWarrantyStatus> | undefined>(undefined);
  readonly dataChange = output<Partial<StepWarrantyStatus>>();
}
