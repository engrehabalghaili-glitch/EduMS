import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PersonService, CreatePersonCommand } from '../../services/person.service';
import { ProblemDetails } from '../../../../core/models/problem-details.model';

@Component({
  selector: 'app-create-person',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="person-registration-card">
      <h3>تسجيل فرد جديد (طالب / ولي أمر)</h3>
      
      <div *ngIf="successMessage()" class="alert alert-success">
        {{ successMessage() }}
      </div>

      <div *ngIf="errorMessage()" class="alert alert-danger">
        <strong>{{ errorTitle() }}</strong>: {{ errorMessage() }}
        <ul *ngIf="validationErrors().length > 0">
          <li *ngFor="let err of validationErrors()">{{ err }}</li>
        </ul>
      </div>

      <form [formGroup]="personForm" (ngSubmit)="onSubmit()">
        <div class="form-group">
          <label>الاسم الكامل (عربي) *</label>
          <input type="text" formControlName="fullNameAr" class="form-control" />
        </div>

        <div class="form-group">
          <label>الاسم الكامل (إنجليزي)</label>
          <input type="text" formControlName="fullNameEn" class="form-control" />
        </div>

        <div class="form-group">
          <label>رقم الهوية الوطنية / الإقامة *</label>
          <input type="text" formControlName="nationalId" class="form-control" />
        </div>

        <div class="form-group">
          <label>الجنس *</label>
          <select formControlName="gender" class="form-control">
            <option [ngValue]="1">ذكر</option>
            <option [ngValue]="2">أنثى</option>
          </select>
        </div>

        <div class="form-group">
          <label>رقم التواصل</label>
          <input type="text" formControlName="contactNumber" class="form-control" />
        </div>

        <div class="form-group">
          <label>المعلومات الطبية</label>
          <textarea formControlName="medicalInfo" class="form-control"></textarea>
        </div>

        <button type="submit" [disabled]="personForm.invalid || isLoading()" class="btn btn-primary">
          {{ isLoading() ? 'جاري الحفظ...' : 'تسجيل الفرد' }}
        </button>
      </form>
    </div>
  `,
  styles: [`
    .person-registration-card {
      background: #ffffff;
      padding: 1.5rem;
      border-radius: 8px;
      box-shadow: 0 2px 8px rgba(0,0,0,0.05);
      max-width: 600px;
      margin: 1rem auto;
    }
    .form-group { margin-bottom: 1rem; }
    .form-control { width: 100%; padding: 0.5rem; border: 1px solid #cbd5e1; border-radius: 4px; box-sizing: border-box; }
    .btn { padding: 0.6rem 1.2rem; border: none; border-radius: 4px; cursor: pointer; font-weight: 600; }
    .btn-primary { background-color: var(--primary-color, #1a56db); color: #fff; }
    .btn-primary:disabled { background-color: #94a3b8; cursor: not-allowed; }
    .alert { padding: 0.75rem; border-radius: 4px; margin-bottom: 1rem; }
    .alert-success { background-color: #d1fae5; color: #065f46; border: 1px solid #10b981; }
    .alert-danger { background-color: #fee2e2; color: #991b1b; border: 1px solid #ef4444; }
  `]
})
export class CreatePersonComponent {
  private fb = inject(FormBuilder);
  private personService = inject(PersonService);

  isLoading = signal<boolean>(false);
  successMessage = signal<string | null>(null);
  errorTitle = signal<string | null>(null);
  errorMessage = signal<string | null>(null);
  validationErrors = signal<string[]>([]);

  personForm = this.fb.group({
    fullNameAr: ['', [Validators.required, Validators.minLength(3)]],
    fullNameEn: [''],
    nationalId: ['', [Validators.required, Validators.minLength(5)]],
    gender: [1, Validators.required],
    contactNumber: [''],
    medicalInfo: ['']
  });

  onSubmit(): void {
    if (this.personForm.invalid) return;

    this.isLoading.set(true);
    this.successMessage.set(null);
    this.errorTitle.set(null);
    this.errorMessage.set(null);
    this.validationErrors.set([]);

    const command: CreatePersonCommand = {
      fullNameAr: this.personForm.value.fullNameAr!,
      fullNameEn: this.personForm.value.fullNameEn || undefined,
      nationalId: this.personForm.value.nationalId!,
      gender: Number(this.personForm.value.gender),
      contactNumber: this.personForm.value.contactNumber || undefined,
      medicalInfo: this.personForm.value.medicalInfo || undefined
    };

    this.personService.createPerson(command).subscribe({
      next: (id: number) => {
        this.isLoading.set(false);
        this.successMessage.set(`تم تسجيل الفرد بنجاح تحت الرقم التعريفي: ${id}`);
        this.personForm.reset({ gender: 1 });
      },
      error: (err: ProblemDetails) => {
        this.isLoading.set(false);
        this.errorTitle.set(err.title || 'خطأ في عملية التسجيل');
        this.errorMessage.set(err.detail || 'حدث خطأ غير متوقع أثناء معالجة الطلب');

        if (err.errors) {
          const errorsList: string[] = [];
          Object.entries(err.errors).forEach(([field, msgs]) => {
            msgs.forEach(m => errorsList.push(`${field}: ${m}`));
          });
          this.validationErrors.set(errorsList);
        }
      }
    });
  }
}
