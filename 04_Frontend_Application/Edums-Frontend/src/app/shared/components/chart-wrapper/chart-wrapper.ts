import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { NgClass } from '@angular/common';

export type ChartType = 'line' | 'bar' | 'radar' | 'pie' | 'doughnut' | 'polarArea';

@Component({
  selector: 'app-chart-wrapper',
  imports: [ChartModule, NgClass],
  templateUrl: './chart-wrapper.html',
  styleUrl: './chart-wrapper.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartWrapper {
  readonly type = input<ChartType>('bar');
  readonly data = input.required<unknown>();
  readonly options = input<unknown>({});
  readonly width = input('100%');
  readonly height = input('');
  readonly title = input('');
  readonly showLegend = input(true);
  readonly styleClass = input('');

  get mergedOptions(): Record<string, unknown> {
    const opts = (this.options() as Record<string, unknown>) ?? {};
    const existingPlugins = (opts['plugins'] as Record<string, unknown>) ?? {};
    const existingLegend = (existingPlugins['legend'] as Record<string, unknown>) ?? {};
    return {
      ...opts,
      plugins: {
        ...existingPlugins,
        legend: {
          ...existingLegend,
          display: this.showLegend(),
        },
      },
    };
  }
}
