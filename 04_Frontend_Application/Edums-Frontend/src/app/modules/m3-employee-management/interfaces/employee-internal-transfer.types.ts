import type { AuditFields, OrganizationalScope } from './shared.types'

export type InternalApprovalStatus = 'قيد_الانتظار' | 'معتمد' | 'مرفوض' | 'ملغي'

export interface EmployeeInternalTransferData {
  employeeId: number
  transferRequestNumber: string
  requestDate: string
  fromDepartmentId: number
  toDepartmentId: number
  fromJobTitle: string | null
  toJobTitle: string | null
  transferReason: string
  effectiveDate: string | null
  approvalStatus: InternalApprovalStatus
  approvedByEmployeeId: number | null
  approvalDate: string | null
  rejectionReason: string | null
  decisionDocumentUrl: string | null
  notes: string | null
}

export interface EmployeeInternalTransfer extends AuditFields, OrganizationalScope, EmployeeInternalTransferData {}

export type CreateEmployeeInternalTransfer = Omit<EmployeeInternalTransfer, keyof AuditFields>

export type UpdateEmployeeInternalTransfer = Partial<Omit<EmployeeInternalTransfer, keyof AuditFields>> & { id: number }
