import { ChangeDetectionStrategy, Component, effect, input, output, signal } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { MultiSelectModule } from 'primeng/multiselect';
import { DatePickerModule } from 'primeng/datepicker';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ToggleSwitchModule } from 'primeng/toggleswitch';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';
import { ButtonModule } from 'primeng/button';
import { FormFieldConfig, FormFieldType, SelectOption } from './dynamic-form.types';

export { type FormFieldConfig, type FormFieldType, type SelectOption } from './dynamic-form.types';

@Component({
  selector: 'app-dynamic-form',
  imports: [
    ReactiveFormsModule, InputTextModule, InputNumberModule, SelectModule,
    MultiSelectModule, DatePickerModule, CheckboxModule, RadioButtonModule,
    ToggleSwitchModule, EditorModule, InputMaskModule, ButtonModule,
  ],
  templateUrl: './dynamic-form.html',
  styleUrl: './dynamic-form.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DynamicForm {
  readonly formConfig = input.required<FormFieldConfig[]>();
  readonly initialValues = input<Record<string, unknown>>({});
  readonly submitLabel = input('حفظ');
  readonly cancelLabel = input('إلغاء');
  readonly showCancel = input(true);
  readonly loading = input(false);
  readonly readonly = input(false);
  readonly columnsPerRow = input(2);

  readonly onSubmit = output<Record<string, unknown>>();
  readonly onCancel = output<void>();
  readonly onValueChange = output<{ field: string; value: unknown }>();

  formGroup = signal<FormGroup>(new FormGroup({}));

  private valueChangesSub: (() => void) | null = null;

  constructor() {
    effect(() => {
      const config = this.formConfig();
      const values = this.initialValues();
      this.rebuildForm(config, values);
    });
  }

  private rebuildForm(config: FormFieldConfig[], values: Record<string, unknown>): void {
    const group = new FormGroup({});
    for (const field of config) {
      const value = values[field.name] ?? field.defaultValue ?? '';
      group.addControl(field.name, new FormControl({ value, disabled: field.disabled ?? false }));
    }
    this.formGroup.set(group);

    this.valueChangesSub?.();
    const sub = group.valueChanges.subscribe(() => {
      const ctrlProps = Object.keys(group.controls);
      for (const name of ctrlProps) {
        const ctrl = group.get(name);
        if (ctrl?.dirty) {
          this.onValueChange.emit({ field: name, value: ctrl.value });
        }
      }
    });
    this.valueChangesSub = () => sub.unsubscribe();
  }

  submit(): void {
    if (this.formGroup().invalid) return;
    this.onSubmit.emit(this.formGroup().value);
  }

  cancel(): void {
    this.onCancel.emit();
  }

  getFieldErrors(field: FormFieldConfig): string[] {
    const ctrl = this.formGroup().get(field.name);
    if (!ctrl || !ctrl.touched || !ctrl.errors) return [];
    const msgs: string[] = [];
    if (ctrl.errors['required']) msgs.push('هذا الحقل مطلوب');
    if (ctrl.errors['min']) msgs.push(`أقل قيمة ${ctrl.errors['min'].min}`);
    if (ctrl.errors['max']) msgs.push(`أقصى قيمة ${ctrl.errors['max'].max}`);
    if (ctrl.errors['minlength']) msgs.push(`أقل عدد أحرف ${ctrl.errors['minlength'].requiredLength}`);
    if (ctrl.errors['maxlength']) msgs.push(`أقصى عدد أحرف ${ctrl.errors['maxlength'].requiredLength}`);
    if (ctrl.errors['pattern']) msgs.push('القيمة غير صالحة');
    return msgs;
  }

  gridColumns(): string {
    return `repeat(${this.columnsPerRow()}, 1fr)`;
  }

  fieldCols(field: FormFieldConfig): number {
    return Math.min(field.cols ?? 1, this.columnsPerRow());
  }

  isVisible(field: FormFieldConfig): boolean {
    return field.visible ?? true;
  }

  isDisabled(field: FormFieldConfig): boolean {
    return this.readonly() || (field.disabled ?? false);
  }

  fieldId(field: FormFieldConfig): string {
    return `df-${field.name}`;
  }
}
