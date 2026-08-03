import type { RecordStatus, SyncStatus, ApprovalStatus, ConfigCategory } from './common';

export interface AcademicBranchConfigLog {
  id: number;
  schoolId: number;
  configKey: string;
  configValue: string;
  previousValue: string | null;
  changeReason: string | null;
  effectiveDate: string;
  configCategory: ConfigCategory;
  modifiedByEmployeeId: number | null;
  requiresSupervisoryApproval: boolean;
  approvalStatus: ApprovalStatus;
  isActive: boolean;
}

export type CreateAcademicBranchConfigLogDto = Omit<AcademicBranchConfigLog, 'id' | 'previousValue' | 'approvalStatus' | 'isActive' | 'modifiedByEmployeeId' | 'effectiveDate'>;

export type UpdateAcademicBranchConfigLogDto = Pick<AcademicBranchConfigLog, 'id' | 'configValue' | 'changeReason' | 'configCategory' | 'requiresSupervisoryApproval'>;
