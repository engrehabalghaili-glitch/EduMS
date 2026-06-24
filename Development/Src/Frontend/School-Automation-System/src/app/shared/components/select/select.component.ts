import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Select } from 'primeng/select';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [FormsModule, Select],
  template: `
    <p-select
      [options]="options()"
      [ngModel]="value()"
      (ngModelChange)="onChange($event)"
      [optionLabel]="optionLabel()"
      [optionValue]="optionValue()"
      [placeholder]="placeholder()"
      [inputId]="inputId()"
      [styleClass]="styleClass()"
      [class.ng-invalid]="invalid()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppSelect {
  readonly options = input.required<any[]>();
  readonly value = input<any>();
  readonly optionLabel = input('label');
  readonly optionValue = input('value');
  readonly placeholder = input('اختر');
  readonly styleClass = input('');
  readonly inputId = input<string>('');
  readonly invalid = input(false);

  readonly valueChange = output<any>();

  onChange(val: any): void {
    this.valueChange.emit(val);
  }
}
