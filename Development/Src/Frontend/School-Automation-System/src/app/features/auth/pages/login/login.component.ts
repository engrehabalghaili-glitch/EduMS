import { ChangeDetectionStrategy, Component, inject, signal, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AppCard } from '../../../../shared/components/card/card.component';
import { AppInputText } from '../../../../shared/components/input-text/input-text.component';
import { AppPassword } from '../../../../shared/components/password/password.component';
import { AppCheckbox } from '../../../../shared/components/checkbox/checkbox.component';
import { AppButton } from '../../../../shared/components/button/button.component';
import { UserRole } from '../../../../core/layout/main-layout/main-layout.types';
import { AuthStore } from '../../store/auth.store';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [AppCard, AppInputText, AppPassword, AppCheckbox, AppButton],
  template: `
    <div class="login-page">
      <div class="login-container">
        <app-card styleClass="login-card">
          <div class="login-header">
            <i class="pi pi-graduation-cap login-icon"></i>
            <h1 class="login-title">نظام إدارة المدارس</h1>
            <p class="login-subtitle">تسجيل الدخول إلى النظام</p>
          </div>

          @if (store.error(); as errMsg) {
            <div class="login-error">
              <i class="pi pi-exclamation-circle"></i>
              <span>{{ errMsg }}</span>
            </div>
          }

          <div class="login-form">
            <div class="field">
              <label for="email">البريد الإلكتروني</label>
              <app-input-text
                [(value)]="email"
                styleClass="w-full"
                placeholder="admin@school.com"
                inputId="email"
              />
              @if (submitted && !email().trim()) {
                <small class="field-error">البريد الإلكتروني مطلوب</small>
              }
            </div>
            <div class="field">
              <label for="password">كلمة المرور</label>
              <app-password
                [(value)]="password"
                [feedback]="false"
                [toggleMask]="true"
                styleClass="w-full"
                inputStyleClass="w-full"
                inputId="password"
              />
              @if (submitted && !password()) {
                <small class="field-error">كلمة المرور مطلوبة</small>
              }
            </div>
            <div class="login-options">
              <app-checkbox [(checked)]="rememberMe" label="تذكرني" inputId="remember" />
            </div>

            <app-button
              label="تسجيل الدخول"
              type="submit"
              styleClass="w-full login-submit-btn"
              [disabled]="store.loading() || !email().trim() || !password()"
              [icon]="store.loading() ? 'pi pi-spin pi-spinner' : 'pi pi-sign-in'"
              (click)="onLogin()"
            />
          </div>

          <div class="login-test-section">
            <div class="test-header">
              <i class="pi pi-lock-open"></i>
              <span>حسابات اختبارية</span>
            </div>
            <p class="test-hint">للدخول بسرعة أثناء التطوير، اختر أحد الأدوار:</p>
            <div class="role-buttons">
              @for (role of testRoles; track role.label) {
                <app-button
                  [label]="role.label"
                  [styleClass]="'role-btn role-' + role.value"
                  (click)="loginAs(role.value)"
                  [disabled]="store.loading()"
                />
              }
            </div>
          </div>
        </app-card>
      </div>
    </div>
  `,
  styles: [`
    .login-page {
      direction: rtl;
      min-height: 100vh;
      display: flex;
      align-items: center;
      justify-content: center;
      background: var(--surface-ground);
      padding: 1rem;
    }
    .login-container { width: 100%; max-width: 420px; }
    .login-card .p-card-body { padding: 2rem; }
    .login-header { text-align: center; margin-bottom: 2rem; }
    .login-icon { font-size: 3rem; color: var(--primary-color); margin-bottom: 1rem; }
    .login-title { margin: 0; font-size: 1.5rem; color: var(--text-color); }
    .login-subtitle { margin: 0.25rem 0 0; color: var(--text-color-secondary); }
    .login-form { display: flex; flex-direction: column; gap: 1.25rem; }
    .field { display: flex; flex-direction: column; gap: 0.375rem; }
    .field label { font-weight: 600; color: var(--text-color); font-size: 0.875rem; }
    .field-error { color: var(--red-500, #e24c4c); font-size: 0.75rem; }
    .login-options { display: flex; justify-content: space-between; align-items: center; }
    .login-error {
      display: flex; align-items: center; gap: 0.5rem;
      background: var(--red-50, #fff5f5); color: var(--red-600, #c63737);
      padding: 0.75rem; border-radius: 6px; font-size: 0.875rem;
      border: 1px solid var(--red-200, #f5c6c6); margin-bottom: 1rem;
    }
    .login-error i { font-size: 1rem; flex-shrink: 0; }
    .login-test-section {
      margin-top: 1.5rem; padding-top: 1.25rem;
      border-top: 1px solid var(--surface-border);
    }
    .test-header {
      display: flex; align-items: center; gap: 0.5rem;
      justify-content: center; margin-bottom: 0.5rem;
      color: var(--text-color-secondary); font-size: 0.875rem; font-weight: 600;
    }
    .test-header i { font-size: 0.875rem; }
    .test-hint {
      margin: 0 0 0.75rem; font-size: 0.75rem;
      color: var(--text-color-secondary); text-align: center;
    }
    .role-buttons { display: flex; flex-wrap: wrap; gap: 0.5rem; justify-content: center; }
    .role-btn { font-size: 0.75rem; }
  `],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent {
  readonly store = inject(AuthStore);
  private readonly router = inject(Router);

  readonly email = signal('');
  readonly password = signal('');
  readonly rememberMe = signal(false);
  submitted = false;

  readonly testRoles = [
    { label: 'مدير المدرسة', value: UserRole.SCHOOL_MANAGER },
    { label: 'معلم', value: UserRole.TEACHER },
    { label: 'طالب', value: UserRole.STUDENT },
    { label: 'مدير أصول', value: UserRole.ASSET_MANAGER },
    { label: 'محاسب', value: UserRole.FINANCIAL_ACCOUNTANT },
    { label: 'موارد بشرية', value: UserRole.HR_MANAGER },
    { label: 'شؤون طلاب', value: UserRole.STUDENT_AFFAIRS },
    { label: 'مشرف', value: UserRole.OFFICE_SUPERVISOR },
  ];

  async onLogin(): Promise<void> {
    this.submitted = true;
    const email = this.email().trim();
    const password = this.password();
    if (!email || !password) return;
    try {
      await this.store.login(email, password);
      this.router.navigateByUrl('/dashboard');
    } catch {
      /* error handled by store.error signal */
    }
  }

  async loginAs(role: UserRole): Promise<void> {
    try {
      await this.store.loginAs(role);
      this.router.navigateByUrl('/dashboard');
    } catch {
      /* error handled by store.error signal */
    }
  }
}
