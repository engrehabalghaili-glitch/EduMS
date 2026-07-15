import type { AuditFields } from './shared.types'

export type PortalRequestType = 'تحديث_بيانات' | 'طلب_إجازة' | 'طلب_انتداب' | 'طلب_تدريب' | 'استفسار'
export type PortalRequestStatus = 'جديد' | 'قيد_المعالجة' | 'منجز' | 'مرفوض' | 'ملغي'

export interface SelfServicePortalRequestData {
  employeeId: number
  requestType: PortalRequestType
  requestTitleAr: string
  requestDetailsText: string | null
  submissionDate: string
  requestStatus: PortalRequestStatus
  reviewedByUserId: number | null
  reviewDate: string | null
  rejectionReason: string | null
  attachmentUrl: string | null
  notes: string | null
}

export interface SelfServicePortalRequest extends AuditFields, SelfServicePortalRequestData {}

export type CreateSelfServicePortalRequest = Omit<SelfServicePortalRequest, keyof AuditFields>

export type UpdateSelfServicePortalRequest = Partial<Omit<SelfServicePortalRequest, keyof AuditFields>> & { id: number }
