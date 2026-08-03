import type { EventType, TargetAudience } from './common';

export interface SchoolEventCalendar {
  id: number;
  schoolId: number;
  eventTitleAr: string;
  eventTitleEn: string;
  startDate: string;
  endDate: string;
  eventType: EventType;
  isPublic: boolean;
  description: string | null;
  organizerEmployeeId: number | null;
  targetAudience: TargetAudience;
  locationDetails: string | null;
  requiresAttendanceTracking: boolean;
}

export type CreateSchoolEventCalendarDto = Omit<SchoolEventCalendar, 'id'>;

export type UpdateSchoolEventCalendarDto = Omit<SchoolEventCalendar, 'schoolId'>;
