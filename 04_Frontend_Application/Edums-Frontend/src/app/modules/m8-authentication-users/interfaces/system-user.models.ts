export interface SystemUser {
  id: number
  schoolId: number | null
  officeId: number | null
  username: string
  mustChangePassword: boolean
  failedAttempts: number
  lastFailedAttemptDate: string | null
  isLocked: boolean
  lockReason: string | null
  lockExpiryDate: string | null
  isActive: boolean
  activationDate: string | null
  deactivationDate: string | null
  deactivationReason: string | null
  fullNameAr: string
  fullNameEn: string | null
  nationalId: string
  email: string
  emailVerified: boolean
  emailVerifiedAt: string | null
  phone: string | null
  phoneVerified: boolean
  phoneVerifiedAt: string | null
  userType: 'مدير النظام' | 'مدير مدرسة' | 'موظف' | 'معلم' | 'طالب' | 'ولي أمر' | 'مشرف'
  employeeId: number | null
  studentId: number | null
  guardianId: number | null
  twoFactorEnabled: boolean
  twoFactorMethod: 'لا يوجد' | 'بريد إلكتروني' | 'رسالة نصية' | 'تطبيق مصادقة'
  lastLoginDate: string | null
  lastLoginIp: string | null
  lastLoginDevice: string | null
  lastLoginUserAgent: string | null
  previousLoginDate: string | null
  preferredLanguage: string | null
  timezone: string | null
  dateFormat: string | null
  theme: string | null
  profilePictureUrl: string | null
  signatureImageUrl: string | null
  notificationPreferencesJson: string | null
  dashboardLayoutJson: string | null
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateSystemUser = Omit<SystemUser, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateSystemUser = Partial<CreateSystemUser> & { id: number }
