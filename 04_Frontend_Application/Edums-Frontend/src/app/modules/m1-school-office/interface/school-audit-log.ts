import type { OperationType, SeverityLevel } from './common';

export interface SchoolAuditLog {
  id: number;
  schoolId: number;
  affectedTableName: string;
  affectedEntityId: number;
  operationType: OperationType;
  changeTypeSummary: string;
  oldValueJson: string | null;
  newValueJson: string | null;
  changeSummaryText: string;
  performedByUserId: number;
  performedByUserName: string;
  performedByUserRole: string;
  ipAddress: string | null;
  deviceInfo: string | null;
  actionDate: string;
  severityLevel: SeverityLevel;
  isSuspicious: boolean;
  decisionDocumentUrl: string | null;
  notes: string | null;
}

export type CreateSchoolAuditLogDto = Omit<SchoolAuditLog, 'id'>;

export type UpdateSchoolAuditLogDto = Omit<SchoolAuditLog, 'schoolId'>;
