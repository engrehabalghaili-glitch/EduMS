import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { ProgressBarModule } from 'primeng/progressbar';
import { Skeleton } from 'primeng/skeleton';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-progress-indicator',
  imports: [ProgressBarModule, Skeleton, NgClass],
  templateUrl: './progress-indicator.html',
  styleUrl: './progress-indicator.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProgressIndicator {
  readonly value = input(0);
  readonly label = input('');
  readonly showValue = input(true);
  readonly color = input('#006699');
  readonly mode = input<'determinate' | 'indeterminate'>('determinate');
  readonly size = input<'small' | 'normal' | 'large'>('normal');
  readonly striped = input(false);
  readonly loading = input(false);

  barStyle(): Record<string, string> {
    return {
      height: this.size() === 'small' ? '0.5rem' : this.size() === 'large' ? '1.25rem' : '0.75rem',
      background: '#f0f0f0',
    };
  }

  fillStyle(): Record<string, string> {
    const s: Record<string, string> = { background: this.color() };
    if (this.striped()) {
      s['backgroundImage'] = 'linear-gradient(45deg, rgba(255,255,255,0.15) 25%, transparent 25%, transparent 50%, rgba(255,255,255,0.15) 50%, rgba(255,255,255,0.15) 75%, transparent 75%, transparent)';
      s['backgroundSize'] = '1rem 1rem';
    }
    return s;
  }

  displayValue(): string {
    return `${Math.round(this.value())}%`;
  }
}
