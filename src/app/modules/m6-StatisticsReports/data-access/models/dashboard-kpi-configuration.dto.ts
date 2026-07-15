import { BaseAuditFields, AggregationMethod, ChartType } from './base.types';

export interface DashboardKpiConfiguration extends BaseAuditFields {
  schoolId: number | null;
  kpiCode: string;
  kpiNameAr: string;
  kpiNameEn: string | null;
  kpiDescription: string | null;
  sourceModule: string;
  sourceTable: string | null;
  sourceField: string | null;
  aggregationMethod: AggregationMethod;
  chartType: ChartType;
  refreshIntervalMinutes: number;
  targetValue: number | null;
  thresholdGreen: number | null;
  thresholdYellow: number | null;
  thresholdRed: number | null;
  alertEnabled: boolean;
  alertRecipientsJson: string | null;
  isActive: boolean;
  displayOrder: number;
  dashboardId: number | null;
}

export type CreateDashboardKpiConfiguration = Omit<DashboardKpiConfiguration, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateDashboardKpiConfiguration = Pick<DashboardKpiConfiguration, 'id'> & Partial<Omit<DashboardKpiConfiguration, 'id' | 'createdAt' | 'modifiedAt'>>;
