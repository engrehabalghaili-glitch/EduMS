import type { AuditFields } from './shared.types'

export type DecisionSource = 'وزاري' | 'مدير_المدرسة' | 'مدير_التعليم' | 'لجنة'
export type DecisionType = 'تعيين' | 'تثبيت' | 'ترقية' | 'نقل' | 'إعارة'
export type EmploymentType = 'دوام_كامل' | 'دوام_جزئي' | 'مؤقت'

export interface AppointmentDecisionData {
  employeeId: number
  decisionNumber: string
  decisionDate: string
  decisionSource: DecisionSource
  decisionType: DecisionType
  jobTitle: string
  jobGrade: string | null
  departmentId: number | null
  employmentType: EmploymentType
  startDate: string
  probationPeriodMonths: number
  probationEndDate: string | null
  salaryAmount: number
  allowanceDetailsJson: string | null
  otherBenefits: string | null
  attachmentUrl: string | null
  approvedByName: string | null
  approvedByTitle: string | null
  notes: string | null
}

export interface AppointmentDecision extends AuditFields, AppointmentDecisionData {}

export type CreateAppointmentDecision = Omit<AppointmentDecision, keyof AuditFields>

export type UpdateAppointmentDecision = Partial<Omit<AppointmentDecision, keyof AuditFields>> & { id: number }
