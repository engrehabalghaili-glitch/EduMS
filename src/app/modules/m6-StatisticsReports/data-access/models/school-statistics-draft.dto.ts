import { BaseAuditFields, DraftStatus, PeriodType } from './base.types';

export interface SchoolStatisticsDraft extends BaseAuditFields {
  schoolId: number;
  schoolAcademicYearId: number | null;
  schoolSemesterId: number | null;
  periodType: PeriodType;
  periodValue: number;
  periodStartDate: string;
  periodEndDate: string;
  draftNumber: string;
  draftVersion: string;
  studentDataJson: string | null;
  staffDataJson: string | null;
  financialSummaryJson: string | null;
  assetSummaryJson: string | null;
  completenessPercentage: number;
  draftStatus: DraftStatus;
  isLocked: boolean;
  lockedAt: string | null;
  lockedByUserId: number | null;
  lastSavedAt: string | null;
  savedByUserId: number | null;
  notes: string | null;
}

export type CreateSchoolStatisticsDraft = Omit<SchoolStatisticsDraft, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateSchoolStatisticsDraft = Pick<SchoolStatisticsDraft, 'id'> & Partial<Omit<SchoolStatisticsDraft, 'id' | 'createdAt' | 'modifiedAt'>>;
