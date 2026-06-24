import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { AuthService } from '../../../../core/auth/auth'; // <--- تأكد من صحة مسار الخدمة لديك

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
    CheckboxModule,
    ToastModule
  ],
  providers: [MessageService],
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private messageService = inject(MessageService);
  private authService = inject(AuthService); // <--- 1. حقن خدمة المصادقة هنا

  isLoading = signal<boolean>(false);
  showPassword = signal<boolean>(false);
  forgotPassword = signal<boolean>(false);

  loginForm: FormGroup = this.fb.group({
    username: ['admin@edums.demo', [Validators.required, Validators.email]],
    password: ['demo123', [Validators.required, Validators.minLength(6)]],
    rememberMe: [true]
  });

  togglePasswordVisibility() {
    this.showPassword.update(val => !val);
  }

  onSubmit() {
  if (this.loginForm.invalid) {
    this.messageService.add({
      severity: 'error',
      summary: 'خطأ في المدخلات',
      detail: 'الرجاء التأكد من كتابة البريد الإلكتروني وكلمة المرور بشكل صحيح.'
    });
    return;
  }

  this.isLoading.set(true);

  // محاكاة طلب الـ API بمؤقت واحد فقط
  setTimeout(() => {
    this.isLoading.set(false);

    const email = this.loginForm.value.username;
    let userRole = 'student'; // الافتراضي

    if (email.includes('admin')) {
      userRole = 'admin';
    } else if (email.includes('finance') || email.includes('accountant')) {
      userRole = 'accountant';
    } else if (email.includes('teacher')) {
      userRole = 'teacher';
    }

    // 1. تحديث الجلسة فوراً
    this.authService.setSession('mock-jwt-token-xyz', userRole);

    this.messageService.add({
      severity: 'success',
      summary: 'تم التحقق الآمن',
      detail: `مرحباً بك بنظام EduMS. تم تسجيل الدخول بصلاحية: ${userRole}`
    });

    // 2. التوجيه المباشر فوراً دون انتظار setTimeout أخرى تفقد الـ Context
    if (userRole === 'admin') {
      this.router.navigate(['/main-layout/admin/dashboard']);
    } else if (userRole === 'accountant') {
      this.router.navigate(['/main-layout/finance/dashboard']);
    } else if (userRole === 'teacher') {
      this.router.navigate(['/main-layout/teacher/dashboard']);
    } else {
      this.router.navigate(['/main-layout/student/dashboard']);
    }

  }, 1000); // وقت انتظار الاستجابة الإجمالي ثانية واحدة فقط
}
}
