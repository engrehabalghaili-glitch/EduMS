import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-page-container',
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <div class="page-container">
      <router-outlet />
    </div>
  `,
  styles: [`
    .page-container {
      direction: rtl;
      padding: 1.5rem;
      min-height: calc(100vh - var(--topbar-height, 64px) - var(--footer-height, 50px));
      width: 100%;
      box-sizing: border-box;
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageContainerComponent {}
