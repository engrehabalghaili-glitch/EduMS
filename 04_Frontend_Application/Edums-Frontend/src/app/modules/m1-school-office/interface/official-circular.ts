import type { CircularType, TargetAudience } from './common';

export interface OfficialCircular {
  id: number;
  circularNumber: string;
  issueDate: string;
  titleAr: string;
  titleEn: string;
  circularType: CircularType;
  issuerName: string;
  targetAudience: TargetAudience;
  effectiveDate: string;
  isActive: boolean;
  contentBody: string | null;
  issuerEmployeeId: number | null;
  attachmentFileUrl: string | null;
  requiresMandatoryAcknowledgment: boolean;
  acknowledgmentDeadline: string | null;
}

export type CreateOfficialCircularDto = Omit<OfficialCircular, 'id' | 'isActive' | 'effectiveDate'>;

export type UpdateOfficialCircularDto = Omit<OfficialCircular, 'isActive' | 'effectiveDate'>;
