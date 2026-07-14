import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { type LoginCredentials, AuthStore } from '../../../../core/auth';
import { Login } from './login';

@Component({
  selector: 'app-login-page',
  imports: [Login],
  template: `<app-login [loading]="authStore.loading()" (loginSubmit)="onLogin($event)" />`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginPage {
  protected readonly authStore = inject(AuthStore);

  onLogin(credentials: LoginCredentials): void {
    this.authStore.login(credentials);
  }
}
