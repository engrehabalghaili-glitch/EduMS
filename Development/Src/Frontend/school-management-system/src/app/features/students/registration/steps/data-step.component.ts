import { Component, OnInit, inject, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { FieldsetModule } from 'primeng/fieldset';
import { FloatLabelModule } from 'primeng/floatlabel';
import { RegistrationService } from '../registration.service';
import { LookupService } from '../../../student-portal/services/lookups';
import { GENDER_OPTIONS } from '../../../../app.constants';

@Component({
  selector: 'app-data-step',
  standalone: true,
  imports: [CommonModule, FormsModule, InputTextModule, SelectModule, DatePickerModule, FieldsetModule, FloatLabelModule],
  template: `
    <div class="step-content p-fluid">
      <div class="step-title"><i class="pi pi-file"></i><span>البيانات التفصيلية للطالب</span></div>

      <p-fieldset legend="البيانات الشخصية" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.firstName" class="input-field" /><label>الاسم الأول</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.fatherName" class="input-field" /><label>اسم الأب</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.grandfatherName" class="input-field" /><label>اسم الجد</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.familyName" class="input-field" /><label>اسم العائلة</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.idNumber" class="input-field" /><label>رقم الهوية</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><p-datepicker [(ngModel)]="svc.formData().studentFull.birthDate" styleClass="date-field" [showIcon]="true" iconDisplay="input" placeholder="اختر" selectionMode="single" /><label>تاريخ الميلاد</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="genders" [(ngModel)]="svc.formData().studentFull.gender" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر" /><label>الجنس</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="nationalities()" [(ngModel)]="svc.formData().studentFull.nationality" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر" /><label>الجنسية</label></p-floatLabel></div>
        </div>
      </p-fieldset>

      <p-fieldset legend="بيانات التواصل" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.address" class="input-field" /><label>العنوان بالكامل</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.phone" class="input-field" /><label>رقم الهاتف</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.email" class="input-field" /><label>البريد الإلكتروني</label></p-floatLabel></div>
        </div>
      </p-fieldset>

      <p-fieldset legend="البيانات الأكاديمية" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on">@if (gradesLoading()) {<p-select [options]="[]" disabled styleClass="select-field" placeholder="جاري تحميل الصفوف..." />} @else {<p-select [options]="grades()" [(ngModel)]="svc.formData().studentFull.grade" (ngModelChange)="onGradeChange()" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر" />}<label>الصف الدراسي</label></p-floatLabel></div>
          @if (isSecondaryStage()) {
            <div class="col-12"><p-floatLabel variant="on"><p-select [options]="secondaryDepartments" [(ngModel)]="svc.formData().studentFull.department" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر التخصص" /><label>القسم / التخصص</label></p-floatLabel></div>
          }
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="academicYears()" [(ngModel)]="svc.formData().studentFull.academicYear" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر" /><label>السنة الدراسية</label></p-floatLabel></div>
        </div>
      </p-fieldset>

      <p-fieldset legend="البيانات الصحية" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="bloodTypes()" [(ngModel)]="svc.formData().studentFull.bloodType" optionLabel="label" optionValue="value" styleClass="select-field" placeholder="اختر" /><label>فصيلة الدم</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.allergies" class="input-field" /><label>الحساسية (إن وجد)</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentFull.chronicDiseases" class="input-field" /><label>الأمراض المزمنة</label></p-floatLabel></div>
        </div>
      </p-fieldset>
    </div>
  `,
  styles: [`
    .step-content { display: flex; flex-direction: column; gap: 0.75rem; }
    .step-title { display: flex; align-items: center; gap: 0.65rem; font-size: 1.05rem; font-weight: 800; color: #0f172a; }
    .step-title i { color: #06b6d4; font-size: 1.15rem; }
    ::v-deep .sub-fieldset { border-radius: 0.85rem !important; border: 1px solid #e2e8f0 !important; background: #fff !important; }
    ::v-deep .sub-fieldset .p-fieldset-legend { background: linear-gradient(135deg,#f0f9ff,#e0f2fe); border: none; border-radius: 0.85rem 0.85rem 0 0; padding: 0.7rem 1rem; font-weight: 700; font-size: 0.9rem; color: #0f172a; width: 100%; }
    ::v-deep .sub-fieldset .p-fieldset-content { padding: 0.5rem 0 0.25rem; }
    ::v-deep .sub-fieldset .grid { display: flex; flex-direction: column; gap: 0.6rem; }
    .input-field { width: 100%; padding: 0.65rem 0.8rem; border-radius: 0.65rem; border: 1.5px solid #e2e8f0; background: #fff; font-size: 0.88rem; transition: all 0.25s ease; color: #1f2937; }
    .input-field:focus { outline: none; border-color: #06b6d4; box-shadow: 0 0 0 3px rgba(6,182,212,0.1); }
    .select-field, ::v-deep .select-field .p-select { width: 100%; border-radius: 0.65rem !important; border: 1.5px solid #e2e8f0 !important; background: #fff !important; }
    .date-field, ::v-deep .date-field { width: 100%; border-radius: 0.65rem !important; }
    ::v-deep .p-floatlabel label { font-size: 0.78rem; font-weight: 600; color: #64748b; right: 0.75rem; left: auto; transform-origin: right top; background: #fff; padding: 0 4px; }
  `]
})
export class DataStepComponent implements OnInit {
  private lookupService = inject(LookupService);

  genders = GENDER_OPTIONS;
  gradesLoading = this.lookupService.gradesLoading;
  nationalities = this.lookupService.nationalities;
  grades = this.lookupService.grades;
  departments = this.lookupService.departments;
  academicYears = this.lookupService.academicYears;
  bloodTypes = this.lookupService.bloodTypes;
  secondaryDepartments = this.lookupService.secondaryDepartments;

  isSecondaryStage = computed(() => {
    const grade = this.svc.formData().studentFull.grade;
    return grade && ['g10', 'g11', 'g12'].includes(grade);
  });

  constructor(public svc: RegistrationService) {}

  ngOnInit(): void {
    this.lookupService.getNationalities().subscribe();
    this.lookupService.getGrades().subscribe();
    this.lookupService.getDepartments().subscribe();
    this.lookupService.getAcademicYears().subscribe();
    this.lookupService.getBloodTypes().subscribe();
  }

  onGradeChange(): void {
    if (!this.isSecondaryStage()) {
      this.svc.updateStudentFull({ department: '' });
    }
  }
}
