import type { AuditFields, AcademicScope } from './shared.types'

export interface EmployeeMentorData {
  mentorEmployeeId: number
  menteeEmployeeId: number
  assignmentDate: string
  endDate: string | null
  mentoringGoals: string | null
  isActive: boolean
  notes: string | null
}

export interface EmployeeMentor extends AuditFields, AcademicScope, EmployeeMentorData {}

export type CreateEmployeeMentor = Omit<EmployeeMentor, keyof AuditFields>

export type UpdateEmployeeMentor = Partial<Omit<EmployeeMentor, keyof AuditFields>> & { id: number }
