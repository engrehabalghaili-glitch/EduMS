import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ResetPassword } from './reset-password';

@Component({
  selector: 'app-reset-password-page',
  imports: [ResetPassword],
  template: `<app-reset-password (resetPasswordSubmit)="onSubmit($event)" />`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResetPasswordPage {
  onSubmit(password: string): void {
    // TODO: integrate with auth store when reset-password API is ready
  }
}
