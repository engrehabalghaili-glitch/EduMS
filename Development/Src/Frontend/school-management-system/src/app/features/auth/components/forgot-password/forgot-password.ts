import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
    ToastModule
  ],
  providers: [MessageService],
  templateUrl: './forgot-password.html',
  styleUrls: ['./forgot-password.scss']
})
export class ForgotPasswordComponent {
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private messageService = inject(MessageService);

  // إدارة الحالات التشغيلية الفورية عبر الـ Signals الحديثة
  isLoading = signal<boolean>(false);
  isSuccess = signal<boolean>(false);

  // بناء نموذج التحقق الصارم من البريد الإلكتروني
  forgotForm: FormGroup = this.fb.group({
    email: ['', [Validators.required, Validators.email]]
  });

  /** معالجة طلب إرسال رمز استعادة الحساب */
  onSubmit() {
    if (this.forgotForm.invalid) {
      this.messageService.add({
        severity: 'error',
        summary: 'صيغة غير مدعومة',
        detail: 'برجاء إدخال بريد إلكتروني صحيح للتمكن من استعادة الحساب.'
      });
      return;
    }

    this.isLoading.set(true);

    // محاكاة إرسال الـ OTP والسجل الآمن المقتبس من ملفك الفني
    setTimeout(() => {
      this.isLoading.set(false);
      this.isSuccess.set(true);

      this.messageService.add({
        severity: 'success',
        summary: 'تم الإرسال بنجاح',
        detail: 'تحقق من صندوق البريد الخاص بك، سيتم توجيهك لصفحة التعيين...'
      });

      // التحويل التلقائي لصفحة إعادة التعيين (OTP) بعد 4 ثوانٍ كما هو محدد بملفك
      setTimeout(() => {
      this.router.navigate(['/auth/reset-password']);
    }, 4000);

    }, 1200);
  }
}
