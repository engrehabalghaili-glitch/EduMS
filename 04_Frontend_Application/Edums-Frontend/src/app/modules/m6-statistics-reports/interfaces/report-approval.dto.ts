import { BaseAuditFields, ApprovalStatus } from './base.types';

export interface ReportApproval extends BaseAuditFields {
  systemReportId: number;
  schoolId: number;
  submissionDate: string;
  submittedByUserId: number;
  approvalStatus: ApprovalStatus;
  reviewerId: number | null;
  reviewDate: string | null;
  comments: string | null;
  rejectionReason: string | null;
  approvalDate: string | null;
  approvedByUserId: number | null;
  digitalSignatureHash: string | null;
  certificateNumber: string | null;
  certificatePath: string | null;
  isFinal: boolean;
  notes: string | null;
}

export type CreateReportApproval = Omit<ReportApproval, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateReportApproval = Pick<ReportApproval, 'id'> & Partial<Omit<ReportApproval, 'id' | 'createdAt' | 'modifiedAt'>>;
