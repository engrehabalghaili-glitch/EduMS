import { BaseAuditFields, ReportCategory } from './base.types';

export interface StatisticalReportSnapshot extends BaseAuditFields {
  schoolId: number;
  academicLockPeriodId: number | null;
  reportCode: string;
  reportNameAr: string;
  reportCategory: ReportCategory;
  snapshotPayloadJson: string;
  snapshotDate: string;
  isVerifiedByOffice: boolean;
}

export type CreateStatisticalReportSnapshot = Omit<StatisticalReportSnapshot, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStatisticalReportSnapshot = Pick<StatisticalReportSnapshot, 'id'> & Partial<Omit<StatisticalReportSnapshot, 'id' | 'createdAt' | 'modifiedAt'>>;
