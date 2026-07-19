import { RequestStatus } from './_types';

export interface StudentAdmissionApplication {
  id: number;
  guardianId: number;
  schoolId: number;
  schoolAcademicYearId?: number;
  requestedGradeLevelCode: string;
  submissionDate: string;
  requestStatus: RequestStatus;
  birthCertificateAttachmentUrl?: string;
  personalPhotoAttachmentUrl?: string;
  previousSchoolName?: string;
  previousSchoolGradeLevel?: string;
  hasSpecialNeeds: boolean;
  specialNeedsDetails?: string;
  medicalNotes?: string;
  hasSiblingInSchool: boolean;
  siblingNames?: string;
  referralSource?: string;
  emergencyContactName?: string;
  emergencyContactPhone?: string;
  reviewedByEmployeeId?: number;
  reviewDate?: string;
  rejectionReason?: string;
  approvalDate?: string;
  convertedToStudentId?: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentAdmissionApplication = Omit<StudentAdmissionApplication, 'id' | 'createdAt' | 'modifiedAt' | 'requestStatus'>;

export type UpdateStudentAdmissionApplication = CreateStudentAdmissionApplication & { id: number };
