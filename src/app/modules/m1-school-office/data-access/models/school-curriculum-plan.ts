import type { PlanStatus, MinisterialApprovalStatus } from './common';

export interface SchoolCurriculumPlan {
  id: number;
  schoolId: number;
  planNameAr: string;
  planNameEn: string | null;
  planCode: string;
  gradeCapacityId: number | null;
  schoolLevelId: number | null;
  schoolAcademicYearId: number;
  schoolSemesterId: number | null;
  planVersion: string;
  adoptionDate: string;
  totalCreditHours: number;
  planStatus: PlanStatus;
  ministerialApprovalStatus: MinisterialApprovalStatus;
  approvalDocumentUrl: string | null;
  isActive: boolean;
  effectiveDate: string;
  expiryDate: string | null;
  notes: string | null;
}

export type CreateSchoolCurriculumPlanDto = Omit<SchoolCurriculumPlan, 'id' | 'planStatus' | 'ministerialApprovalStatus' | 'isActive' | 'effectiveDate'>;

export type UpdateSchoolCurriculumPlanDto = Omit<SchoolCurriculumPlan, 'schoolId' | 'planStatus' | 'ministerialApprovalStatus' | 'isActive' | 'effectiveDate'>;
