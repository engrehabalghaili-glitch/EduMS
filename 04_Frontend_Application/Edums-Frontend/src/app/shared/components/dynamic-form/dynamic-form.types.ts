export type FormFieldType = 'text' | 'textarea' | 'number' | 'dropdown' | 'multiSelect' | 'date' | 'checkbox' | 'radio' | 'switch' | 'editor' | 'mask';

export interface SelectOption {
  label: string;
  value: unknown;
}

export interface FormFieldConfig {
  name: string;
  label: string;
  type: FormFieldType;
  placeholder?: string;
  defaultValue?: unknown;
  validators?: import('@angular/forms').ValidatorFn[];
  options?: SelectOption[];
  cols?: number;
  disabled?: boolean;
  visible?: boolean;
  hint?: string;
  min?: number;
  max?: number;
  step?: number;
  mask?: string;
  rows?: number;
}
