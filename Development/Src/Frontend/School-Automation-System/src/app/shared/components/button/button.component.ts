import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { ButtonDirective } from 'primeng/button';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [ButtonDirective],
  template: `
    <button
      pButton
      [label]="label()"
      [icon]="icon()"
      [disabled]="disabled()"
      [loading]="loading()"
      [class]="styleClass()"
      [style]="style()"
      [attr.type]="type()"
      [iconPos]="iconPos()"
      (click)="onClick()">
      <ng-content />
    </button>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppButton {
  readonly label = input<string>('');
  readonly icon = input<string>('');
  readonly disabled = input(false);
  readonly loading = input(false);
  readonly styleClass = input<string>('');
  readonly style = input<Record<string, string>>({});
  readonly type = input<'button' | 'submit' | 'reset'>('button');
  readonly iconPos = input<'left' | 'right' | 'top' | 'bottom'>('left');

  readonly click = output<void>();

  onClick(): void {
    this.click.emit();
  }
}
