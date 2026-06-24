import { ChangeDetectionStrategy, Component, input, output, signal } from '@angular/core';
import { AppInputText } from '../input-text/input-text.component';
import { AppSelect } from '../select/select.component';
import { AppButton } from '../button/button.component';

export interface FilterFieldConfig {
  key: string;
  label: string;
  type: 'text' | 'select';
  placeholder?: string;
  options?: { label: string; value: string }[];
}

export interface FilterState {
  [key: string]: string;
}

@Component({
  selector: 'app-asset-filter-bar',
  standalone: true,
  imports: [AppInputText, AppSelect, AppButton],
  template: `
    <div class="filter-bar" dir="rtl">
      @for (field of fields(); track field.key) {
        @if (field.type === 'text') {
          <app-input-text
            [value]="values()[field.key] || ''"
            (valueChange)="setValue(field.key, $event)"
            [placeholder]="field.placeholder || 'بحث...'"
            styleClass="filter-text"
          />
        } @else if (field.type === 'select' && field.options) {
          <app-select
            [options]="field.options"
            [value]="values()[field.key] || ''"
            (valueChange)="setValue(field.key, $event)"
            optionLabel="label"
            optionValue="value"
            [placeholder]="field.placeholder || field.label"
            styleClass="filter-select"
          />
        }
      }
      <app-button
        icon="pi pi-search"
        styleClass="p-button-sm"
        (click)="apply()"
      />
      <app-button
        icon="pi pi-times"
        styleClass="p-button-sm p-button-outlined"
        (click)="reset()"
      />
    </div>
  `,
  styles: [`
    .filter-bar { display: flex; align-items: center; gap: 0.5rem; flex-wrap: wrap; }
    .filter-text { min-width: 200px; }
    .filter-select { min-width: 140px; }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetFilterBar {
  readonly fields = input.required<FilterFieldConfig[]>();

  readonly filterChange = output<FilterState>();

  private readonly _values = signal<FilterState>({});

  values(): FilterState {
    return this._values();
  }

  setValue(key: string, val: string | number | undefined): void {
    this._values.update(v => ({ ...v, [key]: String(val ?? '') }));
  }

  apply(): void {
    this.filterChange.emit({ ...this._values() });
  }

  reset(): void {
    this._values.set({});
    this.apply();
  }
}
