import { ChangeDetectionStrategy, Component, forwardRef, input, signal } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormsModule } from '@angular/forms';
import { DatePickerModule } from 'primeng/datepicker';

@Component({
  selector: 'app-date-picker',
  imports: [DatePickerModule, FormsModule],
  templateUrl: './date-picker.html',
  styleUrl: './date-picker.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DatePickerComponent),
      multi: true,
    },
  ],
})
export class DatePickerComponent implements ControlValueAccessor {
  readonly selectionMode = input<'single' | 'multiple' | 'range' | undefined>('single');
  readonly dateFormat = input('yy-mm-dd');
  readonly placeholder = input('اختر تاريخ');
  readonly showIcon = input(true);
  readonly icon = input('pi pi-calendar');
  readonly readonlyInput = input(false);
  readonly showButtonBar = input(true);
  readonly showClear = input(true);
  readonly showTime = input(false);
  readonly timeOnly = input(false);
  readonly hourFormat = input<'12' | '24'>('24');
  readonly showOtherMonths = input(true);
  readonly selectOtherMonths = input(false);
  readonly showOnFocus = input(true);
  readonly numberOfMonths = input(1);
  readonly touchUI = input(false);
  readonly inline = input(false);
  readonly minDate = input<Date | undefined>(undefined);
  readonly maxDate = input<Date | undefined>(undefined);
  readonly styleClass = input('');

  value = signal<Date | Date[] | null>(null);
  disabled = signal(false);

  private onChange: (_: unknown) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: unknown): void {
    this.value.set(obj as Date | Date[] | null);
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
    this.value.set(event as Date | Date[] | null);
    this.onChange(event);
  }

  onBlur(): void {
    this.onTouched();
  }
}
