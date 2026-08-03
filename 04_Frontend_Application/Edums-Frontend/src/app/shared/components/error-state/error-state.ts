import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-error-state',
  imports: [ButtonModule],
  templateUrl: './error-state.html',
  styleUrl: './error-state.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ErrorState {
  readonly title = input.required<string>();
  readonly description = input('');
  readonly icon = input('pi pi-fw pi-exclamation-circle');
  readonly errorCode = input('');
  readonly showHome = input(false);

  readonly onGoHome = output<void>();

  goHome(): void {
    this.onGoHome.emit();
  }
}
