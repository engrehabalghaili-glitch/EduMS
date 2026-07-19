import type { RecordStatus, TermSemester } from './common';

export interface ExamDistributionTimetable {
  id: number;
  schoolId: number;
  subjectId: number;
  classroomId: number;
  facilityId: number | null;
  proctorEmployeeId: number | null;
  examDate: string;
  startTime: string;
  endTime: string;
  maxSeatCount: number;
  status: RecordStatus;
  examSessionNameAr: string | null;
  examType: number;
  termSemesterNumber: TermSemester;
  assistantProctorEmployeeId: number | null;
  isSeatingChartPublished: boolean;
}

export type CreateExamDistributionTimetableDto = Omit<ExamDistributionTimetable, 'id' | 'status'>;

export type UpdateExamDistributionTimetableDto = Omit<ExamDistributionTimetable, 'schoolId' | 'status'>;
