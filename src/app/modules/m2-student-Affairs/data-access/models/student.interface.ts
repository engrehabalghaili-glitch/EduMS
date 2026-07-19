import { Person } from './person.interface';
import { StudentStatus } from './_types';

export interface Student extends Person {
  enrollmentNumber: string;
  enrollmentDate: string;
  schoolId?: number;
  classroomId?: number;
  guardianId?: number;
  previousSchoolName?: string;
  admissionGradeLevel: number;
  currentAcademicYear?: string;
  studentStatus: StudentStatus;
  specialEducationNeeds?: string;
  busStopLocationDescription?: string;
  isActive: boolean;
}

export type CreateStudent = Omit<Student, 'id' | 'createdAt' | 'modifiedAt' | 'studentStatus' | 'isActive'>;

export type UpdateStudent = CreateStudent & { id: number };
