import { WarningCategory, WarningLevel, StatusNumeric } from './_types';

export interface DetailedAcademicWarningLog {
  id: number;
  studentId: number;
  warningDate: string;
  warningCategory: WarningCategory;
  subjectId?: number;
  warningLevel: WarningLevel;
  triggerDescription: string;
  guardianAcknowledgedDate?: string;
  issuedByEmployeeId?: number;
  remedialPlanDescription?: string;
  targetResolutionDate?: string;
  status: StatusNumeric;
  isEscalatedToDirector: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateDetailedAcademicWarningLog = Omit<DetailedAcademicWarningLog, 'id' | 'createdAt' | 'modifiedAt' | 'status'>;

export type UpdateDetailedAcademicWarningLog = CreateDetailedAcademicWarningLog & { id: number };
