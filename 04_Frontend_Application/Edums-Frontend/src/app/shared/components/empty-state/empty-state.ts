import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-empty-state',
  imports: [ButtonModule],
  templateUrl: './empty-state.html',
  styleUrl: './empty-state.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmptyState {
  readonly title = input.required<string>();
  readonly description = input('');
  readonly icon = input('pi pi-fw pi-inbox');
  readonly size = input<'sm' | 'md' | 'lg'>('md');
  readonly actionLabel = input('');
  readonly actionIcon = input('pi pi-fw pi-plus');
  readonly showAction = input(false);

  readonly onAction = output<void>();

  actionClick(): void {
    this.onAction.emit();
  }
}
