import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-installment-form-dialog',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, InputTextModule, InputNumberModule, SelectModule, DatePickerModule, ButtonModule],
  template: `
    <div class="dialog-body">
      <form [formGroup]="form" (ngSubmit)="onSave()">
        <div class="field">
          <label for="studentName">اسم الطالب</label>
          <input id="studentName" pInputText formControlName="studentName" placeholder="أدخل اسم الطالب" class="input-field" />
        </div>

        <div class="field">
          <label for="grade">المرحلة الدراسية</label>
          <p-select
            id="grade"
            formControlName="grade"
            [options]="gradeOptions"
            optionLabel="label"
            optionValue="value"
            placeholder="اختر المرحلة"
            styleClass="select-field" />
        </div>

        <div class="field">
          <label for="amount">المبلغ (ر.ي)</label>
          <p-inputNumber id="amount" formControlName="amount" [min]="0" [max]="999999" placeholder="أدخل المبلغ" styleClass="input-field" />
        </div>

        <div class="field">
          <label for="dueDate">تاريخ الاستحقاق</label>
          <p-datepicker
            id="dueDate"
            formControlName="dueDate"
            styleClass="date-field"
            [showIcon]="true"
            iconDisplay="input"
            placeholder="اختر التاريخ" />
        </div>

        <div class="field">
          <label for="paymentMethod">وسيلة الدفع</label>
          <p-select
            id="paymentMethod"
            formControlName="paymentMethod"
            [options]="paymentOptions"
            optionLabel="label"
            optionValue="value"
            placeholder="اختر وسيلة الدفع"
            styleClass="select-field" />
        </div>

        <div class="field">
          <label for="notes">ملاحظات (اختياري)</label>
          <input id="notes" pInputText formControlName="notes" placeholder="ملاحظات إضافية" class="input-field" />
        </div>

        <div class="dialog-actions">
          <p-button label="إلغاء" severity="secondary" (onClick)="onCancel()" />
          <p-button label="حفظ" type="submit" [loading]="saving" [disabled]="form.invalid" styleClass="p-button-success" />
        </div>
      </form>
    </div>
  `,
  styles: [`
    .dialog-body { padding: 0.5rem 0; }
    .field { display: flex; flex-direction: column; gap: 0.35rem; margin-bottom: 1.25rem; }
    label { font-size: 0.8rem; font-weight: 700; color: #374151; }
    .input-field, .select-field, ::v-deep .select-field, .date-field, ::v-deep .date-field { width: 100%; }
    .dialog-actions { display: flex; justify-content: flex-end; gap: 0.75rem; margin-top: 1.5rem; }
  `]
})
export class InstallmentFormDialogComponent {
  private fb = inject(FormBuilder);
  private ref = inject(DynamicDialogRef);

  saving = false;

  gradeOptions = [
    { label: 'الأول الابتدائي', value: 'g1' }, { label: 'الثاني الابتدائي', value: 'g2' },
    { label: 'الثالث الابتدائي', value: 'g3' }, { label: 'الرابع الابتدائي', value: 'g4' },
    { label: 'الخامس الابتدائي', value: 'g5' }, { label: 'السادس الابتدائي', value: 'g6' },
    { label: 'الأول المتوسط', value: 'g7' }, { label: 'الثاني المتوسط', value: 'g8' },
    { label: 'الثالث المتوسط', value: 'g9' }, { label: 'الأول الثانوي', value: 'g10' },
    { label: 'الثاني الثانوي', value: 'g11' }, { label: 'الثالث الثانوي', value: 'g12' },
  ];

  paymentOptions = [
    { label: 'نقداً', value: 'cash' },
    { label: 'بطاقة ائتمان', value: 'credit' },
    { label: 'تحويل بنكي', value: 'transfer' },
    { label: 'شيك', value: 'check' },
  ];

  form: FormGroup = this.fb.group({
    studentName: ['', Validators.required],
    grade: ['', Validators.required],
    amount: [null, [Validators.required, Validators.min(1)]],
    dueDate: ['', Validators.required],
    paymentMethod: ['', Validators.required],
    notes: [''],
  });

  onSave(): void {
    if (this.form.invalid) return;
    this.saving = true;
    this.ref.close(this.form.value);
  }

  onCancel(): void {
    this.ref.close();
  }
}
