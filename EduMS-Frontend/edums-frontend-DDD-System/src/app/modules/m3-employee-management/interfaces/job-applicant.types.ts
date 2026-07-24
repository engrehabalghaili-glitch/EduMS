import type { AuditFields } from './shared.types'

export type ApplicationStatus = 'مستلمة' | 'قيد_المراجعة' | 'مدعو_لمقابلة' | 'مقبول' | 'مرفوض'

export interface JobApplicantData {
  vacantPositionId: number
  applicantFullNameAr: string
  applicantFullNameEn: string | null
  nationalIdNumber: string
  phonePrimary: string
  emailAddress: string
  academicQualification: string
  qualificationSource: string | null
  experienceYears: number
  cvDocumentUrl: string | null
  coverLetterUrl: string | null
  applicationStatus: ApplicationStatus
  interviewDate: string | null
  interviewNotes: string | null
  rejectionReason: string | null
  reviewedByEmployeeId: number | null
  notes: string | null
}

export interface JobApplicant extends AuditFields, JobApplicantData {}

export type CreateJobApplicant = Omit<JobApplicant, keyof AuditFields>

export type UpdateJobApplicant = Partial<Omit<JobApplicant, keyof AuditFields>> & { id: number }
