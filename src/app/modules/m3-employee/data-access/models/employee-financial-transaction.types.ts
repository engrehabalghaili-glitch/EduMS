import type { AuditFields, OrganizationalScope } from './shared.types'

export type FinancialTransactionType = 'راتب' | 'بدل' | 'مكافأة' | 'خصم' | 'سلفة' | 'تعويض'
export type FinancialApprovalStatus = 'قيد_الانتظار' | 'معتمد' | 'مرفوض' | 'مسدد'

export interface EmployeeFinancialTransactionData {
  employeeId: number
  transactionReferenceNumber: string
  transactionType: FinancialTransactionType
  amount: number
  currency: string
  transactionDate: string
  descriptionAr: string
  descriptionEn: string | null
  approvalStatus: FinancialApprovalStatus
  approvedByEmployeeId: number | null
  approvalDate: string | null
  module5VoucherReference: string | null
  notes: string | null
}

export interface EmployeeFinancialTransaction extends AuditFields, OrganizationalScope, EmployeeFinancialTransactionData {}

export type CreateEmployeeFinancialTransaction = Omit<EmployeeFinancialTransaction, keyof AuditFields>

export type UpdateEmployeeFinancialTransaction = Partial<Omit<EmployeeFinancialTransaction, keyof AuditFields>> & { id: number }
