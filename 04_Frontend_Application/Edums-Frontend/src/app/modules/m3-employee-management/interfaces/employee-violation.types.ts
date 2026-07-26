import type { AuditFields, OrganizationalScope } from './shared.types'

export type ViolationCategory = 'إداري' | 'مالي' | 'سلوكي' | 'أكاديمي' | 'غياب'
export type SanctionType = 'إنذار' | 'خصم_من_الراتب' | 'حرمان_من_البدل' | 'فصل' | 'توقيف'
export type ViolationStatus = 'مبلغة' | 'قيد_التحقيق' | 'مقروء' | 'مستأنفة' | 'مغلقة'

export interface EmployeeViolationData {
  employeeId: number
  violationReferenceNumber: string
  violationDate: string
  violationCategory: ViolationCategory
  violationDescriptionAr: string
  supportingDocumentUrl: string | null
  sanctionType: SanctionType
  penaltyDeductionAmount: number
  violationStatus: ViolationStatus
  reportedByEmployeeId: number | null
  investigatingEmployeeId: number | null
  investigationDate: string | null
  investigationNotes: string | null
  decisionText: string | null
  decisionDate: string | null
  isAppealed: boolean
  appealDate: string | null
  appealResult: string | null
  notes: string | null
}

export interface EmployeeViolation extends AuditFields, OrganizationalScope, EmployeeViolationData {}

export type CreateEmployeeViolation = Omit<EmployeeViolation, keyof AuditFields>

export type UpdateEmployeeViolation = Partial<Omit<EmployeeViolation, keyof AuditFields>> & { id: number }
