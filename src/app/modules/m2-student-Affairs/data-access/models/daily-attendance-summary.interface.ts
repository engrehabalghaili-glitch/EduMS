export interface StudentDailyAttendanceSummary {
  id: number;
  studentId: number;
  academicYear: string;
  semesterNumber: number;
  monthNumber: number;
  totalPresentDays: number;
  totalAbsentDays: number;
  totalExcusedDays: number;
  totalLateDays: number;
  totalAbsencePercentage: number;
  isWarningThresholdReached: boolean;
  consecutiveAbsentDaysCount: number;
  lastAbsenceDate?: string;
  isParentNotifiedOfThreshold: boolean;
  calculatedGradeLevel: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentDailyAttendanceSummary = Omit<StudentDailyAttendanceSummary, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentDailyAttendanceSummary = CreateStudentDailyAttendanceSummary & { id: number };
