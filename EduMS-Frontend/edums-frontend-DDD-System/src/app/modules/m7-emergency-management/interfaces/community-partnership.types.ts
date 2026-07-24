import type { Attachment } from './shared.types'

export interface CommunityPartnership {
  id: number
  schoolId: number
  partnershipNumber: string
  partnerName: string
  partnerType?: string
  supportType?: string
  agreementDate?: string
  startDate: string
  endDate?: string
  isRenewable: boolean
  agreementDocumentPath?: string
  supportValueAmount: number
  supportValueCurrency?: string
  supportInKind?: string[]
  impact?: string
  impactRating: number
  responsibleEmployeeId?: number
  partnerContactPerson?: string
  partnerContactEmail?: string
  partnerContactPhone?: string
  partnershipStatus: 'نشط' | 'منتهي' | 'ملغي'
  notes?: string
}

export type CreateCommunityPartnership = Omit<CommunityPartnership, 'id'>

export type UpdateCommunityPartnership = Partial<CommunityPartnership> & { id: number }

export type CommunityPartnershipResponse = CommunityPartnership

export type CommunityPartnershipListResponse = CommunityPartnership[]
