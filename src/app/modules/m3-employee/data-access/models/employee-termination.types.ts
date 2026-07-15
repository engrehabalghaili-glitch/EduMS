import type { AuditFields, OrganizationalScope } from './shared.types'

export type TerminationType = 'استقالة' | 'فصل' | 'إنهاء_خدمة' | 'تقاعد' | 'اتفاق_طرفين'
export type TerminationStatus = 'قيد_المعالجة' | 'مكتمل' | 'ملغي'

export interface EmployeeTerminationData {
  employeeId: number
  terminationReferenceNumber: string
  terminationDate: string
  terminationType: TerminationType
  terminationReason: string
  lastWorkingDay: string | null
  custodyCleared: boolean
  custodyClearanceDate: string | null
  financialCleared: boolean
  financialClearanceDate: string | null
  gratuityAmount: number
  finalSalarySettlement: number
  decisionDocumentUrl: string | null
  approvedByUserId: number | null
  approvalDate: string | null
  terminationStatus: TerminationStatus
  notes: string | null
}

export interface EmployeeTermination extends AuditFields, OrganizationalScope, EmployeeTerminationData {}

export type CreateEmployeeTermination = Omit<EmployeeTermination, keyof AuditFields>

export type UpdateEmployeeTermination = Partial<Omit<EmployeeTermination, keyof AuditFields>> & { id: number }
