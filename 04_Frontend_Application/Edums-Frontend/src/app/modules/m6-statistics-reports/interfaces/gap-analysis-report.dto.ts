import { BaseAuditFields, AnalysisStatus, GapType, Priority } from './base.types';

export interface GapAnalysisReport extends BaseAuditFields {
  schoolId: number;
  analysisNumber: string;
  analysisType: string;
  assetCategoryId: number | null;
  gradeCapacityId: number | null;
  departmentId: number | null;
  requiredQuantity: number;
  availableQuantity: number;
  gapValue: number;
  gapPercentage: number;
  gapType: GapType | null;
  recommendation: string | null;
  priority: Priority;
  estimatedCost: number;
  analysisDate: string;
  analyzedByUserId: number | null;
  filePath: string | null;
  analysisStatus: AnalysisStatus;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateGapAnalysisReport = Omit<GapAnalysisReport, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateGapAnalysisReport = Pick<GapAnalysisReport, 'id'> & Partial<Omit<GapAnalysisReport, 'id' | 'createdAt' | 'modifiedAt'>>;
