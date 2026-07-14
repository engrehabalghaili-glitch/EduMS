import type { ApprovalStatus, SemesterType } from './common';

export interface SchoolSemester {
  id: number;
  schoolAcademicYearId: number;
  semesterNumber: number;
  semesterType: SemesterType;
  semesterNameAr: string;
  semesterNameEn: string | null;
  startDate: string;
  endDate: string;
  teachingWeeksCount: number;
  examWeeksCount: number;
  registrationOpenDate: string | null;
  registrationCloseDate: string | null;
  addDropStartDate: string | null;
  addDropEndDate: string | null;
  examStartDate: string | null;
  examEndDate: string | null;
  gradingOpenDate: string | null;
  gradingCloseDate: string | null;
  closureDate: string | null;
  approvalStatus: ApprovalStatus;
  isActive: boolean;
  isCurrent: boolean;
  notes: string | null;
}

export type CreateSchoolSemesterDto = Omit<SchoolSemester, 'id' | 'approvalStatus' | 'isActive' | 'isCurrent'>;

export type UpdateSchoolSemesterDto = Omit<SchoolSemester, 'approvalStatus' | 'isActive' | 'isCurrent'>;
