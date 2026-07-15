import { BaseAuditFields, ApprovalStatus, AuditStatus, FinancialReportType } from './base.types';

export interface SchoolFinancialSummaryReport extends BaseAuditFields {
  schoolId: number;
  fiscalYear: string;
  reportDate: string;
  reportType: FinancialReportType;
  totalBookValue: number;
  totalDepreciation: number;
  totalAssetsCount: number;
  totalAcquisitionCost: number;
  totalRevaluationGains: number;
  totalImpairmentLosses: number;
  totalRevenue: number;
  totalExpenses: number;
  netIncome: number;
  auditStatus: AuditStatus | null;
  auditFirmName: string | null;
  auditDate: string | null;
  approvalStatus: ApprovalStatus;
  approvedByUserId: number | null;
  approvalDate: string | null;
  filePath: string | null;
  notes: string | null;
}

export type CreateSchoolFinancialSummaryReport = Omit<SchoolFinancialSummaryReport, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateSchoolFinancialSummaryReport = Pick<SchoolFinancialSummaryReport, 'id'> & Partial<Omit<SchoolFinancialSummaryReport, 'id' | 'createdAt' | 'modifiedAt'>>;
