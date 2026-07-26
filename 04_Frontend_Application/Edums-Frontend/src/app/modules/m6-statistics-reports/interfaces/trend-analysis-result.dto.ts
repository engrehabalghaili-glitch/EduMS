import { BaseAuditFields, AnalysisStatus, ForecastingMethod, TrendDirection } from './base.types';

export interface TrendAnalysisResult extends BaseAuditFields {
  schoolId: number;
  studyPeriod: string;
  startYear: string;
  endYear: string;
  kpiCode: string;
  historicalValuesJson: string | null;
  trendDirection: TrendDirection | null;
  slope: number | null;
  correlationCoefficient: number | null;
  forecastedValueNext1Year: number | null;
  forecastedValueNext2Year: number | null;
  confidenceLevel: number | null;
  lowerBound: number | null;
  upperBound: number | null;
  forecastingMethod: ForecastingMethod | null;
  analysisDate: string;
  analyzedByUserId: number | null;
  analysisStatus: AnalysisStatus;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateTrendAnalysisResult = Omit<TrendAnalysisResult, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateTrendAnalysisResult = Pick<TrendAnalysisResult, 'id'> & Partial<Omit<TrendAnalysisResult, 'id' | 'createdAt' | 'modifiedAt'>>;
