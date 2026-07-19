import { BaseAuditFields, ReportStatus } from './base.types';

export interface ExceptionalStatisticsReport extends BaseAuditFields {
  schoolId: number;
  schoolAcademicYearId: number | null;
  reportNumber: string;
  totalIncidents: number;
  totalClosureDays: number;
  totalDamageCost: number;
  totalAwardsCount: number;
  totalParticipationsCount: number;
  totalDeficitCount: number;
  totalSurplusCount: number;
  emergencySummaryJson: string | null;
  closureSummaryJson: string | null;
  awardSummaryJson: string | null;
  generationDate: string;
  generatedByUserId: number | null;
  filePath: string | null;
  reportStatus: ReportStatus;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateExceptionalStatisticsReport = Omit<ExceptionalStatisticsReport, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateExceptionalStatisticsReport = Pick<ExceptionalStatisticsReport, 'id'> & Partial<Omit<ExceptionalStatisticsReport, 'id' | 'createdAt' | 'modifiedAt'>>;
