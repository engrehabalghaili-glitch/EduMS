import { ClearanceStatus } from './_types';

export interface StudentExitClearance {
  id: number;
  studentId: number;
  clearanceReferenceNumber: string;
  clearanceReason: number;
  initiationDate: string;
  completionDate?: string;
  isLibraryClearanceApproved: boolean;
  isFinancialClearanceApproved: boolean;
  isCanteenClearanceApproved: boolean;
  isSportsEquipmentClearanceApproved: boolean;
  overallClearanceStatus: ClearanceStatus;
  approvedByDirectorEmployeeId?: number;
  clearanceNotes?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentExitClearance = Omit<StudentExitClearance, 'id' | 'createdAt' | 'modifiedAt' | 'overallClearanceStatus' | 'approvedByDirectorEmployeeId'>;

export type UpdateStudentExitClearance = CreateStudentExitClearance & { id: number };
