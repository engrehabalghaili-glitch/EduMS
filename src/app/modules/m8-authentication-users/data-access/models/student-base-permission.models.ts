export interface StudentBasePermission {
  id: number
  schoolId: number
  permissionKey: string
  permissionNameAr: string
  permissionNameEn: string | null
  category: string | null
  requiresPrincipalApproval: boolean
  requiresGuardianConsent: boolean
  isSensitive: boolean
  allowedRolesJson: string | null
  isActive: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateStudentBasePermission = Omit<StudentBasePermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateStudentBasePermission = Partial<CreateStudentBasePermission> & { id: number }
