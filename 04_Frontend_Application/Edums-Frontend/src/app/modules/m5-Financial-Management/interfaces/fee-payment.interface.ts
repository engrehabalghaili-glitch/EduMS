import { PaymentMethodType, ConfirmationStatus, AuditFields } from './common.types';

export interface FeePayment extends AuditFields {
  id: number;
  studentAccountId: number;
  studentId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  invoiceId: number | null;
  installmentId: number | null;
  paymentNumber: string;
  paymentDate: string;
  paymentTime: string | null;
  amount: number;
  currency: string;
  exchangeRate: number;
  convertedAmount: number;
  paymentMethod: PaymentMethodType;
  paymentType: string | null;
  bankName: string | null;
  bankTransactionId: string | null;
  checkNumber: string | null;
  checkBank: string | null;
  checkDate: string | null;
  creditCardLast4: string | null;
  creditCardType: string | null;
  walletType: string | null;
  payerName: string | null;
  payerType: string | null;
  payerEmail: string | null;
  receiptNumber: string;
  receiptPrinted: boolean;
  receiptSentToEmail: boolean;
  receiptEmailSentAt: string | null;
  receiptDocumentUrl: string | null;
  paymentStatus: ConfirmationStatus;
  isConfirmed: boolean;
  confirmationDate: string | null;
  confirmedByUserId: number | null;
  isReversed: boolean;
  reversalDate: string | null;
  reversalReason: string | null;
  allocatedInvoicesJson: string | null;
  allocatedItemsJson: string | null;
  notes: string | null;
}

export type CreateFeePaymentDto = Omit<FeePayment, 'id' | 'createdAt'>;

export type UpdateFeePaymentDto = Omit<FeePayment, 'createdAt'>;
