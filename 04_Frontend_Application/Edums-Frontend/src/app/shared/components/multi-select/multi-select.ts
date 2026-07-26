import { ChangeDetectionStrategy, Component, contentChild, forwardRef, input, signal, TemplateRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-multi-select',
  imports: [MultiSelectModule, FormsModule],
  templateUrl: './multi-select.html',
  styleUrl: './multi-select.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MultiSelectComponent),
      multi: true,
    },
  ],
})
export class MultiSelectComponent implements ControlValueAccessor {
  readonly options = input<any[]>([]);
  readonly optionLabel = input<string>('label');
  readonly optionValue = input<string>('value');
  readonly optionDisabled = input<string>('disabled');
  readonly placeholder = input('اختر...');
  readonly filter = input(true);
  readonly display = input<'comma' | 'chip'>('chip');
  readonly maxSelectedLabels = input<number>(3);
  readonly selectedItemsLabel = input('');
  readonly showToggleAll = input(true);
  readonly selectionLimit = input<number | undefined>(undefined);
  readonly showClear = input(false);
  readonly loading = input(false);
  readonly showHeader = input(true);
  readonly resetFilterOnHide = input(true);
  readonly emptyMessage = input('لا توجد نتائج');
  readonly emptyFilterMessage = input('لا توجد نتائج مطابقة');
  readonly filterMatchMode = input<'contains' | 'startsWith' | 'endsWith' | 'equals' | 'notEquals'>('contains');
  readonly styleClass = input('');

  value = signal<any[]>([]);
  disabled = signal(false);

  private onChange: (_: unknown) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: unknown): void {
    this.value.set(Array.isArray(obj) ? obj : []);
  }

  registerOnChange(fn: (_: unknown) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled.set(isDisabled);
  }

  onValueChange(event: unknown): void {
    const items = event as any[];
    this.value.set(items);
    this.onChange(event);
  }

  onBlur(): void {
    this.onTouched();
  }
}
