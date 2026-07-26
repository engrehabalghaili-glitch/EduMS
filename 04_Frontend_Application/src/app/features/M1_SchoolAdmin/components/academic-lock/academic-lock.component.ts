import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AcademicLockService, ApplyAcademicLockCommand } from '../../services/academic-lock.service';
import { ProblemDetails } from '../../../../core/models/problem-details.model';

@Component({
  selector: 'app-academic-lock',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="lock-management-card">
      <h3>إدارة القفل الأكاديمي الانتقائي</h3>

      <div *ngIf="successMessage()" class="alert alert-success">
        {{ successMessage() }}
      </div>

      <div *ngIf="errorMessage()" class="alert alert-danger">
        <strong>{{ errorTitle() }}</strong>: {{ errorMessage() }}
        <ul *ngIf="validationErrors().length > 0">
          <li *ngFor="let err of validationErrors()">{{ err }}</li>
        </ul>
      </div>

      <div class="check-section">
        <h4>فحص حالة القفل بتاريخ معين</h4>
        <div class="inline-form">
          <input type="number" #schoolIdCheck placeholder="رقم المدرسة" class="form-control" />
          <input type="date" #targetDateCheck class="form-control" />
          <button type="button" (click)="onCheckLock(schoolIdCheck.value, targetDateCheck.value)" class="btn btn-secondary">
            {{ isChecking() ? 'جاري الفحص...' : 'فحص القفل' }}
          </button>
        </div>
        <div *ngIf="checkResult() !== null" class="status-badge" [ngClass]="checkResult() ? 'locked' : 'unlocked'">
          {{ checkResult() ? 'النظام مقفل أكاديمياً في هذا التاريخ' : 'النظام متاح للعمليات في هذا التاريخ' }}
        </div>
      </div>

      <hr />

      <h4>تطبيق فترة قفل جديدة</h4>
      <form [formGroup]="lockForm" (ngSubmit)="onApplyLock()">
        <div class="form-group">
          <label>رقم المدرسة التعريفي *</label>
          <input type="number" formControlName="schoolId" class="form-control" />
        </div>

        <div class="form-group">
          <label>نوع القفل *</label>
          <select formControlName="lockType" class="form-control">
            <option [ngValue]="1">قفل الدرجات والاختبارات</option>
            <option [ngValue]="2">قفل الحضور والغياب</option>
            <option [ngValue]="3">قفل أكاديمي شامل</option>
          </select>
        </div>

        <div class="form-group">
          <label>تاريخ بداية القفل *</label>
          <input type="date" formControlName="startDate" class="form-control" />
        </div>

        <div class="form-group">
          <label>تاريخ نهاية القفل *</label>
          <input type="date" formControlName="endDate" class="form-control" />
        </div>

        <div class="form-group">
          <label>السبب / ملاحظات</label>
          <input type="text" formControlName="reason" class="form-control" />
        </div>

        <button type="submit" [disabled]="lockForm.invalid || isApplying()" class="btn btn-primary">
          {{ isApplying() ? 'جاري تطبيق القفل...' : 'تطبيق القفل' }}
        </button>
      </form>
    </div>
  `,
  styles: [`
    .lock-management-card {
      background: #ffffff;
      padding: 1.5rem;
      border-radius: 8px;
      box-shadow: 0 2px 8px rgba(0,0,0,0.05);
      max-width: 650px;
      margin: 1rem auto;
    }
    .form-group { margin-bottom: 1rem; }
    .inline-form { display: flex; gap: 0.5rem; margin-bottom: 1rem; }
    .form-control { width: 100%; padding: 0.5rem; border: 1px solid #cbd5e1; border-radius: 4px; box-sizing: border-box; }
    .btn { padding: 0.6rem 1.2rem; border: none; border-radius: 4px; cursor: pointer; font-weight: 600; }
    .btn-primary { background-color: var(--primary-color, #1a56db); color: #fff; }
    .btn-secondary { background-color: var(--secondary-color, #046c4e); color: #fff; white-space: nowrap; }
    .btn:disabled { background-color: #94a3b8; cursor: not-allowed; }
    .alert { padding: 0.75rem; border-radius: 4px; margin-bottom: 1rem; }
    .alert-success { background-color: #d1fae5; color: #065f46; border: 1px solid #10b981; }
    .alert-danger { background-color: #fee2e2; color: #991b1b; border: 1px solid #ef4444; }
    .status-badge { padding: 0.5rem; border-radius: 4px; font-weight: bold; text-align: center; margin-top: 0.5rem; }
    .locked { background-color: #fee2e2; color: #991b1b; }
    .unlocked { background-color: #d1fae5; color: #065f46; }
    hr { margin: 1.5rem 0; border: 0; border-top: 1px solid #e2e8f0; }
  `]
})
export class AcademicLockComponent {
  private fb = inject(FormBuilder);
  private lockService = inject(AcademicLockService);

  isApplying = signal<boolean>(false);
  isChecking = signal<boolean>(false);
  checkResult = signal<boolean | null>(null);
  successMessage = signal<string | null>(null);
  errorTitle = signal<string | null>(null);
  errorMessage = signal<string | null>(null);
  validationErrors = signal<string[]>([]);

  lockForm = this.fb.group({
    schoolId: [1, [Validators.required, Validators.min(1)]],
    lockType: [1, Validators.required],
    startDate: ['', Validators.required],
    endDate: ['', Validators.required],
    reason: ['']
  });

  onCheckLock(schoolIdStr: string, targetDate: string): void {
    const schoolId = Number(schoolIdStr);
    if (!schoolId || !targetDate) return;

    this.isChecking.set(true);
    this.checkResult.set(null);

    this.lockService.checkLock(schoolId, targetDate).subscribe({
      next: (isLocked: boolean) => {
        this.isChecking.set(false);
        this.checkResult.set(isLocked);
      },
      error: (err: ProblemDetails) => {
        this.isChecking.set(false);
        this.handleError(err);
      }
    });
  }

  onApplyLock(): void {
    if (this.lockForm.invalid) return;

    this.isApplying.set(true);
    this.successMessage.set(null);
    this.errorTitle.set(null);
    this.errorMessage.set(null);
    this.validationErrors.set([]);

    const command: ApplyAcademicLockCommand = {
      schoolId: Number(this.lockForm.value.schoolId),
      lockType: Number(this.lockForm.value.lockType),
      startDate: this.lockForm.value.startDate!,
      endDate: this.lockForm.value.endDate!,
      reason: this.lockForm.value.reason || undefined
    };

    this.lockService.applyLock(command).subscribe({
      next: (lockId: number) => {
        this.isApplying.set(false);
        this.successMessage.set(`تم تطبيق القفل الأكاديمي بنجاح تحت الرقم: ${lockId}`);
        this.lockForm.reset({ schoolId: 1, lockType: 1 });
      },
      error: (err: ProblemDetails) => {
        this.isApplying.set(false);
        this.handleError(err);
      }
    });
  }

  private handleError(err: ProblemDetails): void {
    this.errorTitle.set(err.title || 'خطأ في عملية القفل الأكاديمي');
    this.errorMessage.set(err.detail || 'حدث خطأ غير متوقع أثناء معالجة الطلب');

    if (err.errors) {
      const errorsList: string[] = [];
      Object.entries(err.errors).forEach(([field, msgs]) => {
        msgs.forEach(m => errorsList.push(`${field}: ${m}`));
      });
      this.validationErrors.set(errorsList);
    }
  }
}
