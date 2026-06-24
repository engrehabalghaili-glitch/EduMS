import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-task-form-dialog',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, InputTextModule, SelectModule, DatePickerModule, ButtonModule],
  template: `
    <div class="dialog-body">
      <form [formGroup]="form" (ngSubmit)="onSave()">
        <div class="field">
          <label for="title">عنوان المهمة</label>
          <input id="title" pInputText formControlName="title" placeholder="أدخل عنوان المهمة" class="input-field" />
        </div>

        <div class="field">
          <label for="priority">الأولوية</label>
          <p-select
            id="priority"
            formControlName="priority"
            [options]="priorityOptions"
            optionLabel="label"
            optionValue="value"
            placeholder="اختر الأولوية"
            styleClass="select-field" />
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

        <div class="dialog-actions">
          <p-button label="إلغاء" severity="secondary" (onClick)="onCancel()" styleClass="btn-cancel" />
          <p-button
            label="حفظ"
            type="submit"
            [loading]="saving"
            [disabled]="form.invalid"
            styleClass="btn-save" />
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
    .btn-save { background: linear-gradient(135deg, #10B981, #059669); border: none; }
    .btn-cancel { --p-button-secondary-background: #f1f5f9; --p-button-secondary-color: #475569; }
  `]
})
export class TaskFormDialogComponent {
  private fb = inject(FormBuilder);
  private ref = inject(DynamicDialogRef);

  saving = false;

  priorityOptions = [
    { label: 'عالية', value: 'high' },
    { label: 'متوسطة', value: 'medium' },
    { label: 'منخفضة', value: 'low' },
  ];

  form: FormGroup = this.fb.group({
    title: ['', Validators.required],
    priority: ['', Validators.required],
    dueDate: ['', Validators.required],
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
