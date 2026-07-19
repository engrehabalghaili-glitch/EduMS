import type { AuditFields } from './shared.types'

export type DisbursementStatus = 'قيد_المعالجة' | 'صرف' | 'معلق' | 'ملغي'

export interface EmployeePayrollFinancialContractData {
  employeePayrollId: number
  employeeId: number
  organizationalSectorId: number | null
  financialTransactionReferenceNumber: string
  costCenterCode: string
  budgetLineCode: string
  totalGrossAmount: number
  totalDeductionsAmount: number
  netDisbursementAmount: number
  currency: string
  disbursementStatus: DisbursementStatus
  disbursementDate: string | null
  bankTransferReference: string | null
  financialAuditorEmployeeId: number | null
  financialAuditNotes: string | null
}

export interface EmployeePayrollFinancialContract extends AuditFields, EmployeePayrollFinancialContractData {}

export type CreateEmployeePayrollFinancialContract = Omit<EmployeePayrollFinancialContract, keyof AuditFields>

export type UpdateEmployeePayrollFinancialContract = Partial<Omit<EmployeePayrollFinancialContract, keyof AuditFields>> & { id: number }
