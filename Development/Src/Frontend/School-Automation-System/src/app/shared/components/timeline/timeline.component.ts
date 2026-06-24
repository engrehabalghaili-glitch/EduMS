import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Timeline } from 'primeng/timeline';
import { NgTemplateOutlet } from '@angular/common';

@Component({
  selector: 'app-timeline',
  standalone: true,
  imports: [Timeline, NgTemplateOutlet],
  template: `
    <p-timeline [value]="items()" [align]="align()">
      <ng-template pTemplate="content" let-item>
        <ng-container *ngTemplateOutlet="contentTemplate(); context: { $implicit: item }" />
      </ng-template>
      <ng-template pTemplate="opposite" let-item>
        <ng-container *ngTemplateOutlet="oppositeTemplate(); context: { $implicit: item }" />
      </ng-template>
    </p-timeline>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppTimeline {
  readonly items = input.required<any[]>();
  readonly align = input<'left' | 'right' | 'alternate'>('right');
  readonly contentTemplate = input<any>();
  readonly oppositeTemplate = input<any>();
}
