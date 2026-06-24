import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { StepperModule } from 'primeng/stepper';
import { SelectModule } from 'primeng/select';
import { FloatLabelModule } from 'primeng/floatlabel';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { LookupService } from '../student-portal/services/lookups';
import { PortalRegistrationService } from '../student-portal/services/portal-registration';
import { GENDER_OPTIONS } from '../../app.constants';

@Component({
  selector: 'app-registration-portal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, InputTextModule, ButtonModule, StepperModule, SelectModule, FloatLabelModule, ToastModule],
  providers: [MessageService],
  templateUrl: './registration-portal.component.html',
  styleUrl: './registration-portal.component.scss',
})
export class RegistrationPortalComponent implements OnInit {
  private lookupService = inject(LookupService);
  private registrationService = inject(PortalRegistrationService);
  private fb = inject(FormBuilder);
  private msg = inject(MessageService);

  genders = GENDER_OPTIONS;
  nationalities = this.lookupService.nationalities;

  activeStep = 0;
  saving = signal(false);
  submitted = signal(false);

  form: FormGroup = this.fb.group({
    fullName: ['', Validators.required],
    birthDate: ['', Validators.required],
    gender: ['', Validators.required],
    nationality: ['', Validators.required],
    idNumber: ['', Validators.required],
    parentPhone: ['', Validators.required],
  });

  ngOnInit(): void {
    this.lookupService.getNationalities().subscribe();
  }

  onNext(): void {
    if (this.activeStep < 2) this.activeStep++;
  }

  onPrev(): void {
    if (this.activeStep > 0) this.activeStep--;
  }

  onSubmit(): void {
    if (this.form.invalid) { this.form.markAllAsTouched(); return; }
    this.saving.set(true);
    this.registrationService.submitRegistration(this.form.value).subscribe({
      next: () => {
        this.msg.add({ severity: 'success', summary: 'نجاح', detail: 'تم الحفظ بنجاح', life: 3000 });
        this.form.reset();
        this.activeStep = 0;
        this.submitted.set(true);
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
    this.activeStep = 0;
  }

  getGenderLabel(value: string): string {
    return this.genders.find(g => g.value === value)?.label || '—';
  }

  getNationalityLabel(value: string): string {
    return this.nationalities().find(n => n.value === value)?.label || '—';
  }
}
