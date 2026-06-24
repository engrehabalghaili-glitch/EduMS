import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [RouterLink],
  template: `
    <footer class="layout-footer">
      <div class="footer-content">
        <span class="footer-copyright">
          &copy; {{ year }} {{ systemName }}. جميع الحقوق محفوظة.
        </span>
        <div class="footer-links">
          <a routerLink="/about" class="footer-link">عن النظام</a>
          <a routerLink="/privacy" class="footer-link">سياسة الخصوصية</a>
          <a routerLink="/contact" class="footer-link">اتصل بنا</a>
        </div>
      </div>
    </footer>
  `,
  styles: [`
    .layout-footer {
      direction: rtl;
      border-top: 1px solid var(--surface-border);
      background: var(--surface-card);
      padding: 0.75rem 1.5rem;
    }
    .footer-content {
      display: flex;
      justify-content: space-between;
      align-items: center;
      flex-wrap: wrap;
      gap: 0.5rem;
    }
    .footer-copyright {
      color: var(--text-color-secondary);
      font-size: var(--font-size-sm, 0.875rem);
    }
    .footer-links {
      display: flex;
      gap: 1rem;
    }
    .footer-link {
      color: var(--primary-color);
      font-size: var(--font-size-sm, 0.875rem);
      text-decoration: none;
      transition: opacity 0.2s;
    }
    .footer-link:hover {
      opacity: 0.8;
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FooterComponent {
  readonly year = new Date().getFullYear();
  readonly systemName = 'نظام إدارة المدارس';
}
