import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppInputText } from '../../../../../shared/components/input-text/input-text.component';
import type { StepLocationTagging } from '../../models/registration.types';
import type { StepValidationErrors } from '../../models/registration.types';

@Component({
  selector: 'app-step-location-tagging',
  standalone: true,
  imports: [FormsModule, AppInputText],
  template: `
    <div class="step-content">
      <h2 class="step-title">الموقع والباركود</h2>
      <div class="form-grid">
        <div class="field">
          <label for="asset-location">الموقع *</label>
          <app-input-text
            inputId="asset-location"
            [value]="data().location"
            (valueChange)="dataChange.emit({ location: $any($event) })"
            placeholder="مثال: مبنى الإدارة - الدور الثاني"
            [invalid]="!!errors()?.location"
          />
          @if (errors()?.location; as err) {
            <small class="field-error">{{ err }}</small>
          }
        </div>
        <div class="field">
          <label for="asset-floor">الدور</label>
          <app-input-text
            inputId="asset-floor"
            [value]="data().floor"
            (valueChange)="dataChange.emit({ floor: $any($event) })"
          />
        </div>
        <div class="field">
          <label for="asset-room">الغرفة</label>
          <app-input-text
            inputId="asset-room"
            [value]="data().room"
            (valueChange)="dataChange.emit({ room: $any($event) })"
          />
        </div>
        <div class="field">
          <label for="asset-barcode">الباركود *</label>
          <app-input-text
            inputId="asset-barcode"
            [value]="data().barcode"
            (valueChange)="dataChange.emit({ barcode: $any($event) })"
            placeholder="مثال: BRC-2026-001"
            [invalid]="!!errors()?.barcode"
          />
          @if (errors()?.barcode; as err) {
            <small class="field-error">{{ err }}</small>
          }
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
export class StepLocationTaggingComponent {
  readonly data = input.required<StepLocationTagging>();
  readonly errors = input<StepValidationErrors<StepLocationTagging> | undefined>(undefined);
  readonly dataChange = output<Partial<StepLocationTagging>>();
}
