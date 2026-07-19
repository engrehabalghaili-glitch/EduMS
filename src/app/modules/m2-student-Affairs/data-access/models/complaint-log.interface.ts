import { ComplaintStatus } from './_types';

export interface StudentComplaintLog {
  id: number;
  studentId: number;
  submittedByGuardianId?: number;
  complaintReferenceNumber: string;
  submissionDate: string;
  complaintCategory: number;
  complaintTitleAr: string;
  complaintDescriptionText: string;
  supportingDocumentUrl?: string;
  complaintStatus: ComplaintStatus;
  assignedToEmployeeId?: number;
  assignedDate?: string;
  expectedResolutionDate?: string;
  actualResolutionDate?: string;
  investigationNotes?: string;
  resolutionDecisionText?: string;
  isGuardianNotifiedOfResolution: boolean;
  guardianNotificationDate?: string;
  guardianSatisfactionRating: number;
  isEscalatedToDirectorate: boolean;
  escalationDate?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentComplaintLog = Omit<StudentComplaintLog, 'id' | 'createdAt' | 'modifiedAt' | 'complaintStatus'>;

export type UpdateStudentComplaintLog = CreateStudentComplaintLog & { id: number };
