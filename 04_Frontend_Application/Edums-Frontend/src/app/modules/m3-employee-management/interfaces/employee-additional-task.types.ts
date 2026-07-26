import type { AuditFields, OrganizationalScope } from './shared.types'

export type TaskType = 'إدارية' | 'تعليمية' | 'فنية' | 'رقابية' | 'لجنة'
export type TaskStatus = 'جديد' | 'قيد_التنفيذ' | 'منجز' | 'معلق' | 'ملغي'

export interface EmployeeAdditionalTaskData {
  employeeId: number
  taskTitleAr: string
  taskDescription: string | null
  taskType: TaskType
  startDate: string
  endDate: string | null
  hasFinancialCompensation: boolean
  compensationAmount: number
  assignedByEmployeeId: number | null
  taskStatus: TaskStatus
  notes: string | null
}

export interface EmployeeAdditionalTask extends AuditFields, OrganizationalScope, EmployeeAdditionalTaskData {}

export type CreateEmployeeAdditionalTask = Omit<EmployeeAdditionalTask, keyof AuditFields>

export type UpdateEmployeeAdditionalTask = Partial<Omit<EmployeeAdditionalTask, keyof AuditFields>> & { id: number }
