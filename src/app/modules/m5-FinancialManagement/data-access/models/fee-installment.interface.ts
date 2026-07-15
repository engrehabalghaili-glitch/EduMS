import { InstallmentStatus, AuditFields } from './common.types';

export interface FeeInstallment extends AuditFields {
  id: number;
  invoiceId: number;
  itemId: number | null;
  studentAccountId: number;
  studentId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  installmentNumber: number;
  installmentTotal: number;
  installmentAmount: number;
  currency: string;
  dueDate: string;
  extendedDueDate: string | null;
  paidAmount: number;
  remainingAmount: number;
  paymentDate: string | null;
  paymentMethod: string | null;
  paymentReference: string | null;
  installmentType: string | null;
  installmentStatus: InstallmentStatus;
  isLate: boolean;
  lateDays: number | null;
  lateFeePercentage: number | null;
  lateFeeAmount: number | null;
  lateFeePaid: boolean;
  lateFeePaymentDate: string | null;
  lateFeePaymentReference: string | null;
  isRescheduled: boolean;
  rescheduledDate: string | null;
  rescheduledByUserId: number | null;
  rescheduledReason: string | null;
  newDueDate: string | null;
  isWaived: boolean;
  waiverReason: string | null;
  waiverDate: string | null;
  waivedByUserId: number | null;
  waiverApprovalDocumentUrl: string | null;
  notes: string | null;
}

export type CreateFeeInstallmentDto = Omit<FeeInstallment, 'id' | 'createdAt'>;

export type UpdateFeeInstallmentDto = Omit<FeeInstallment, 'createdAt'>;
