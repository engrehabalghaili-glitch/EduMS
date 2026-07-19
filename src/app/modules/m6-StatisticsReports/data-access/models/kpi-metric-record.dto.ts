import { BaseAuditFields, CalculationMethod, PeriodType } from './base.types';

export interface KpiMetricRecord extends BaseAuditFields {
  kpiConfigId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  periodType: PeriodType;
  periodValue: number;
  periodStartDate: string;
  periodEndDate: string;
  actualValue: number;
  targetValue: number | null;
  previousValue: number | null;
  changePercentage: number;
  statusColor: string | null;
  calculationMethod: CalculationMethod;
  calculationDate: string;
  calculatedByUserId: number | null;
  isVerified: boolean;
  verifiedByUserId: number | null;
  verifiedAt: string | null;
  notes: string | null;
}

export type CreateKpiMetricRecord = Omit<KpiMetricRecord, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateKpiMetricRecord = Pick<KpiMetricRecord, 'id'> & Partial<Omit<KpiMetricRecord, 'id' | 'createdAt' | 'modifiedAt'>>;
