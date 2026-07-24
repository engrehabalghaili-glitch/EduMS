import { BaseAuditFields, DisposalStatus, SourceReportType } from './base.types';

export interface StatisticsReportsArchive extends BaseAuditFields {
  sourceReportType: SourceReportType;
  sourceReportId: number;
  schoolId: number;
  archivedAt: string;
  archivedByUserId: number;
  retentionPeriodYears: number;
  retentionEndDate: string | null;
  filePath: string | null;
  fileSizeBytes: number;
  isReadOnly: boolean;
  disposalDate: string | null;
  disposalStatus: DisposalStatus;
  disposalMethod: string | null;
  notes: string | null;
}

export type CreateStatisticsReportsArchive = Omit<StatisticsReportsArchive, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStatisticsReportsArchive = Pick<StatisticsReportsArchive, 'id'> & Partial<Omit<StatisticsReportsArchive, 'id' | 'createdAt' | 'modifiedAt'>>;
