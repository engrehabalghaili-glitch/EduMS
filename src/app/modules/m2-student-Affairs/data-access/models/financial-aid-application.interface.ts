import { AidCategory, AidApplicationStatus } from './_types';

export interface StudentFinancialAidApplication {
  id: number;
  studentId: number;
  guardianId: number;
  applicationReferenceNumber: string;
  applicationDate: string;
  aidCategory: AidCategory;
  requestedAidAmountOrPercentage: number;
  verifiedGuardianAnnualIncome: number;
  familyMembersCount: number;
  applicationStatus: AidApplicationStatus;
  approvedDiscountPercentage: number;
  reviewedByCommitteeEmployeeId?: number;
  incomeProofAttachmentUrl?: string;
  committeeDecisionRemarks?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentFinancialAidApplication = Omit<StudentFinancialAidApplication, 'id' | 'createdAt' | 'modifiedAt' | 'applicationStatus'>;

export type UpdateStudentFinancialAidApplication = CreateStudentFinancialAidApplication & { id: number };
