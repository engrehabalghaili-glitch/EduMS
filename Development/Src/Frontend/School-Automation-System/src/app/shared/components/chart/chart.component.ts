import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { UIChart } from 'primeng/chart';

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [UIChart],
  template: `
    <div class="chart-wrapper">
      <p-chart
        [type]="type()"
        [data]="data()"
        [options]="options()"
        [height]="height()" />
    </div>
  `,
  styleUrl: './chart.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppChart {
  readonly type = input.required<'bar' | 'line' | 'scatter' | 'bubble' | 'pie' | 'doughnut' | 'polarArea' | 'radar'>();
  readonly data = input.required<any>();
  readonly options = input<any>();
  readonly height = input('280px');
}
