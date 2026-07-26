import { EnrollmentStatus, EnrollmentType, PromotionStatus } from './_types';

export interface StudentEnrollment {
  id: number;
  studentId: number;
  schoolId: number;
  classroomId: number;
  academicYear: string;
  semesterNumber: number;
  enrollmentDate: string;
  enrollmentStatus: EnrollmentStatus;
  isCurrentTerm: boolean;
  enrollmentType: EnrollmentType;
  assignedRollNumber: number;
  promotionStatus: PromotionStatus;
  enrollmentRemarks?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentEnrollment = Omit<StudentEnrollment, 'id' | 'createdAt' | 'modifiedAt' | 'enrollmentStatus' | 'promotionStatus'>;

export type UpdateStudentEnrollment = CreateStudentEnrollment & { id: number };
