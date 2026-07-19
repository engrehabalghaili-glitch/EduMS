export interface PermissionBaseModule {
  id: number
  moduleCode: string
  moduleNameAr: string
  moduleNameEn: string | null
  sectionCode: string | null
  sectionNameAr: string | null
  sectionNameEn: string | null
  description: string | null
  defaultPermissionsJson: string | null
  isActive: boolean
  sortOrder: number
  createdAt: string
  modifiedAt: string | null
}

export type CreatePermissionBaseModule = Omit<PermissionBaseModule, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdatePermissionBaseModule = Partial<CreatePermissionBaseModule> & { id: number }
