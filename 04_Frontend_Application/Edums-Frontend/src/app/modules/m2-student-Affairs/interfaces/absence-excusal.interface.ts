import { ExcusalType, ReviewStatus } from './_types';

export interface StudentAbsenceExcusal {
  id: number;
  studentId: number;
  startDate: string;
  endDate: string;
  excusalType: ExcusalType;
  reasonDescription: string;
  medicalReportAttachmentUrl?: string;
  reviewStatus: ReviewStatus;
  reviewedByEmployeeId?: number;
  submittedByGuardianId?: number;
  submissionDate: string;
  reviewRemarks?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentAbsenceExcusal = Omit<StudentAbsenceExcusal, 'id' | 'createdAt' | 'modifiedAt' | 'reviewStatus' | 'reviewedByEmployeeId'>;

export type UpdateStudentAbsenceExcusal = CreateStudentAbsenceExcusal & { id: number };
