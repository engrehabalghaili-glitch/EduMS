export interface RolePermission {
  id: number
  roleId: number
  permissionId: number
  scopeOverride: string | null
  isInherited: boolean
  inheritedFromRoleId: number | null
  isActive: boolean
  startDate: string | null
  endDate: string | null
  grantedByUserId: number | null
  grantedAt: string | null
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateRolePermission = Omit<RolePermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateRolePermission = Partial<CreateRolePermission> & { id: number }
