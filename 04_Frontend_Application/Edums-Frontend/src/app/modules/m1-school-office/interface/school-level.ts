import type { AcademicTrack } from './common';

export interface SchoolLevel {
  id: number;
  schoolId: number;
  levelNameAr: string;
  levelNameEn: string | null;
  levelOrder: number;
  startGrade: string;
  endGrade: string;
  academicTrack: AcademicTrack | null;
  minAgeYears: number;
  maxAgeYears: number;
  defaultShiftId: number | null;
  isActive: boolean;
  notes: string | null;
}

export type CreateSchoolLevelDto = Omit<SchoolLevel, 'id' | 'isActive'>;

export type UpdateSchoolLevelDto = Omit<SchoolLevel, 'schoolId' | 'isActive'>;
