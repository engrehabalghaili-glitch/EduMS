import { InstallmentStatus, AuditFields } from './common.types';

export interface InvoiceItem extends AuditFields {
  id: number;
  invoiceId: number;
  feeTypeId: number;
  itemCode: string | null;
  itemDescription: string;
  quantity: number;
  unitPrice: number;
  totalPrice: number;
  discountPercentage: number | null;
  discountAmount: number;
  priceAfterDiscount: number;
  taxPercentage: number | null;
  taxAmount: number;
  netAmount: number;
  dueDate: string | null;
  isPaid: boolean;
  paidAmount: number;
  remainingAmount: number;
  paymentMethod: string | null;
  isLate: boolean;
  lateFeeApplied: boolean;
  lateFeeAmount: number | null;
  installmentNumber: number | null;
  installmentTotal: number | null;
  isWaived: boolean;
  waiverReason: string | null;
  waiverDate: string | null;
  status: InstallmentStatus;
  notes: string | null;
}

export type CreateInvoiceItemDto = Omit<InvoiceItem, 'id' | 'createdAt'>;

export type UpdateInvoiceItemDto = Omit<InvoiceItem, 'createdAt'>;
