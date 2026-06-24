import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Textarea } from 'primeng/textarea';

@Component({
  selector: 'app-input-textarea',
  standalone: true,
  imports: [FormsModule, Textarea],
  template: `
    <textarea
      pTextarea
      [ngModel]="value()"
      (ngModelChange)="onChange($event)"
      [class]="styleClass()"
      [id]="inputId()"
      [rows]="rows()"
      [class.p-invalid]="invalid()"></textarea>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppInputTextarea {
  readonly value = model<string>();
  readonly inputId = input<string>('');
  readonly rows = input(2);
  readonly styleClass = input('');
  readonly invalid = input(false);

  onChange(val: any): void {
    this.value.set(val);
  }
}
