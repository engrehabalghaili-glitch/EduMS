import { Component, input, ChangeDetectionStrategy, ViewEncapsulation } from '@angular/core';
import { Card } from 'primeng/card';
import type { StatsCardConfig } from '../../interfaces/shared.types';

const COLOR_MAP: Record<string, { bg: string; text: string }> = {
  info:    { bg: 'var(--info-500)',    text: 'var(--info-500)' },
  success: { bg: 'var(--success-500)', text: 'var(--success-500)' },
  warn:    { bg: 'var(--warning-500)', text: 'var(--warning-500)' },
  danger:  { bg: 'var(--danger-500)',  text: 'var(--danger-500)' },
  primary: { bg: 'var(--primary-500)', text: 'var(--primary-500)' },
  gray:    { bg: 'var(--gray-500)',    text: 'var(--gray-600)' },
};

@Component({
  selector: 'app-stats-card',
  imports: [Card],
  template: `
    <p-card class="stats-card">
      <div class="stats-content">
        <div class="stats-icon-box" [style.background]="colors.bg">
          <span [class]="config().icon" style="color: var(--white); font-size: 1.2rem;"></span>
        </div>
        <div class="stats-info">
          <span class="stats-value" [style.color]="colors.text">{{ config().value }}</span>
          <span class="stats-label">{{ config().label }}</span>
          @if (config().trend; as trend) {
            <span class="stats-trend" [class.up]="trend.direction === 'up'" [class.down]="trend.direction === 'down'">
              <span [class]="trend.direction === 'up' ? 'pi pi-arrow-up' : 'pi pi-arrow-down'"></span>
              {{ trend.value }}
            </span>
          }
        </div>
      </div>
    </p-card>
  `,
  styleUrl: './stats-card.component.scss',
  standalone: true,
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StatsCardComponent {
  readonly config = input.required<StatsCardConfig>();

  get colors(): { bg: string; text: string } {
    return COLOR_MAP[this.config().color] ?? COLOR_MAP['info'];
  }
}
