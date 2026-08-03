import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { StepsModule } from 'primeng/steps';

@Component({
  selector: 'app-steps-bar',
  imports: [StepsModule],
  templateUrl: './steps-bar.html',
  styleUrl: './steps-bar.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StepsBar {
  readonly steps = input.required<MenuItem[]>();
  readonly activeIndex = input(0);
  readonly readonly = input(true);
  readonly styleClass = input('');

  readonly activeIndexChange = output<number>();

  onStepClick(index: number): void {
    if (this.readonly()) return;
    this.activeIndexChange.emit(index);
  }
}
