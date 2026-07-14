import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthStore } from '../../../../core/auth';

@Component({
  selector: 'app-auth-layout',
  imports: [RouterOutlet],
  templateUrl: './auth-layout.html',
  styleUrl: './auth-layout.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AuthLayout implements OnInit {
  private readonly authStore = inject(AuthStore);

  ngOnInit(): void {
    this.authStore.checkAuth();
  }
}
