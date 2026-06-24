import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AppCard } from '../../../../../shared/components/card/card.component';
import { AppButton } from '../../../../../shared/components/button/button.component';
import { RegistrationFormStore } from '../../store/registration-form.store';
import { CATEGORY_OPTIONS } from '../../models/registration.constants';
import type { RegistrationStep } from '../../models/registration.types';
import { StepGeneralInfoComponent } from '../step-general-info/step-general-info.component';
import { StepLocationTaggingComponent } from '../step-location-tagging/step-location-tagging.component';
import { StepWarrantyStatusComponent } from '../step-warranty-status/step-warranty-status.component';
import { StepVerificationComponent } from '../step-verification/step-verification.component';

@Component({
  selector: 'app-asset-stepper',
  standalone: true,
  imports: [
    AppCard, AppButton,
    StepGeneralInfoComponent, StepLocationTaggingComponent,
    StepWarrantyStatusComponent, StepVerificationComponent,
  ],
  templateUrl: './asset-stepper.html',
  styleUrl: './asset-stepper.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetStepperComponent {
  readonly store = inject(RegistrationFormStore);
  private readonly router = inject(Router);

  readonly steps: { key: RegistrationStep; label: string; icon: string }[] = [
    { key: 'generalInfo', label: 'المعلومات العامة', icon: 'pi pi-info-circle' },
    { key: 'locationTagging', label: 'الموقع والباركود', icon: 'pi pi-map-marker' },
    { key: 'warrantyStatus', label: 'الضمان والشراء', icon: 'pi pi-shield' },
    { key: 'verification', label: 'مراجعة وتأكيد', icon: 'pi pi-check-circle' },
  ];

  readonly categoryOptions = CATEGORY_OPTIONS.filter(o => o.value !== '');

  async onSubmit(): Promise<void> {
    const success = await this.store.submit();
    if (success) {
      await this.router.navigate(['/assets-management/registration/list']);
    }
  }

  onCancel(): void {
    this.store.reset();
    void this.router.navigate(['/assets-management/registration/list']);
  }
}
