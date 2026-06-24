import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { FieldsetModule } from 'primeng/fieldset';
import { CardModule } from 'primeng/card';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { FloatLabelModule } from 'primeng/floatlabel';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { LookupService } from '../services/lookups';
import { AcademicService } from '../services/academic';
import { GENDER_OPTIONS } from '../../../app.constants';

@Component({
  selector: 'app-student-data-form',
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule, InputTextModule, ButtonModule,
    FieldsetModule, CardModule, SelectModule, DatePickerModule, FloatLabelModule, ToastModule,
  ],
  providers: [MessageService],
  templateUrl: './student-data-form.component.html',
  styleUrl: './student-data-form.component.scss',
})
export class StudentDataFormComponent implements OnInit {
  private lookupService = inject(LookupService);
  private academicService = inject(AcademicService);
  private fb = inject(FormBuilder);
  private msg = inject(MessageService);

  genders = GENDER_OPTIONS;
  nationalities = this.lookupService.nationalities;
  grades = this.lookupService.grades;
  gradesLoading = this.lookupService.gradesLoading;
  departments = this.lookupService.departments;
  academicYears = this.lookupService.academicYears;
  bloodTypes = this.lookupService.bloodTypes;

  saving = signal(false);

  form: FormGroup = this.fb.group({
    firstName: ['', Validators.required],
    fatherName: ['', Validators.required],
    grandfatherName: [''],
    familyName: ['', Validators.required],
    idNumber: ['', Validators.required],
    birthDate: [null, Validators.required],
    gender: ['', Validators.required],
    nationality: ['', Validators.required],
    address: [''],
    phone: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    grade: ['', Validators.required],
    department: [''],
    academicYear: ['', Validators.required],
    bloodType: [''],
    allergies: [''],
    chronicDiseases: [''],
  });

  ngOnInit(): void {
    this.lookupService.getGrades().subscribe();
    this.lookupService.getDepartments().subscribe();
    this.lookupService.getAcademicYears().subscribe();
    this.lookupService.getBloodTypes().subscribe();
  }

  onSubmit(): void {
    if (this.form.invalid) { this.form.markAllAsTouched(); return; }
    this.saving.set(true);
    this.academicService.saveStudentData(this.form.value).subscribe({
      next: () => {
        this.msg.add({ severity: 'success', summary: 'نجاح', detail: 'تم الحفظ بنجاح', life: 3000 });
        this.form.reset();
        this.saving.set(false);
      },
      error: () => {
        this.msg.add({ severity: 'error', summary: 'خطأ', detail: 'حدث خطأ، يرجى المحاولة لاحقاً', life: 3000 });
        this.saving.set(false);
      },
    });
  }

  onCancel(): void {
    this.form.reset();
  }
}
