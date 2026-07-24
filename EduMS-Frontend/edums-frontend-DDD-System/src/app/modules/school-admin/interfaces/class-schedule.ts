import type { DayOfWeek, TermSemester, ScheduleType } from './common';

export interface ClassSchedule {
  id: number;
  schoolId: number;
  classroomId: number;
  subjectId: number;
  assignedEmployeeId: number | null;
  dayOfWeek: DayOfWeek;
  periodNumber: number;
  roomCode: string | null;
  startTime: string | null;
  endTime: string | null;
  termSemesterNumber: TermSemester;
  scheduleType: ScheduleType;
  isActive: boolean;
}

export type CreateClassScheduleDto = Omit<ClassSchedule, 'id' | 'isActive'>;

export type UpdateClassScheduleDto = Omit<ClassSchedule, 'schoolId' | 'isActive'>;
