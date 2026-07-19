import type { Participant } from './shared.types'

export interface SchoolAward {
  id: number
  schoolId: number
  awardNumber: string
  awardName: string
  awardCategory?: string
  awardLevel: 'محلي' | 'إقليمي' | 'وطني' | 'دولي'
  issuingBody?: string
  issuingBodyType?: string
  awardDate: string
  awardPlace?: string
  ranking?: string
  participants?: Participant[]
  studentParticipantsCount: number
  teacherParticipantsCount: number
  awardDetails?: string
  certificatePath?: string
  photosPaths?: string[]
  videoPath?: string
  impact?: string
  notes?: string
}

export type CreateSchoolAward = Omit<SchoolAward, 'id'>

export type UpdateSchoolAward = Partial<SchoolAward> & { id: number }

export type SchoolAwardResponse = SchoolAward

export type SchoolAwardListResponse = SchoolAward[]
