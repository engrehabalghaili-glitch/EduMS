import { InvoiceStatus, AuditFields } from './common.types';

export interface FeeInvoice extends AuditFields {
  id: number;
  studentId: number;
  feeStructureId: number;
  invoiceNumber: string;
  totalAmount: number;
  paidAmount: number;
  dueDate: string;
  status: InvoiceStatus;
}

export type CreateFeeInvoiceDto = Omit<FeeInvoice, 'id' | 'createdAt'>;

export type UpdateFeeInvoiceDto = Omit<FeeInvoice, 'createdAt'>;
