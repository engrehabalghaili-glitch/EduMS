import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { NgClass } from '@angular/common';
import { TagModule } from 'primeng/tag';
import { BadgeModule } from 'primeng/badge';

export type BadgeSeverity = 'success' | 'info' | 'warning' | 'danger' | 'secondary' | 'contrast';
export type BadgeSize = 'small' | 'normal' | 'large';

type PrimeSeverity = 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';

@Component({
  selector: 'app-status-badge',
  imports: [TagModule, BadgeModule, NgClass],
  templateUrl: './status-badge.html',
  styleUrl: './status-badge.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StatusBadge {
  readonly status = input.required<string>();
  readonly severity = input<BadgeSeverity>('info');
  readonly icon = input('');
  readonly size = input<BadgeSize>('normal');
  readonly rounded = input(false);
  readonly pulsing = input(false);

  readonly severityMap: Record<BadgeSeverity, PrimeSeverity> = {
    success: 'success',
    info: 'info',
    warning: 'warn',
    danger: 'danger',
    secondary: 'secondary',
    contrast: 'contrast',
  };
}
