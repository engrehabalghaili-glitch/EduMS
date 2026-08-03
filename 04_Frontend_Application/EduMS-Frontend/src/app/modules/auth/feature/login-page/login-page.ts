import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

// PrimeNG Modules
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';

import { AuthService } from '../../../../core/auth/auth.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CardModule,
    InputTextModule,
    PasswordModule,
    ButtonModule
  ],
  templateUrl: './login-page.html'
})
export class LoginPage {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  // تعريف نموذج تسجيل الدخول
  loginForm = this.fb.group({
    username: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  isLoading = false;
  errorMessage = '';

  onSubmit() {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    const credentials = {
      username: this.loginForm.value.username ?? '',
      password: this.loginForm.value.password ?? ''
    };

    this.authService.login(credentials).subscribe({
      next: (res) => {
        this.isLoading = false;
        if (res.succeeded) {
          // التوجيه إلى الصفحة الرئيسية بعد نجاح الدخول
          this.router.navigate(['/']);
        } else {
          this.errorMessage = res.message || 'فشل تسجيل الدخول';
        }
      },
      error: (err) => {
        this.isLoading = false;
        // معالجة الأخطاء القادمة من الباك إند
        if (err.status === 401) {
          this.errorMessage = 'اسم المستخدم أو كلمة المرور غير صحيحة';
        } else {
          this.errorMessage = 'حدث خطأ في الاتصال بالخادم';
        }
      }
    });
  }
}
