import { BaseAuditFields, ApprovalStatus, PeriodType, SubmissionMethod } from './base.types';

export interface SubmittedStatistics extends BaseAuditFields {
  statisticsDraftId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  submissionNumber: string;
  submissionTimestamp: string;
  submissionMethod: SubmissionMethod;
  submittedByUserId: number;
  directorSignatureHash: string | null;
  directorSignatureDate: string | null;
  studentDataSnapshotJson: string | null;
  staffDataSnapshotJson: string | null;
  financialSummarySnapshotJson: string | null;
  approvalStatus: ApprovalStatus;
  reviewerNotes: string | null;
  reviewDate: string | null;
  reviewedByUserId: number | null;
  rejectionReason: string | null;
  approvalDate: string | null;
  isFinal: boolean;
  isArchived: boolean;
  archivedAt: string | null;
  notes: string | null;
}

export type CreateSubmittedStatistics = Omit<SubmittedStatistics, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateSubmittedStatistics = Pick<SubmittedStatistics, 'id'> & Partial<Omit<SubmittedStatistics, 'id' | 'createdAt' | 'modifiedAt'>>;
