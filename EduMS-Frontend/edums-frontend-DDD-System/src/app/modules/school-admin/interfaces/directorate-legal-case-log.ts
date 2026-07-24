import type { CaseCategory, CaseStatus } from './common';

export interface DirectorateLegalCaseLog {
  id: number;
  directorateId: number;
  caseCodeNumber: string;
  caseCategory: CaseCategory;
  subjectTitle: string;
  involvedPartiesDescription: string;
  registrationDate: string;
  resolutionDate: string | null;
  caseStatus: CaseStatus;
  resolutionDecisionText: string | null;
  assignedLegalCounselEmployeeId: number | null;
  caseDocumentAttachmentUrl: string | null;
}

export type CreateDirectorateLegalCaseLogDto = Omit<DirectorateLegalCaseLog, 'id' | 'caseStatus'>;

export type UpdateDirectorateLegalCaseLogDto = Omit<DirectorateLegalCaseLog, 'directorateId' | 'caseStatus'>;
