import { VerificationStatus } from './_types';

export interface StudentPreviousAcademicHistory {
  id: number;
  studentId: number;
  previousSchoolName: string;
  previousDirectorateName: string;
  academicYearCompleted: string;
  gradeLevelCompleted: number;
  cumulativeScoreEarned: number;
  maximumPossibleScore: number;
  percentage: number;
  leavingCertificateNumber?: string;
  leavingDate: string;
  verificationStatus: VerificationStatus;
  transcriptDocumentUrl?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentPreviousAcademicHistory = Omit<StudentPreviousAcademicHistory, 'id' | 'createdAt' | 'modifiedAt' | 'verificationStatus'>;

export type UpdateStudentPreviousAcademicHistory = CreateStudentPreviousAcademicHistory & { id: number };
