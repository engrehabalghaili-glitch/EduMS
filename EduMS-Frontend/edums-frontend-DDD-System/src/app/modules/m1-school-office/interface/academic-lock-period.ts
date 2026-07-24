import type { RecordStatus } from './common';

export interface AcademicLockPeriod {
  id: number;
  officeId: number;
  schoolId: number;
  periodName: string;
  startDate: string;
  endDate: string;
  isActive: boolean;
  lockGradeRosters: boolean;
  lockEnrollmentSnapshots: boolean;
  lockPeriodStatisticalReports: boolean;
  lockAttendanceLogs: boolean;
  lockBehavioralRecords: boolean;
  lockFinancialFeeAssessments: boolean;
  unlockReasonDescription: string | null;
  initiatedByEmployeeId: number | null;
}

export type CreateAcademicLockPeriodDto = Omit<AcademicLockPeriod, 'id' | 'isActive'>;

export type UpdateAcademicLockPeriodDto = Omit<AcademicLockPeriod, 'isActive' | 'schoolId'>;
