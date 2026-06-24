import { Component, input, ChangeDetectionStrategy } from '@angular/core';
import { ProgressSpinner } from 'primeng/progressspinner';

@Component({
  selector: 'app-loading-overlay',
  imports: [ProgressSpinner],
  template: `
    @if (visible()) {
      <div class="loading-overlay">
        <p-progressSpinner [style]="{width: '50px', height: '50px'}" strokeWidth="4" />
        @if (message()) {
          <p style="color: var(--gray-600); margin-top: 1rem;">{{ message() }}</p>
        }
      </div>
    }
  `,
  styleUrl: './loading-overlay.component.scss',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoadingOverlayComponent {
  readonly visible = input(false);
  readonly message = input<string>();
}
