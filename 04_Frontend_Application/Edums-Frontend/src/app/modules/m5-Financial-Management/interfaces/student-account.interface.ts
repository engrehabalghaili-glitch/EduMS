import { BalanceType, StudentAccountStatus, AuditFields } from './common.types';

export interface StudentAccount extends AuditFields {
  id: number;
  studentId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  accountNumber: string;
  totalDebit: number;
  totalCredit: number;
  currentBalance: number;
  balanceType: BalanceType;
  totalDiscount: number;
  totalExemption: number;
  lastTransactionDate: string | null;
  lastPaymentDate: string | null;
  lastPaymentAmount: number | null;
  accountStatus: StudentAccountStatus;
  isExempt: boolean;
  exemptionPercentage: number | null;
  exemptionReason: string | null;
  exemptionApprovedByUserId: number | null;
  exemptionApprovalDate: string | null;
  exemptionDocumentUrl: string | null;
  minimumPaymentRequired: number | null;
  isBlockedFromRegistration: boolean;
  blockReason: string | null;
  unblockDate: string | null;
  paymentPlan: string | null;
  isEligibleForExam: boolean;
  notes: string | null;
}

export type CreateStudentAccountDto = Omit<StudentAccount, 'id' | 'createdAt'>;

export type UpdateStudentAccountDto = Omit<StudentAccount, 'createdAt'>;
