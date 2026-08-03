import type { AuditFields } from './shared.types'

export type MemberRole = 'رئيس' | 'نائب_رئيس' | 'مقرر' | 'عضو' | 'خبير'

export interface CommitteeMemberData {
  committeeId: number
  employeeId: number
  memberRole: MemberRole
  joinDate: string
  exitDate: string | null
  isActive: boolean
  notes: string | null
}

export interface CommitteeMember extends AuditFields, CommitteeMemberData {}

export type CreateCommitteeMember = Omit<CommitteeMember, keyof AuditFields>

export type UpdateCommitteeMember = Partial<Omit<CommitteeMember, keyof AuditFields>> & { id: number }
