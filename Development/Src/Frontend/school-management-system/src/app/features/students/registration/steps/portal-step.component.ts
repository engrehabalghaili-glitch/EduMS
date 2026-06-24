import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { FieldsetModule } from 'primeng/fieldset';
import { FloatLabelModule } from 'primeng/floatlabel';
import { RegistrationService } from '../registration.service';
import { LookupService } from '../../../student-portal/services/lookups';
import { GENDER_OPTIONS } from '../../../../app.constants';

@Component({
  selector: 'app-portal-step',
  standalone: true,
  imports: [CommonModule, FormsModule, InputTextModule, SelectModule, FieldsetModule, FloatLabelModule],
  template: `
    <div class="step-content p-fluid">
      <div class="step-title"><i class="pi pi-user"></i><span>بيانات ولي الأمر والطالب</span></div>

      <p-fieldset legend="بيانات ولي الأمر" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.firstName" class="input-field" /><label>اسم ولي الأمر الأول</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.fatherName" class="input-field" /><label>اسم الأب</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.grandfatherName" class="input-field" /><label>اسم الجد</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.familyName" class="input-field" /><label>اسم العائلة</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.idNumber" class="input-field" /><label>رقم الهوية / الإقامة</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.phone" class="input-field" placeholder="05xxxxxxxx" /><label>رقم الجوال</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().parent.email" class="input-field" placeholder="example@email.com" /><label>البريد الإلكتروني</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="relations" [(ngModel)]="svc.formData().parent.relation" optionLabel="label" optionValue="value" placeholder="اختر" styleClass="select-field" /><label>صلة القرابة</label></p-floatLabel></div>
        </div>
      </p-fieldset>

      <p-fieldset legend="بيانات الطالب الأولية" styleClass="sub-fieldset">
        <div class="grid">
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentBasic.fullName" class="input-field" /><label>الاسم الكامل للطالب</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><input pInputText [(ngModel)]="svc.formData().studentBasic.birthDate" class="input-field" placeholder="هـ ١٤٣٥/٥/١٥" /><label>تاريخ الميلاد</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on"><p-select [options]="genders" [(ngModel)]="svc.formData().studentBasic.gender" optionLabel="label" optionValue="value" placeholder="اختر" styleClass="select-field" /><label>الجنس</label></p-floatLabel></div>
          <div class="col-12"><p-floatLabel variant="on">@if (gradesLoading()) {<p-select [options]="[]" disabled styleClass="select-field" placeholder="جاري تحميل الصفوف..." />} @else {<p-select [options]="grades()" [(ngModel)]="svc.formData().studentBasic.grade" optionLabel="label" optionValue="value" placeholder="اختر" styleClass="select-field" />}<label>الصف الدراسي المطلوب</label></p-floatLabel></div>
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
    ::v-deep .p-floatlabel label { font-size: 0.78rem; font-weight: 600; color: #64748b; right: 0.75rem; left: auto; transform-origin: right top; background: #fff; padding: 0 4px; }
  `]
})
export class PortalStepComponent implements OnInit {
  private lookupService = inject(LookupService);

  genders = GENDER_OPTIONS;
  gradesLoading = this.lookupService.gradesLoading;
  grades = this.lookupService.grades;

  relations = [
    { label: 'أب', value: 'father' }, { label: 'أم', value: 'mother' }, { label: 'ولي أمر قانوني', value: 'guardian' },
  ];

  constructor(public svc: RegistrationService) {}

  ngOnInit(): void {
    this.lookupService.getGrades().subscribe();
  }
}
