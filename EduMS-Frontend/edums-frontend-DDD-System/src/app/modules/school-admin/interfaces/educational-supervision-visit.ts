import type { VisitStatus } from './common';

export interface EducationalSupervisionVisit {
  id: number;
  directorateId: number;
  schoolId: number;
  supervisorName: string;
  visitDate: string;
  visitPurpose: string;
  evaluationScore: number | null;
  recommendations: string | null;
  status: VisitStatus;
  supervisorEmployeeId: number | null;
  targetDepartmentId: number | null;
  followUpRequiredDate: string | null;
  actionItemsDetail: string | null;
}

export type CreateEducationalSupervisionVisitDto = Omit<EducationalSupervisionVisit, 'id' | 'status'>;

export type UpdateEducationalSupervisionVisitDto = Omit<EducationalSupervisionVisit, 'directorateId' | 'schoolId' | 'status'>;
