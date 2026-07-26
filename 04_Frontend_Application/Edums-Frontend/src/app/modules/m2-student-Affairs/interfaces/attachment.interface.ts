export interface StudentAttachment {
  id: number;
  studentId: number;
  attachmentTitleAr: string;
  attachmentCategory: number;
  fileName: string;
  filePathUrl: string;
  fileSizeKb: number;
  uploadDate: string;
  attachmentTitleEn?: string;
  mimeType?: string;
  isConfidential: boolean;
  uploadedByEmployeeId?: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentAttachment = Omit<StudentAttachment, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentAttachment = CreateStudentAttachment & { id: number };
