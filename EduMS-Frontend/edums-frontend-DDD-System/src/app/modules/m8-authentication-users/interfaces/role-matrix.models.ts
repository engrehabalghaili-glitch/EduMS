export interface RoleMatrix {
  id: number
  schoolId: number | null
  roleCode: string
  roleNameAr: string
  roleNameEn: string | null
  roleType: 'إدارة نظام' | 'إدارة مدرسة' | 'تعليمي' | 'طلابي' | 'مالي' | 'مكتب'
  permissionsJson: string | null
  descriptionAr: string | null
  isActive: boolean
  sortOrder: number
  createdAt: string
  modifiedAt: string | null
}

export type CreateRoleMatrix = Omit<RoleMatrix, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateRoleMatrix = Partial<CreateRoleMatrix> & { id: number }
