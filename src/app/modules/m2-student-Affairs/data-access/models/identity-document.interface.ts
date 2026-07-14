import { DocumentStatus } from './_types';

export interface StudentIdentityDocument {
  id: number;
  studentId: number;
  documentType: number;
  documentNumber: string;
  issueCountry?: string;
  issueDate?: string;
  expiryDate?: string;
  attachmentUrl?: string;
  isVerified: boolean;
  issuePlace?: string;
  verifiedByEmployeeId?: number;
  verificationDate?: string;
  documentStatus: DocumentStatus;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentIdentityDocument = Omit<StudentIdentityDocument, 'id' | 'createdAt' | 'modifiedAt' | 'documentStatus' | 'isVerified' | 'verifiedByEmployeeId' | 'verificationDate'>;

export type UpdateStudentIdentityDocument = CreateStudentIdentityDocument & { id: number };
