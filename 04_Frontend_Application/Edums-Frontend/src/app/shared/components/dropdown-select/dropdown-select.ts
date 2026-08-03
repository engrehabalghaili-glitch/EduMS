import { ChangeDetectionStrategy, Component, contentChild, forwardRef, input, signal, TemplateRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';

@Component({
  selector: 'app-dropdown-select',
  imports: [SelectModule, FormsModule],
  templateUrl: './dropdown-select.html',
  styleUrl: './dropdown-select.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DropdownSelect),
      multi: true,
    },
  ],
})
export class DropdownSelect implements ControlValueAccessor {
  readonly options = input<any[]>([]);
  readonly optionLabel = input<string>('label');
  readonly optionValue = input<string>('value');
  readonly optionDisabled = input<string>('disabled');
  readonly placeholder = input('اختر...');
  readonly filter = input(true);
  readonly showClear = input(false);
  readonly loading = input(false);
  readonly editable = input(false);
  readonly readonly = input(false);
  readonly dataKey = input<string>('');
  readonly emptyMessage = input('لا توجد نتائج');
  readonly emptyFilterMessage = input('لا توجد نتائج مطابقة');
  readonly checkmark = input(true);
  readonly resetFilterOnHide = input(true);
  readonly selectOnFocus = input(true);
  readonly autoOptionFocus = input(true);
  readonly filterMatchMode = input<'contains' | 'startsWith' | 'endsWith' | 'equals' | 'notEquals'>('contains');
  readonly virtualScroll = input(false);
  readonly virtualScrollItemSize = input(38);
  readonly styleClass = input('');

  readonly customTemplate = contentChild<TemplateRef<unknown>>('item');

  value = signal<any>(null);
  disabled = signal(false);

  private onChange: (_: unknown) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: unknown): void {
    this.value.set(obj);
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
    this.value.set(event);
    this.onChange(event);
  }

  onBlur(): void {
    this.onTouched();
  }
}
