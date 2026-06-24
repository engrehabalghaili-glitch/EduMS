import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { RegistrationService } from './registration.service';
import { PortalStepComponent } from './steps/portal-step.component';
import { DataStepComponent } from './steps/data-step.component';
import { DocsStepComponent } from './steps/docs-step.component';

@Component({
  selector: 'app-student-registration-wizard',
  standalone: true,
  imports: [
    CommonModule, ButtonModule, ToastModule,
    PortalStepComponent, DataStepComponent, DocsStepComponent,
  ],
  templateUrl: './student-registration-wizard.component.html',
  styleUrl: './student-registration-wizard.component.scss',
  providers: [MessageService],
})
export class StudentRegistrationWizardComponent {
  activeStep = signal(0);
  submitted = signal(false);
  saving = signal(false);

  steps = [
    { num: 1, label: 'التسجيل', icon: 'pi-pencil', color: '#dbeafe', activeColor: '#3b82f6' },
    { num: 2, label: 'البيانات', icon: 'pi-file', color: '#dcfce7', activeColor: '#22c55e' },
    { num: 3, label: 'المستندات', icon: 'pi-folder-open', color: '#f3e8ff', activeColor: '#8b5cf6' },
  ];

  constructor(public svc: RegistrationService, private msg: MessageService) {}

  goToStep(step: number): void {
    if (step < this.activeStep()) {
      this.activeStep.set(step);
      return;
    }
    if (step === this.activeStep()) return;
    if (this.svc.validateStep(this.activeStep())) {
      this.activeStep.set(step);
    } else {
      this.msg.add({ severity: 'warn', summary: 'بيانات ناقصة', detail: 'أكمل الحقول المطلوبة أولاً', life: 4000 });
    }
  }

  onNext(): void {
    if (!this.svc.validateStep(this.activeStep())) {
      this.msg.add({ severity: 'warn', summary: 'بيانات ناقصة', detail: 'يرجى إكمال جميع الحقول المطلوبة', life: 4000 });
      return;
    }
    if (this.activeStep() < 2) this.activeStep.update(v => v + 1);
  }

  onPrev(): void {
    if (this.activeStep() > 0) this.activeStep.update(v => v - 1);
  }

  onSubmit(): void {
    if (!this.svc.validateStep(0) || !this.svc.validateStep(1)) {
      this.msg.add({ severity: 'warn', summary: 'بيانات ناقصة', detail: 'يرجى إكمال جميع الحقول المطلوبة قبل الإرسال', life: 4000 });
      return;
    }
    this.saving.set(true);
    this.svc.saveData().subscribe({
      next: () => {
        this.msg.add({ severity: 'success', summary: 'نجاح', detail: 'تم الحفظ بنجاح', life: 3000 });
        this.submitted.set(true);
        this.saving.set(false);
      },
      error: () => {
        this.msg.add({ severity: 'error', summary: 'خطأ', detail: 'حدث خطأ، يرجى المحاولة لاحقاً', life: 3000 });
        this.saving.set(false);
      },
    });
  }

  resetAll(): void {
    this.svc.resetAll();
    this.activeStep.set(0);
    this.submitted.set(false);
  }

  onCancel(): void {
    this.svc.resetAll();
    this.activeStep.set(0);
    this.submitted.set(false);
  }
}
