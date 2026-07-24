import { BaseAuditFields, ApprovalStatus, ComplianceReportType, EntityType, SubmissionMethod } from './base.types';

export interface ExternalComplianceReport extends BaseAuditFields {
  schoolId: number;
  reportNumber: string;
  targetEntityName: string;
  entityType: EntityType;
  standardType: string | null;
  reportType: ComplianceReportType;
  periodStart: string | null;
  periodEnd: string | null;
  generationDate: string;
  generatedByUserId: number | null;
  filePath: string | null;
  submissionDate: string | null;
  submissionMethod: SubmissionMethod;
  receiptReference: string | null;
  receiptDate: string | null;
  submissionStatus: ApprovalStatus;
  rejectionReason: string | null;
  isFinal: boolean;
  finalApprovalDate: string | null;
  notes: string | null;
}

export type CreateExternalComplianceReport = Omit<ExternalComplianceReport, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateExternalComplianceReport = Pick<ExternalComplianceReport, 'id'> & Partial<Omit<ExternalComplianceReport, 'id' | 'createdAt' | 'modifiedAt'>>;
