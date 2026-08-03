export type AuditFields = {
  id: number
  createdAt: string
  createdByUserId: number
  modifiedAt: string | null
  modifiedByUserId: number | null
}

export type OrganizationalScope = {
  schoolId: number | null
  directorateId: number | null
  organizationalSectorId: number | null
}

export type AcademicScope = OrganizationalScope & {
  schoolAcademicYearId: number | null
  schoolSemesterId: number | null
}

export type ApprovalStatus = 'قيد_الانتظار' | 'معتمد' | 'مرفوض' | 'ملغي'

export type ActiveStatus = 'نشط' | 'غير_نشط'

export type PaymentStatus = 'غير_مدفوع' | 'مدفوع' | 'قيد_المعالجة' | 'مؤجل'

export type VerificationStatus = 'غير_موثق' | 'موثق' | 'قيد_التحقق'
