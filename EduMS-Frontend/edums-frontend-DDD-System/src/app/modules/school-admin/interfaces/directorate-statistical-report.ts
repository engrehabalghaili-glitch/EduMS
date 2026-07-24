import type { VerificationStatus, PeriodType, ReportTargetCategory } from './common';

export interface DirectorateStatisticalReport {
  id: number;
  directorateId: number;
  reportCode: string;
  reportTitleAr: string;
  reportTitleEn: string | null;
  targetCategory: ReportTargetCategory;
  periodType: PeriodType;
  targetAcademicYear: string;
  statisticalDataPayloadJson: string;
  analyticalSummary: string | null;
  recommendationsText: string | null;
  generationDate: string;
  compiledByEmployeeId: number | null;
  verificationStatus: VerificationStatus;
}

export type CreateDirectorateStatisticalReportDto = Omit<DirectorateStatisticalReport, 'id' | 'verificationStatus'>;

export type UpdateDirectorateStatisticalReportDto = Omit<DirectorateStatisticalReport, 'directorateId' | 'verificationStatus'>;
