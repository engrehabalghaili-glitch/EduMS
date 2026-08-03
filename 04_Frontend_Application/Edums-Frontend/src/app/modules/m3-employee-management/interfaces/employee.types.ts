import type { AuditFields, OrganizationalScope, ActiveStatus, VerificationStatus } from './shared.types'

export type WorkLocationType = 'داخل_المدرسة' | 'خارج_المدرسة' | 'ميداني'
export type NationalIdType = 'رقم_وطني' | 'جواز_سفر' | 'إقامة' | 'بطاقة_عائلية'
export type MaritalStatus = 'أعزب' | 'متزوج' | 'مطلق' | 'أرمل'
export type ContractType = 'دوام_كامل' | 'دوام_جزئي' | 'مؤقت' | 'موسمي'
export type EmployeeType = 'إداري' | 'تعليمي' | 'فني' | 'مشرف'
export type EmploymentStatus = 'نشط' | 'موقوف' | 'منتهي' | 'إجازة'
export type BloodType = 'A+' | 'A-' | 'B+' | 'B-' | 'O+' | 'O-' | 'AB+' | 'AB-'

export interface EmployeeData {
  employeeCode: string
  nationalIdNumber: string
  nationalIdType: NationalIdType
  nationalIdExpiryDate: string | null
  passportExpiryDate: string | null
  residenceNumber: string | null
  residenceExpiryDate: string | null
  residenceSponsorName: string | null
  firstNameAr: string
  fatherNameAr: string
  grandfatherNameAr: string
  familyNameAr: string
  firstNameEn: string | null
  familyNameEn: string | null
  birthDate: string
  nationality: string | null
  maritalStatus: MaritalStatus
  numberOfDependents: number
  emergencyContactName: string | null
  emergencyContactPhone: string | null
  bloodType: BloodType | null
  hasSpecialNeeds: boolean
  phonePrimary: string
  phoneSecondary: string | null
  personalEmail: string | null
  officialEmail: string
  fullAddress: string | null
  city: string | null
  profilePhotoUrl: string | null
  contractType: ContractType
  employeeType: EmployeeType
  departmentId: number | null
  jobTitle: string
  jobGrade: string | null
  specialization: string | null
  academicQualification: string | null
  qualificationSource: string | null
  experienceYears: number
  hireDate: string
  startDate: string
  endDate: string | null
  employmentStatus: EmploymentStatus
  isActive: boolean
  canLogin: boolean
  portalUsername: string | null
  lastLoginDate: string | null
  twoFactorEnabled: boolean
  bankName: string | null
  bankIban: string | null
  verificationStatus: VerificationStatus
  notes: string | null
}

export interface Employee extends AuditFields, OrganizationalScope, EmployeeData {
  workLocationType: WorkLocationType
}

export type CreateEmployee = Omit<Employee, keyof AuditFields | keyof OrganizationalScope | 'workLocationType'> & {
  schoolId?: number | null
  directorateId?: number | null
  organizationalSectorId?: number | null
  workLocationType?: WorkLocationType
}

export type UpdateEmployee = Partial<CreateEmployee> & { id: number }
