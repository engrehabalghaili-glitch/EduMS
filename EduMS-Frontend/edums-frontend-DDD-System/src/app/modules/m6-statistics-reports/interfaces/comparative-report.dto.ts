import { BaseAuditFields, ComparisonType, FileFormat, ReportStatus } from './base.types';

export interface ComparativeReport extends BaseAuditFields {
  schoolId: number;
  reportNumber: string;
  comparisonTitle: string;
  firstPeriodLabel: string;
  firstPeriodStart: string;
  firstPeriodEnd: string;
  secondPeriodLabel: string;
  secondPeriodStart: string;
  secondPeriodEnd: string;
  comparisonType: ComparisonType;
  kpiComparedJson: string | null;
  comparisonDataJson: string | null;
  autoInsights: string | null;
  summary: string | null;
  generationDate: string;
  generatedByUserId: number | null;
  fileFormat: FileFormat | null;
  filePath: string | null;
  viewCount: number;
  lastViewedAt: string | null;
  reportStatus: ReportStatus;
  notes: string | null;
}

export type CreateComparativeReport = Omit<ComparativeReport, 'id' | 'createdAt' | 'modifiedAt' | 'viewCount' | 'lastViewedAt'>;

export type UpdateComparativeReport = Pick<ComparativeReport, 'id'> & Partial<Omit<ComparativeReport, 'id' | 'createdAt' | 'modifiedAt'>>;
