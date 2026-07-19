import { PaymentVoucherMethod, AuditFields } from './common.types';

export interface PaymentVoucher extends AuditFields {
  id: number;
  schoolId: number;
  vendorId: number | null;
  voucherNumber: string;
  voucherDate: string;
  totalAmount: number;
  paymentMethod: PaymentVoucherMethod;
  description: string;
  accountId: number | null;
}

export type CreatePaymentVoucherDto = Omit<PaymentVoucher, 'id' | 'createdAt'>;

export type UpdatePaymentVoucherDto = Omit<PaymentVoucher, 'createdAt'>;
