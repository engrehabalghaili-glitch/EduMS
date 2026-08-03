export interface CalendarEvent {
  id: number | string;
  title: string;
  date: Date;
  endDate?: Date;
  type: 'holiday' | 'exam' | 'meeting' | 'deadline' | 'visit' | 'event' | 'other';
  description?: string;
  color?: string;
  icon?: string;
  allDay?: boolean;
}
