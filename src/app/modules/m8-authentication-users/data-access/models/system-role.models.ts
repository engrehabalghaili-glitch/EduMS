export interface SystemRole {
  id: number
  roleCode: string
  roleNameAr: string
  roleNameEn: string | null
  roleType: 'إدارة نظام' | 'إدارة مدرسة' | 'تعليمي' | 'طلابي' | 'مالي'
  hierarchyLevel: number
  parentRoleId: number | null
  isInheritable: boolean
  isAssignable: boolean
  isSystem: boolean
  isActive: boolean
  descriptionAr: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateSystemRole = Omit<SystemRole, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateSystemRole = Partial<CreateSystemRole> & { id: number }
