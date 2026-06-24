import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Password } from 'primeng/password';

@Component({
  selector: 'app-password',
  standalone: true,
  imports: [FormsModule, Password],
  template: `
    <p-password
      [(ngModel)]="value"
      [feedback]="feedback()"
      [toggleMask]="toggleMask()"
      [styleClass]="styleClass()"
      [inputStyleClass]="inputStyleClass()"
      [inputId]="inputId()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppPassword {
  readonly value = model<string>('');
  readonly feedback = input(false);
  readonly toggleMask = input(true);
  readonly styleClass = input('');
  readonly inputStyleClass = input('');
  readonly inputId = input<string>('');
}
