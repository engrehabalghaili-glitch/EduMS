import { Component, OnInit, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  protected readonly title = signal('edums-frontend-DDD-System');
  private authService = inject(AuthService);

  ngOnInit() {
    // تم إيقاف الدخول التلقائي للانتقال للربط الحقيقي مع قاعدة البيانات
    // if (!this.authService.isLoggedIn()) {
    //   this.authService.autoLoginForDevelopment();
    // }
  }
}
