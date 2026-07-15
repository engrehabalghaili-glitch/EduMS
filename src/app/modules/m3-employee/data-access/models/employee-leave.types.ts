import type { AuditFields, AcademicScope } from './shared.types'

export type LeaveType = 'سنوية' | 'مرضية' | 'اضطرارية' | 'دراسية' | 'بدون_راتب' | 'أمومة' | 'أبوة' | 'حج' | 'تعويضية'
export type LeaveApprovalStatus = 'قيد_الانتظار' | 'معتمد' | 'مرفوض' | 'ملغي'

export interface EmployeeLeaveData {
  employeeId: number
  leaveType: LeaveType
  startDate: string
  endDate: string
  totalDays: number
  leaveReason: string
  supportingDocumentUrl: string | null
  approvalStatus: LeaveApprovalStatus
  approvedByEmployeeId: number | null
  approvalDate: string | null
  rejectionReason: string | null
  isEmergency: boolean
  replacementEmployeeName: string | null
  notes: string | null
}

export interface EmployeeLeave extends AuditFields, AcademicScope, EmployeeLeaveData {}

export type CreateEmployeeLeave = Omit<EmployeeLeave, keyof AuditFields>

export type UpdateEmployeeLeave = Partial<Omit<EmployeeLeave, keyof AuditFields>> & { id: number }
