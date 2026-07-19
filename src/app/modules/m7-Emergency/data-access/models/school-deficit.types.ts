import type { Attachment } from './shared.types'

export interface SchoolDeficit {
  id: number
  schoolId: number
  deficitNumber: string
  deficitType: string
  deficitCategory?: string
  deficitAmount: number
  requiredAmount: number
  availableAmount: number
  deficitDescription?: string
  educationalImpact?: string
  impactLevel: 'منخفض' | 'متوسط' | 'مرتفع' | 'حرج'
  detectionDate: string
  detectedByUserId?: number
  deficitStatus: 'مكتشف' | 'قيد المعالجة' | 'محلول' | 'ملغي'
  statusUpdateDate?: string
  proposedSolution?: string
  estimatedResolutionCost: number
  estimatedResolutionDate?: string
  actualResolutionDate?: string
  resolvedByUserId?: number
  resolutionNotes?: string
  relatedRemediationPlanId?: number
  attachments?: Attachment[]
  notes?: string
}

export type CreateSchoolDeficit = Omit<SchoolDeficit, 'id'>

export type UpdateSchoolDeficit = Partial<SchoolDeficit> & { id: number }

export type SchoolDeficitResponse = SchoolDeficit

export type SchoolDeficitListResponse = SchoolDeficit[]
