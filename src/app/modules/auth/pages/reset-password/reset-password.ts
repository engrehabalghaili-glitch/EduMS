import { ChangeDetectionStrategy, Component, inject, input, output } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators, AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { RouterLink } from '@angular/router';

function matchingPasswords(): ValidatorFn {
  return (group: AbstractControl): ValidationErrors | null => {
    const password = group.get('password');
    const confirmPassword = group.get('confirmPassword');
    if (!password || !confirmPassword) return null;
    return password.value === confirmPassword.value ? null : { mismatch: true };
  };
}

@Component({
  selector: 'app-reset-password',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './reset-password.html',
  styleUrl: './reset-password.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResetPassword {
  readonly loading = input<boolean>(false);
  readonly resetPasswordSubmit = output<string>();

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({
    password: ['', [Validators.required, Validators.minLength(8)]],
    confirmPassword: ['', [Validators.required]]
  }, { validators: matchingPasswords() });

  onSubmit(): void {
    if (this.form.invalid) return;
    this.resetPasswordSubmit.emit(this.form.controls.password.value);
  }
}
