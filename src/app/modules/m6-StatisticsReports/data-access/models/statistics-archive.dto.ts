import { BaseAuditFields, PeriodType } from './base.types';

export interface StatisticsArchive extends BaseAuditFields {
  submittedStatisticsId: number;
  schoolId: number;
  archivedYear: string;
  periodType: PeriodType;
  archivedAt: string;
  archivedByUserId: number;
  finalDataSnapshotJson: string | null;
  studentSnapshotJson: string | null;
  staffSnapshotJson: string | null;
  retentionPeriodYears: number;
  retentionEndDate: string | null;
  isReadOnly: boolean;
  notes: string | null;
}

export type CreateStatisticsArchive = Omit<StatisticsArchive, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStatisticsArchive = Pick<StatisticsArchive, 'id'> & Partial<Omit<StatisticsArchive, 'id' | 'createdAt' | 'modifiedAt'>>;
