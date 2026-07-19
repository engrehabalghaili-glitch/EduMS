import type { AuditFields, AcademicScope, PaymentStatus } from './shared.types'

export type PayrollPaymentMethod = 'تحويل_بنكي' | 'شيك' | 'نقدي'

export interface EmployeePayrollData {
  employeeId: number
  payrollMonth: number
  payrollYear: number
  basicSalary: number
  housingAllowance: number
  transportAllowance: number
  otherAllowances: number
  overtimePay: number
  grossTotal: number
  deductionAbsence: number
  deductionInsurance: number
  deductionOther: number
  netSalary: number
  paymentStatus: PaymentStatus
  paymentDate: string | null
  paymentMethod: PayrollPaymentMethod | null
  bankTransactionRef: string | null
  approvedByUserId: number | null
  approvalDate: string | null
  isSynced: boolean
  notes: string | null
}

export interface EmployeePayroll extends AuditFields, AcademicScope, EmployeePayrollData {}

export type CreateEmployeePayroll = Omit<EmployeePayroll, keyof AuditFields>

export type UpdateEmployeePayroll = Partial<Omit<EmployeePayroll, keyof AuditFields>> & { id: number }
