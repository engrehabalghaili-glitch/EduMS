import type { AuditFields } from './shared.types'

export type TransferDirection = 'وارد' | 'صادر' | 'داخلي'
export type TransferApprovalStatus = 'قيد_الانتظار' | 'معتمد' | 'مرفوض' | 'ملغي'

export interface EmployeeExternalTransferData {
  employeeId: number
  fromSchoolId: number | null
  toSchoolId: number | null
  fromDirectorateId: number | null
  toDirectorateId: number | null
  fromOrganizationalSectorId: number | null
  toOrganizationalSectorId: number | null
  transferRequestNumber: string
  requestDate: string
  transferDirection: TransferDirection
  transferReason: string
  effectiveDate: string | null
  returnDate: string | null
  ministryDecisionNumber: string | null
  ministryDecisionDate: string | null
  decisionDocumentUrl: string | null
  approvalStatus: TransferApprovalStatus
  approvedByUserId: number | null
  approvalDate: string | null
  notes: string | null
}

export interface EmployeeExternalTransfer extends AuditFields, EmployeeExternalTransferData {}

export type CreateEmployeeExternalTransfer = Omit<EmployeeExternalTransfer, keyof AuditFields>

export type UpdateEmployeeExternalTransfer = Partial<Omit<EmployeeExternalTransfer, keyof AuditFields>> & { id: number }
