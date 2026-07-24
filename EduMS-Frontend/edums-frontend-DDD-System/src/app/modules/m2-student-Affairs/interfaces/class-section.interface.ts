import { StatusNumeric } from './_types';

export interface ClassSection {
  id: number;
  schoolId: number;
  schoolAcademicYearId: number;
  schoolSemesterId?: number;
  gradeCapacityId?: number;
  classroomId?: number;
  sectionCode: string;
  sectionNameAr: string;
  sectionNameEn?: string;
  maxStudents: number;
  currentEnrolledCount: number;
  homeroomTeacherEmployeeId?: number;
  shiftId?: number;
  sectionStatus: StatusNumeric;
  isActive: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateClassSection = Omit<ClassSection, 'id' | 'createdAt' | 'modifiedAt' | 'sectionStatus' | 'isActive' | 'currentEnrolledCount'>;

export type UpdateClassSection = CreateClassSection & { id: number };
