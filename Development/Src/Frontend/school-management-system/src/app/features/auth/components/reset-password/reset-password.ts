import { Component, inject, signal, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormArray } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-reset-password',
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
  templateUrl: './reset-password.html',
  styleUrls: ['./reset-password.scss']
})
export class ResetPasswordComponent {
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private messageService = inject(MessageService);

  @ViewChildren('otpInput') otpInputs!: QueryList<ElementRef>;

  // إدارة الحالات التشغيلية الفورية عبر الـ Signals
  isLoading = signal<boolean>(false);
  passwordStrength = signal<number>(0);

  // المصفوفات الفنية للألوان والوصف المقتبسة مباشرة من كودك الفني
  strengthLabels = ['لم يتم الإدخال', 'ضعيف', 'متوسط', 'جيد', 'قوي جداً'];
  strengthColors = ['#E2E8F0', '#DC2626', '#F59E0B', '#3B82F6', '#10B981'];

  // بناء نموذج التحقق المتوافق هندسياً مع ملفك
  resetForm: FormGroup = this.fb.group({
    otp: this.fb.array(Array(6).fill('').map(() => ['', [Validators.required, Validators.pattern(/^[0-9]$/)]])),
    newPassword: ['', [Validators.required, Validators.minLength(8)]],
    confirmPassword: ['', [Validators.required]]
  }, { validators: this.passwordMatchValidator });

  get otpArray() {
    return this.resetForm.get('otp') as FormArray;
  }

  /** مجهر قياس قوة كلمة المرور المعتمد على خوارزميتك المرفقة */
  checkStrength() {
    const pwd = this.resetForm.get('newPassword')?.value || '';
    let strength = 0;

    if (pwd.length >= 8) strength++;
    if (/[A-Z]/.test(pwd)) strength++;
    if (/[0-9]/.test(pwd)) strength++;
    if (/[^A-Za-z0-9]/.test(pwd)) strength++;

    this.passwordStrength.set(pwd.length === 0 ? 0 : strength === 0 ? 1 : strength);
  }

  /** التحقق من تطابق كلمتي المرور */
  passwordMatchValidator(g: FormGroup) {
    const pass = g.get('newPassword')?.value;
    const confirm = g.get('confirmPassword')?.value;
    return pass === confirm ? null : { mismatch: true };
  }

  /** التحكم التلقائي المتجاوب في حركة مؤشر حقول الـ OTP عند الكتابة */
  onOtpInput(event: any, index: number) {
    const input = event.target;
    if (input.value && index < 5) {
      this.otpInputs.toArray()[index + 1].nativeElement.focus();
    }
  }

  /** العودة للحقل السابق عند ضغط زر Backspace والمربع فارغ */
  onOtpKeyDown(event: KeyboardEvent, index: number) {
    const input = event.target as HTMLInputElement;
    if (event.key === 'Backspace' && !input.value && index > 0) {
      this.otpInputs.toArray()[index - 1].nativeElement.focus();
    }
  }

  /** تنفيذ حفظ وتحديث البيانات والتحويل التلقائي بذكاء */
  onSubmit() {
    if (this.resetForm.invalid || this.passwordStrength() < 2) {
      this.messageService.add({
        severity: 'error',
        summary: 'فشل التأكيد',
        detail: 'يرجى استكمال حقول الرموز واختيار كلمة مرور مقبولة ومتطابقة.'
      });
      return;
    }

    this.isLoading.set(true);

    // محاكاة زمنية متطابقة مع آلية المعالجة في ملفك الأصلي
    setTimeout(() => {
      this.isLoading.set(false);
      this.messageService.add({
        severity: 'success',
        summary: 'تم التحديث بنجاح',
        detail: 'تمت إعادة تعيين كلمة المرور، جاري تحويلك لصفحة الدخول...'
      });

      setTimeout(() => {
        this.router.navigate(['/auth/login'], { queryParams: { reset: 'success' } });
      }, 1500);

    }, 1500);
  }
}
