import type { VisitStatus } from './common';

export interface VisitorEntryLog {
  id: number;
  schoolId: number;
  visitorFullName: string;
  nationalIdOrPassport: string;
  visitPurpose: string;
  hostEmployeeId: number | null;
  checkInTime: string;
  checkOutTime: string | null;
  visitorBadgeNumber: string | null;
  status: VisitStatus;
  visitorPhoneNumber: string | null;
  visitorOrganization: string | null;
  securityGateNumber: string | null;
  securityOfficerEmployeeId: number | null;
}

export type CreateVisitorEntryLogDto = Omit<VisitorEntryLog, 'id' | 'status'>;

export type UpdateVisitorEntryLogDto = Omit<VisitorEntryLog, 'schoolId' | 'status'>;
