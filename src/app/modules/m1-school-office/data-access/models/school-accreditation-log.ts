import type { RecordStatus, LicenseType } from './common';

export interface SchoolAccreditationLog {
  id: number;
  schoolId: number;
  licenseNumber: string;
  accreditationBody: string;
  issueDate: string;
  expiryDate: string;
  status: RecordStatus;
  licenseType: LicenseType;
  accreditationGrade: string | null;
  certificateAttachmentUrl: string | null;
  renewalSubmittedDate: string | null;
}

export type CreateSchoolAccreditationLogDto = Omit<SchoolAccreditationLog, 'id' | 'status'>;

export type UpdateSchoolAccreditationLogDto = Omit<SchoolAccreditationLog, 'schoolId' | 'status'>;
