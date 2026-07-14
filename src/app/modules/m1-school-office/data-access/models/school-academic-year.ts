import type { RecordStatus } from './common';

export interface SchoolAcademicYear {
  id: number;
  schoolId: number;
  yearCode: string;
  yearNameAr: string;
  yearNameEn: string | null;
  startDate: string;
  endDate: string;
  registrationStartDate: string;
  registrationEndDate: string;
  addDropStartDate: string | null;
  addDropEndDate: string | null;
  examsStartDate: string | null;
  examsEndDate: string | null;
  isCurrentYear: boolean;
  yearStatus: RecordStatus;
  isArchived: boolean;
  archivedDate: string | null;
  previousAcademicYearId: number | null;
  notes: string | null;
}

export type CreateSchoolAcademicYearDto = Omit<SchoolAcademicYear, 'id' | 'yearStatus' | 'isCurrentYear'>;

export type UpdateSchoolAcademicYearDto = Omit<SchoolAcademicYear, 'schoolId' | 'yearStatus' | 'isCurrentYear'>;
