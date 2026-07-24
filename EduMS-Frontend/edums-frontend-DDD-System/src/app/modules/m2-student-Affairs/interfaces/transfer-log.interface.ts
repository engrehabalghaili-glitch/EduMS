import { StatusNumeric } from './_types';

export interface StudentTransferLog {
  id: number;
  studentId: number;
  fromSchoolId: number;
  toSchoolId: number;
  transferDate: string;
  reason: string;
  status: StatusNumeric;
  transferCertificateNumber?: string;
  approvedByEmployeeId?: number;
  ministryApprovalReference?: string;
  transferRemarks?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentTransferLog = Omit<StudentTransferLog, 'id' | 'createdAt' | 'modifiedAt' | 'status' | 'approvedByEmployeeId'>;

export type UpdateStudentTransferLog = CreateStudentTransferLog & { id: number };
