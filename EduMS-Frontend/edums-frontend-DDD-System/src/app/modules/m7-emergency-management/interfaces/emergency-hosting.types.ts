import type { Attachment, ResourceItem, ExpenseItem } from './shared.types'

export interface EmergencyHosting {
  id: number
  schoolId: number
  hostingNumber: string
  hostingType: string
  hostingDate: string
  endDate?: string
  expectedEndDate?: string
  actualCount: number
  maxCapacity: number
  utilizationPercentage: number
  reason?: string
  sourceLocation?: string
  supportOrganization?: string
  supportOrgContact?: string
  facilitiesUsed?: string[]
  resourcesProvided?: ResourceItem[]
  resourcesReceived?: ResourceItem[]
  expenses?: ExpenseItem[]
  totalExpenses: number
  hostingStatus: 'مخطط' | 'نشط' | 'مكتمل' | 'ملغي'
  closureNotes?: string
  lessonsLearned?: string
  reportedByUserId?: number
  attachments?: Attachment[]
  notes?: string
}

export type CreateEmergencyHosting = Omit<EmergencyHosting, 'id'>

export type UpdateEmergencyHosting = Partial<EmergencyHosting> & { id: number }

export type EmergencyHostingResponse = EmergencyHosting

export type EmergencyHostingListResponse = EmergencyHosting[]
