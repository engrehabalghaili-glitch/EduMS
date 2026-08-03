import type { GenderAllocation } from './common';

export interface GradeCapacity {
  id: number;
  schoolAcademicYearId: number;
  schoolLevelId: number;
  gradeLevelCode: string;
  gradeNameAr: string;
  gradeNameEn: string | null;
  maxStudentsPerSection: number;
  maxSectionsCount: number;
  currentEnrolledCount: number;
  genderAllocation: GenderAllocation;
  isActive: boolean;
  notes: string | null;
}

export type CreateGradeCapacityDto = Omit<GradeCapacity, 'id' | 'isActive'>;

export type UpdateGradeCapacityDto = Omit<GradeCapacity, 'isActive'>;
