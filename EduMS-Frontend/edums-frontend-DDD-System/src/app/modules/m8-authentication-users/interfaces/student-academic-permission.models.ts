export interface StudentAcademicPermission {
  id: number
  schoolId: number
  permissionKey: string
  permissionNameAr: string
  permissionNameEn: string | null
  category: string | null
  isTimeBound: boolean
  allowedWindowDays: string | null
  requiresLockOverride: boolean
  requiresSupervisorApproval: boolean
  allowedRolesJson: string | null
  isActive: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateStudentAcademicPermission = Omit<StudentAcademicPermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateStudentAcademicPermission = Partial<CreateStudentAcademicPermission> & { id: number }
