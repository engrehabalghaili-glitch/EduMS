import type { Attachment, ExternalAgency } from './shared.types'

export interface EmergencyIncident {
  id: number
  schoolId: number
  incidentNumber: string
  incidentType: string
  incidentDate: string
  incidentTime?: string
  severity: 'منخفضة' | 'متوسطة' | 'عالية' | 'حرجة'
  description?: string
  locationText?: string
  reportedByUserId?: number
  reportedAt?: string
  isPlanActive: boolean
  emergencyPlanId?: number
  affectedCount: number
  studentsAffected: number
  employeesAffected: number
  injuriesCount: number
  severeInjuriesCount: number
  fatalitiesCount: number
  propertyDamage: number
  propertyDamageDescription?: string
  emergencyResponseActions?: string
  externalAgencies?: ExternalAgency[]
  externalResponseTime?: string
  incidentStatus: 'مبلّغ' | 'قيد المعالجة' | 'مغلق' | 'ملغي'
  closureDate?: string
  closureNotes?: string
  investigationReportUrl?: string
  lessonsLearned?: string
  recommendations?: string
  attachments?: Attachment[]
  notes?: string
}

export type CreateEmergencyIncident = Omit<EmergencyIncident, 'id'>

export type UpdateEmergencyIncident = Partial<EmergencyIncident> & { id: number }

export type EmergencyIncidentResponse = EmergencyIncident

export type EmergencyIncidentListResponse = EmergencyIncident[]
