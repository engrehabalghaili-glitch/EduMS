import type { AuditFields, OrganizationalScope } from './shared.types'

export type VacancyStatus = 'معلنة' | 'قيد_التعبئة' | 'ملغاة' | 'مكتملة'

export interface VacantPositionData {
  positionCode: string
  positionTitleAr: string
  positionTitleEn: string | null
  departmentId: number | null
  employeeType: number
  requiredQualification: string | null
  experienceRequiredYears: number
  salaryRangeMin: number
  salaryRangeMax: number
  vacancyStatus: VacancyStatus
  postingDate: string
  closingDate: string | null
  specialRequirements: string | null
  notes: string | null
}

export interface VacantPosition extends AuditFields, OrganizationalScope, VacantPositionData {}

export type CreateVacantPosition = Omit<VacantPosition, keyof AuditFields>

export type UpdateVacantPosition = Partial<Omit<VacantPosition, keyof AuditFields>> & { id: number }
