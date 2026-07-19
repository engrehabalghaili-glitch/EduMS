import type { Attachment, Participant, ExpenseItem } from './shared.types'

export interface ExternalParticipation {
  id: number
  schoolId: number
  participationNumber: string
  eventName: string
  eventType?: string
  organizer?: string
  organizerType?: string
  location?: string
  startDate: string
  endDate?: string
  results?: string
  ranking?: string
  participants?: Participant[]
  studentParticipantsCount: number
  teacherParticipantsCount: number
  expenses?: ExpenseItem[]
  fundingSource?: string
  attachments?: Attachment[]
  lessonsLearned?: string
  recommendations?: string
  notes?: string
}

export type CreateExternalParticipation = Omit<ExternalParticipation, 'id'>

export type UpdateExternalParticipation = Partial<ExternalParticipation> & { id: number }

export type ExternalParticipationResponse = ExternalParticipation

export type ExternalParticipationListResponse = ExternalParticipation[]
