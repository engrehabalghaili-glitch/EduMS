import type { Attachment } from './shared.types'

export interface SchoolSurplus {
  id: number
  schoolId: number
  surplusNumber: string
  surplusType: string
  surplusCategory?: string
  surplusAmount: number
  availableAmount: number
  requiredAmount: number
  surplusDescription?: string
  utilizationPlan?: string
  utilizationType?: string
  potentialBeneficiary?: string
  discoveryDate: string
  discoveredByUserId?: number
  surplusStatus: 'مكتشف' | 'مخطط للاستخدام' | 'مستخدم' | 'ملغي'
  statusUpdateDate?: string
  utilizationDate?: string
  actualUtilizationDate?: string
  utilizedByUserId?: number
  utilizationNotes?: string
  relatedRemediationPlanId?: number
  attachments?: Attachment[]
  notes?: string
}

export type CreateSchoolSurplus = Omit<SchoolSurplus, 'id'>

export type UpdateSchoolSurplus = Partial<SchoolSurplus> & { id: number }

export type SchoolSurplusResponse = SchoolSurplus

export type SchoolSurplusListResponse = SchoolSurplus[]
