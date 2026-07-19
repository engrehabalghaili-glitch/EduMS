import type { AuditFields, OrganizationalScope } from './shared.types'

export type CommitteeType = 'دائمة' | 'مؤقتة' | 'طارئة' | 'تنفيذية'
export type CommitteeStatus = 'نشطة' | 'منحلة' | 'معلقة'

export interface EmployeeCommitteeData {
  committeeNameAr: string
  committeeNameEn: string | null
  committeeCode: string
  committeeType: CommitteeType
  formationDate: string
  dissolutionDate: string | null
  objectives: string | null
  chairmanEmployeeId: number | null
  committeeStatus: CommitteeStatus
  notes: string | null
}

export interface EmployeeCommittee extends AuditFields, OrganizationalScope, EmployeeCommitteeData {}

export type CreateEmployeeCommittee = Omit<EmployeeCommittee, keyof AuditFields>

export type UpdateEmployeeCommittee = Partial<Omit<EmployeeCommittee, keyof AuditFields>> & { id: number }
