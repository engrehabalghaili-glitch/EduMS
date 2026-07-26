import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { TimelineModule } from 'primeng/timeline';

export interface TimelineEvent {
  id?: string | number;
  title: string;
  description?: string;
  icon?: string;
  color?: string;
  date?: string | Date;
  actor?: string;
  metadata?: TimelineEventMeta[];
}

export interface TimelineEventMeta {
  label: string;
  value: string;
  icon?: string;
}

@Component({
  selector: 'app-timeline',
  imports: [TimelineModule],
  templateUrl: './timeline.html',
  styleUrl: './timeline.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppTimeline {
  readonly events = input.required<TimelineEvent[]>();
  readonly alignment = input<'left' | 'right' | 'top' | 'bottom' | 'alternate'>('left');
  readonly layout = input<'vertical' | 'horizontal'>('vertical');
  readonly showIcons = input(true);
  readonly styleClass = input('');

  readonly onEventClick = output<TimelineEvent>();

  eventClick(event: TimelineEvent): void {
    this.onEventClick.emit(event);
  }

  getEventIcon(event: TimelineEvent): string {
    return event.icon ?? 'pi pi-fw pi-circle-fill';
  }

  getEventColor(event: TimelineEvent): string {
    return event.color ?? '#006699';
  }
}
