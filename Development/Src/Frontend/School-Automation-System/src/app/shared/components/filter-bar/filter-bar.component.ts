import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Select } from 'primeng/select';
import { InputText } from 'primeng/inputtext';
import { DatePicker } from 'primeng/datepicker';
import { ButtonDirective } from 'primeng/button';
import type { FilterField } from '../../interfaces/shared.types';

@Component({
  selector: 'app-filter-bar',
  imports: [FormsModule, Select, InputText, DatePicker, ButtonDirective],
  template: `
    <div class="filter-bar">
      @for (field of fields(); track field.field) {
        <div class="filter-field">
          <label class="filter-label">{{ field.header }}</label>
          @switch (field.type) {
            @case ('text') {
              <input
                pInputText
                type="text"
                [placeholder]="field.placeholder || 'بحث...'"
                [ngModel]="filters()[field.field]"
                (ngModelChange)="filterChange.emit({field: field.field, value: $event})"
                class="filter-input"
              />
            }
            @case ('select') {
              <p-select
                [options]="field.options || []"
                optionLabel="label"
                optionValue="value"
                [placeholder]="field.placeholder || 'الكل'"
                [ngModel]="filters()[field.field]"
                (ngModelChange)="filterChange.emit({field: field.field, value: $event})"
                styleClass="w-full"
                [showClear]="true"
              />
            }
            @case ('date') {
              <p-datePicker
                [ngModel]="filters()[field.field]"
                (ngModelChange)="filterChange.emit({field: field.field, value: $event})"
                [placeholder]="field.placeholder || 'اختر تاريخاً'"
                styleClass="w-full"
                [showClear]="true"
              />
            }
          }
        </div>
      }
      @if (showReset()) {
        <button
          pButton
          icon="pi pi-filter-slash"
          label="مسح الكل"
          class="p-button-outlined p-button-sm"
          severity="secondary"
          (click)="reset.emit()"
        ></button>
      }
    </div>
  `,
  styleUrl: './filter-bar.component.scss',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FilterBarComponent {
  readonly fields = input.required<FilterField[]>();
  readonly filters = input<Record<string, any>>({});
  readonly showReset = input(false);
  readonly filterChange = output<{ field: string; value: any }>();
  readonly reset = output<void>();
}
