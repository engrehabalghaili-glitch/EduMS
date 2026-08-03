import { ChangeDetectionStrategy, Component, computed, forwardRef, inject, input, signal } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl, FormsModule } from '@angular/forms';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { InputText } from 'primeng/inputtext';
import { InputNumber } from 'primeng/inputnumber';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-form-input-group',
  imports: [IconField, InputIcon, InputText, InputNumber, FormsModule, NgClass],
  templateUrl: './form-input-group.html',
  styleUrl: './form-input-group.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => FormInputGroup),
      multi: true,
    },
  ],
})
export class FormInputGroup implements ControlValueAccessor {
  readonly label = input('');
  readonly placeholder = input('');
  readonly type = input<'text' | 'number' | 'email' | 'password' | 'tel'>('text');
  readonly prefixIcon = input('');
  readonly suffixIcon = input('');
  readonly iconPosition = input<'left' | 'right'>('left');
  readonly variant = input<'outlined' | 'filled'>('outlined');
  readonly inputMode = input<'decimal' | 'currency'>('decimal');
  readonly minFractionDigits = input(0);
  readonly maxFractionDigits = input(2);
  readonly currency = input('SAR');
  readonly min = input<number | undefined>(undefined);
  readonly max = input<number | undefined>(undefined);
  readonly hint = input('');

  protected readonly ngControl = inject(NgControl, { optional: true });
  protected readonly isTouched = signal(false);
  private readonly errorVersion = signal(0);

  protected readonly value = signal<string | number>('');
  protected readonly disabled = signal(false);

  private onChange: (_: unknown) => void = () => {};
  private onTouched: () => void = () => {};

  constructor() {
    const control = this.ngControl?.control;
    if (control) {
      control.valueChanges?.subscribe(() => this.errorVersion.update(v => v + 1));
    }
  }

  protected readonly errorMessage = computed(() => {
    this.errorVersion();
    if (!this.isTouched()) return '';
    const errors = this.ngControl?.control?.errors;
    if (!errors) return '';
    const key = Object.keys(errors)[0];
    const params = errors[key] as Record<string, unknown>;
    return this.getTranslation(key, params);
  });

  private getTranslation(key: string, params: Record<string, unknown>): string {
    const map: Record<string, string> = {
      required: 'هذا الحقل مطلوب',
      email: 'البريد الإلكتروني غير صحيح',
      minlength: `يجب أن يكون على الأقل ${params['requiredLength']} حرف`,
      maxlength: `يجب أن يكون على الأكثر ${params['requiredLength']} حرف`,
      min: `يجب أن تكون القيمة ${params['min']} أو أكثر`,
      max: `يجب أن تكون القيمة ${params['max']} أو أقل`,
      pattern: 'النمط غير صحيح',
    };
    return map[key] || 'حقل غير صحيح';
  }

  writeValue(obj: unknown): void {
    const val = obj as string | number;
    this.value.set(val ?? '');
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

  onValueChange(event: string | number): void {
    this.value.set(event);
    this.onChange(event);
    this.errorVersion.update(v => v + 1);
  }

  onBlur(): void {
    this.isTouched.set(true);
    this.onTouched();
    this.errorVersion.update(v => v + 1);
  }
}
