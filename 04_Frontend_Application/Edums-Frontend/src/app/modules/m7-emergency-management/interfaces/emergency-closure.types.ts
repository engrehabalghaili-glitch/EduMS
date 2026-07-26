import type { Attachment } from './shared.types'

export interface EmergencyClosure {
  id: number
  schoolId: number
  closureNumber: string
  closureReason: string
  decisionAuthority?: string
  authorityDecisionNumber?: string
  startDate: string
  endDate?: string
  actualEndDate?: string
  totalClosureDays: number
  schoolDaysAffected: number
  alternativeEducationActivated: boolean
  alternativeEducationType?: string
  altEducationPlatform?: string
  altEducationDetails?: string
  wasCompensated: boolean
  compensationRemediationPlanId?: number
  parentNotificationSent: boolean
  parentNotificationDate?: string
  parentNotificationMethod?: string
  closureStatus: 'مخطط' | 'نشط' | 'منتهي' | 'ملغي'
  notes?: string
}

export type CreateEmergencyClosure = Omit<EmergencyClosure, 'id'>

export type UpdateEmergencyClosure = Partial<EmergencyClosure> & { id: number }

export type EmergencyClosureResponse = EmergencyClosure

export type EmergencyClosureListResponse = EmergencyClosure[]
