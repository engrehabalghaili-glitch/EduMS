import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ForgotPassword } from './forgot-password';

@Component({
  selector: 'app-forgot-password-page',
  imports: [ForgotPassword],
  template: `<app-forgot-password (forgotPasswordSubmit)="onSubmit($event)" />`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ForgotPasswordPage {
  private readonly router = inject(Router);

  onSubmit(email: string): void {
    this.router.navigate(['/auth', 'reset-password']);
  }
}
