import { ChangeDetectionStrategy, Component, inject, input, output } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { type LoginCredentials } from '../../../../core/auth';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Login {
  readonly loading = input<boolean>(false);
  readonly loginSubmit = output<LoginCredentials>();

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({
    email: ['supervisor@school.edu', [Validators.required, Validators.email]],
    password: ['Password123!', [Validators.required]]
  });

  onSubmit(): void {
    if (this.form.invalid) return;
    this.loginSubmit.emit(this.form.getRawValue());
  }
}
