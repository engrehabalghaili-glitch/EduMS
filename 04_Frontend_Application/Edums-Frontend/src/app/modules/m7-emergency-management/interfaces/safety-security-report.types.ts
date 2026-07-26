import type { Attachment, CommitteeMember } from './shared.types'

export interface SafetySecurityReport {
  id: number
  schoolId: number
  reportNumber: string
  reportDate: string
  reportPeriod?: string
  safetyLevel?: string
  extinguisherExpiryDate?: string
  extinguishersCount: number
  extinguishersLastInspection?: string
  extinguishersNextInspection?: string
  alarmSystemStatus?: string
  alarmLastTestDate?: string
  hasEvacuationMaps: boolean
  emergencyExitsStatus?: string
  drillCount: number
  drillDates?: string[]
  drillAverageTimeMinutes: number
  drillEvaluation?: string
  safetyCommitteeFormed: boolean
  safetyCommitteeMembers?: CommitteeMember[]
  safetyTrainingHours: number
  incidentsCount: number
  recommendations?: string
  actionPlan?: string
  attachments?: Attachment[]
  approvedByUserId?: number
  approvalDate?: string
  notes?: string
}

export type CreateSafetySecurityReport = Omit<SafetySecurityReport, 'id'>

export type UpdateSafetySecurityReport = Partial<SafetySecurityReport> & { id: number }

export type SafetySecurityReportResponse = SafetySecurityReport

export type SafetySecurityReportListResponse = SafetySecurityReport[]
