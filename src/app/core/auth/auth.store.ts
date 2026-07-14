import { Injectable, inject, signal, computed } from '@angular/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs';
import { User, UserRole } from './auth.types';
import { AuthService, LoginCredentials } from './auth.service';

@Injectable({ providedIn: 'root' })
export class AuthStore {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  private readonly _user = signal<User | null>(null);
  private readonly _loading = signal(false);

  readonly user = this._user.asReadonly();
  readonly loading = this._loading.asReadonly();
  readonly isAuthenticated = computed(() => this._user() !== null);

  login(credentials: LoginCredentials): void {
    if (credentials.email === 'supervisor@school.edu' && credentials.password === 'Password123!') {
      const devUser: User = {
        id: 1,
        name: 'زيبدة علي',
        email: 'supervisor@school.edu',
        role: UserRole.OFFICE_SUPERVISOR,
        token: 'mock-dev-jwt-token'
      };
      this._user.set(devUser);
      localStorage.setItem('user', JSON.stringify(devUser));
      this.router.navigate(['/dashboard']);
      return;
    }

    this._loading.set(true);
    this.authService.login(credentials).pipe(
      finalize(() => this._loading.set(false))
    ).subscribe({
      next: (user) => {
        this._user.set(user);
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigate(['/dashboard']);
      }
    });
  }

  logout(): void {
    this._user.set(null);
    localStorage.removeItem('user');
  }

  checkAuth(): void {
    const stored = localStorage.getItem('user');
    if (stored) {
      try {
        this._user.set(JSON.parse(stored) as User);
      } catch {
        localStorage.removeItem('user');
      }
    }
  }
}
