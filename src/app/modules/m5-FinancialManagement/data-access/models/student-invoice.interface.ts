import {
  InvoiceStatus,
  PaymentStatus,
  ParentApprovalStatus,
  InvoiceCategoryType,
  AuditFields,
} from './common.types';

export interface StudentInvoice extends AuditFields {
  id: number;
  studentAccountId: number;
  studentId: number;
  schoolId: number;
  schoolAcademicYearId: number | null;
  schoolSemesterId: number | null;
  invoiceNumber: string;
  invoiceDate: string;
  dueDate: string | null;
  issueDate: string | null;
  totalAmount: number;
  discountAmount: number;
  discountReason: number | null;
  taxAmount: number;
  taxRate: number;
  taxRegistrationNumber: string | null;
  netAmount: number;
  paidAmount: number;
  remainingAmount: number;
  invoiceType: string;
  invoiceCategory: InvoiceCategoryType;
  paymentStatus: PaymentStatus;
  invoiceStatus: InvoiceStatus;
  paymentMethod: string | null;
  isLate: boolean;
  lateDays: number | null;
  lateFeePercentage: number | null;
  lateFeeAmount: number | null;
  installmentPlan: boolean;
  installmentCount: number | null;
  currentInstallment: number | null;
  parentApprovalRequired: boolean;
  parentApprovalStatus: ParentApprovalStatus;
  parentApprovalDate: string | null;
  sentToParent: boolean;
  parentNotifiedAt: string | null;
  notes: string | null;
}

export type CreateStudentInvoiceDto = Omit<StudentInvoice, 'id' | 'createdAt'>;

export type UpdateStudentInvoiceDto = Omit<StudentInvoice, 'createdAt'>;
