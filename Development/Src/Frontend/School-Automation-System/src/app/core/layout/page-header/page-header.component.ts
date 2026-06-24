import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import type { PageAction } from '../main-layout/main-layout.types';

@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [ButtonModule, BreadcrumbComponent],
  template: `
    <div class="page-header">
      <div class="page-header-top">
        <div class="page-header-text">
          <h1 class="page-title">{{ title() }}</h1>
          @if (description(); as desc) {
            <p class="page-description">{{ desc }}</p>
          }
        </div>
        @if (actions().length > 0) {
          <div class="page-header-actions">
            @for (action of actions(); track action.label) {
            <p-button
              [label]="action.label"
              [icon]="action.icon"
              [severity]="action.severity || 'primary'"
              [outlined]="action.outlined || false"
              [disabled]="action.disabled || false"
              (onClick)="action.command()"
              styleClass="page-action-btn">
            </p-button>
          }
          </div>
        }
      </div>
      @if (showBreadcrumb()) {
        <app-breadcrumb />
      }
    </div>
  `,
  styles: [`
    .page-header {
      direction: rtl;
      margin-bottom: 1.5rem;
    }
    .page-header-top {
      display: flex;
      justify-content: space-between;
      align-items: flex-start;
      gap: 1rem;
      flex-wrap: wrap;
    }
    .page-header-text {
      flex: 1;
      min-width: 200px;
    }
    .page-title {
      margin: 0;
      font-size: 1.5rem;
      font-weight: 700;
      color: var(--text-color);
    }
    .page-description {
      margin: 0.25rem 0 0;
      color: var(--text-color-secondary);
      font-size: var(--font-size-sm, 0.875rem);
    }
    .page-header-actions {
      display: flex;
      gap: 0.5rem;
      flex-wrap: wrap;
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageHeaderComponent {
  readonly title = input.required<string>();
  readonly description = input<string>();
  readonly actions = input<PageAction[]>([]);
  readonly showBreadcrumb = input(true);
}
