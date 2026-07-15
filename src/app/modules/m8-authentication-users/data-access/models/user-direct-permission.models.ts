export interface UserDirectPermission {
  id: number
  userId: number
  permissionId: number
  schoolId: number | null
  scopeOverride: string | null
  isActive: boolean
  startDate: string | null
  endDate: string | null
  grantedByUserId: number | null
  grantedAt: string | null
  reason: string | null
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateUserDirectPermission = Omit<UserDirectPermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateUserDirectPermission = Partial<CreateUserDirectPermission> & { id: number }
