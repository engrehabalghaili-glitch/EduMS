import { Injectable, inject, signal, computed } from '@angular/core';
import { RegistrationService } from '../services/registration.service';
import type { RegistrationStep, AssetFormData, ValidationErrors } from '../models/registration.types';

const DEFAULT_FORM: AssetFormData = {
  generalInfo: { name: '', acquisitionDate: '', assetType: '', subCategory: [], estimatedValue: null, notes: '' },
  locationTagging: { floor: '', room: '', location: '', barcode: '' },
  warrantyStatus: { purchaseDate: '', purchaseCost: null, invoiceNumber: '', warrantyEnd: '' },
};

@Injectable()
export class RegistrationFormStore {
  private readonly service = inject(RegistrationService);

  readonly activeStep = signal<RegistrationStep>('generalInfo');
  readonly formData = signal<AssetFormData>({ ...DEFAULT_FORM });
  readonly validationErrors = signal<ValidationErrors>({});
  readonly submitting = signal(false);

  readonly steps: RegistrationStep[] = ['generalInfo', 'locationTagging', 'warrantyStatus', 'verification'];

  readonly currentStepIndex = computed(() => this.steps.indexOf(this.activeStep()));
  readonly isLastStep = computed(() => this.currentStepIndex() === this.steps.length - 1);
  readonly isFirstStep = computed(() => this.currentStepIndex() === 0);

  readonly canProceed = computed(() => {
    const step = this.activeStep();
    const errors = this.validationErrors()[step];
    return !errors || Object.keys(errors).length === 0;
  });

  goToStep(step: RegistrationStep): void {
    this.activeStep.set(step);
  }

  nextStep(): void {
    const idx = this.currentStepIndex();
    if (idx < this.steps.length - 1) {
      this.validateCurrentStep();
      if (this.canProceed()) {
        this.activeStep.set(this.steps[idx + 1]);
      }
    }
  }

  prevStep(): void {
    const idx = this.currentStepIndex();
    if (idx > 0) {
      this.activeStep.set(this.steps[idx - 1]);
    }
  }

  updateGeneralInfo(data: Partial<AssetFormData['generalInfo']>): void {
    this.formData.update(f => ({ ...f, generalInfo: { ...f.generalInfo, ...data } }));
  }

  updateLocationTagging(data: Partial<AssetFormData['locationTagging']>): void {
    this.formData.update(f => ({ ...f, locationTagging: { ...f.locationTagging, ...data } }));
  }

  updateWarrantyStatus(data: Partial<AssetFormData['warrantyStatus']>): void {
    this.formData.update(f => ({ ...f, warrantyStatus: { ...f.warrantyStatus, ...data } }));
  }

  validateCurrentStep(): void {
    const step = this.activeStep();
    const data = this.formData();
    const errors: ValidationErrors = { ...this.validationErrors() };

    switch (step) {
      case 'generalInfo': {
        const g = data.generalInfo;
        const e: Record<string, string> = {};
        if (!g.name.trim()) e['name'] = 'اسم الأصل مطلوب';
        if (!g.acquisitionDate) e['acquisitionDate'] = 'تاريخ الحصول مطلوب';
        if (!g.assetType) e['assetType'] = 'نوع الأصل مطلوب';
        if (g.subCategory.length === 0) e['subCategory'] = 'اختر فئة واحدة على الأقل';
        if (g.estimatedValue === null || g.estimatedValue <= 0) e['estimatedValue'] = 'القيمة التقريبية مطلوبة';
        errors.generalInfo = e;
        break;
      }
      case 'locationTagging': {
        const l = data.locationTagging;
        const e: Record<string, string> = {};
        if (!l.location.trim()) e['location'] = 'الموقع مطلوب';
        if (!l.barcode.trim()) e['barcode'] = 'الباركود مطلوب';
        errors.locationTagging = e;
        break;
      }
      case 'warrantyStatus': {
        const w = data.warrantyStatus;
        const e: Record<string, string> = {};
        if (!w.purchaseDate) e['purchaseDate'] = 'تاريخ الشراء مطلوب';
        if (w.purchaseCost === null || w.purchaseCost <= 0) e['purchaseCost'] = 'تكلفة الشراء مطلوبة';
        if (!w.invoiceNumber.trim()) e['invoiceNumber'] = 'رقم الفاتورة مطلوب';
        errors.warrantyStatus = e;
        break;
      }
      case 'verification':
        errors.verification = {};
        break;
    }

    this.validationErrors.set(errors);
  }

  clearStepErrors(step: RegistrationStep): void {
    this.validationErrors.update(e => ({ ...e, [step]: undefined }));
  }

  reset(): void {
    this.activeStep.set('generalInfo');
    this.formData.set({ ...DEFAULT_FORM });
    this.validationErrors.set({});
    this.submitting.set(false);
  }

  async submit(): Promise<boolean> {
    this.validateCurrentStep();
    if (!this.canProceed()) return false;

    this.submitting.set(true);
    try {
      await this.service.createAsset(this.formData());
      this.reset();
      return true;
    } finally {
      this.submitting.set(false);
    }
  }
}
