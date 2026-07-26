import { ChangeDetectionStrategy, Component, input, output, computed } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DatePickerModule } from 'primeng/datepicker';
import { DialogModule } from 'primeng/dialog';
import { BadgeModule } from 'primeng/badge';
import { TooltipModule } from 'primeng/tooltip';
import { Skeleton } from 'primeng/skeleton';
import { NgClass, DatePipe } from '@angular/common';
import { CalendarEvent } from './calendar-viewer.types';

export { type CalendarEvent } from './calendar-viewer.types';

@Component({
  selector: 'app-calendar-viewer',
  imports: [FormsModule, DatePickerModule, DialogModule, BadgeModule, TooltipModule, Skeleton, NgClass, DatePipe],
  templateUrl: './calendar-viewer.html',
  styleUrl: './calendar-viewer.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarViewer {
  readonly events = input<CalendarEvent[]>([]);
  readonly loading = input(false);
  readonly defaultDate = input(new Date());
  readonly minDate = input<Date | undefined>(undefined);
  readonly maxDate = input<Date | undefined>(undefined);
  readonly showEventDetails = input(true);
  readonly readonly = input(false);

  readonly onEventClick = output<CalendarEvent>();
  readonly onDateSelect = output<Date>();

  selectedDate: Date | null = null;
  selectedEvent: CalendarEvent | null = null;
  detailVisible = false;

  eventsByDate = computed(() => {
    const map = new Map<string, CalendarEvent[]>();
    for (const evt of this.events()) {
      const key = this.dateKey(evt.date);
      if (!map.has(key)) map.set(key, []);
      map.get(key)!.push(evt);
    }
    return map;
  });

  private dateKey(d: Date): string {
    return `${d.getFullYear()}-${d.getMonth()}-${d.getDate()}`;
  }

  eventsForDateMeta(day: number, month: number, year: number): CalendarEvent[] {
    const key = `${year}-${month}-${day}`;
    return this.eventsByDate().get(key) ?? [];
  }

  hasEvents(day: number, month: number, year: number): boolean {
    return this.eventsForDateMeta(day, month, year).length > 0;
  }

  eventDotColor(day: number, month: number, year: number): string {
    const evts = this.eventsForDateMeta(day, month, year);
    if (evts.length === 0) return 'transparent';
    if (evts.length === 1) return evts[0].color ?? this.typeColor(evts[0].type);
    return '#006699';
  }

  eventCount(day: number, month: number, year: number): number {
    return this.eventsForDateMeta(day, month, year).length;
  }

  dateSelect(value: unknown): void {
    this.selectedDate = value as Date;
    this.onDateSelect.emit(value as Date);
    if (this.selectedDate) {
      const key = this.dateKey(this.selectedDate);
      const dayEvents = this.eventsByDate().get(key);
      if (dayEvents && dayEvents.length === 1 && this.showEventDetails()) {
        this.selectedEvent = dayEvents[0];
        this.detailVisible = true;
      }
    }
  }

  eventClick(evt: CalendarEvent): void {
    this.selectedEvent = evt;
    this.onEventClick.emit(evt);
    if (this.showEventDetails()) {
      this.detailVisible = true;
    }
  }

  typeLabel(type: string): string {
    switch (type) {
      case 'holiday': return 'عطلة';
      case 'exam': return 'امتحان';
      case 'meeting': return 'اجتماع';
      case 'deadline': return 'موعد نهائي';
      case 'visit': return 'زيارة';
      case 'event': return 'فعالية';
      default: return 'أخرى';
    }
  }

  typeColor(type: string): string {
    switch (type) {
      case 'holiday': return '#16a34a';
      case 'exam': return '#dc2626';
      case 'meeting': return '#006699';
      case 'deadline': return '#ca8a04';
      case 'visit': return '#6366f1';
      case 'event': return '#0891b2';
      default: return '#71717a';
    }
  }

  typeIcon(type: string): string {
    switch (type) {
      case 'holiday': return 'pi pi-sun';
      case 'exam': return 'pi pi-file';
      case 'meeting': return 'pi pi-users';
      case 'deadline': return 'pi pi-clock';
      case 'visit': return 'pi pi-eye';
      case 'event': return 'pi pi-calendar';
      default: return 'pi pi-circle';
    }
  }

  dayEvents(): CalendarEvent[] {
    if (!this.selectedDate) return [];
    const key = this.dateKey(this.selectedDate);
    return this.eventsByDate().get(key) ?? [];
  }

  todayDate(): Date {
    return new Date();
  }
}
