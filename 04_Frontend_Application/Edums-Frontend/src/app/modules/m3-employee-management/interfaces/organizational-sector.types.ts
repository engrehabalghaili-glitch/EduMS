import type { AuditFields } from './shared.types'

export type SectorType = 'إدارة_عامة' | 'إدارة_تعليم' | 'مدرسة' | 'قسم' | 'وحدة'

export interface OrganizationalSectorData {
  sectorCode: string
  sectorNameAr: string
  sectorNameEn: string | null
  sectorType: SectorType
  parentSectorId: number | null
  directorateId: number | null
  schoolId: number | null
  costCenterCode: string | null
  annualHrBudget: number
  headOfSectorEmployeeId: number | null
  isActive: boolean
  notes: string | null
}

export interface OrganizationalSector extends AuditFields, OrganizationalSectorData {}

export type CreateOrganizationalSector = Omit<OrganizationalSector, keyof AuditFields>

export type UpdateOrganizationalSector = Partial<Omit<OrganizationalSector, keyof AuditFields>> & { id: number }
