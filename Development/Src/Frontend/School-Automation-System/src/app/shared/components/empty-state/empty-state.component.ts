import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { ButtonDirective } from 'primeng/button';
import type { EmptyStateConfig } from '../../interfaces/shared.types';

@Component({
  selector: 'app-empty-state',
  imports: [ButtonDirective],
  template: `
    <div class="flex flex-column align-items-center gap-3 p-5">
      <span [class]="config().icon || 'pi pi-inbox'" style="font-size: 3rem; color: var(--gray-400);"></span>
      <h3 style="color: var(--gray-600); margin: 0; font-size: var(--font-size-lg);">{{ config().title }}</h3>
      @if (config().message) {
        <p style="color: var(--gray-400); margin: 0; font-size: var(--font-size-sm); text-align: center;">
          {{ config().message }}
        </p>
      }
      @if (config().actionLabel && config().action) {
        <button
          pButton
          [label]="config().actionLabel!"
          [icon]="config().actionIcon || 'pi pi-plus'"
          (click)="action.emit()"
        ></button>
      }
    </div>
  `,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmptyStateComponent {
  readonly config = input.required<EmptyStateConfig>();
  readonly action = output<void>();
}
