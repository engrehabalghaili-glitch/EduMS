import type { AuditFields, OrganizationalScope } from './shared.types'

export type TrainingType = 'داخلي' | 'خارجي' | 'عن_بعد' | 'مؤتمرات'
export type CompletionStatus = 'مسجل' | 'قيد_التنفيذ' | 'مكتمل' | 'لم_يكتمل' | 'ملغي'

export interface EmployeeTrainingData {
  employeeId: number
  courseName: string
  courseCode: string | null
  trainingType: TrainingType
  providerName: string
  startDate: string
  endDate: string
  durationHours: number
  trainingLocation: string | null
  trainingCost: number
  fundingSource: string | null
  completionStatus: CompletionStatus
  score: number | null
  gradeLevel: string | null
  certificateUrl: string | null
  certificateExpiryDate: string | null
  trainingOutcomesSummary: string | null
  notes: string | null
}

export interface EmployeeTraining extends AuditFields, OrganizationalScope, EmployeeTrainingData {}

export type CreateEmployeeTraining = Omit<EmployeeTraining, keyof AuditFields>

export type UpdateEmployeeTraining = Partial<Omit<EmployeeTraining, keyof AuditFields>> & { id: number }
