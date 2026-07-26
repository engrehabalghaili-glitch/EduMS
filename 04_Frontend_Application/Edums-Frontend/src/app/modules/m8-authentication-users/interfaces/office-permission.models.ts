export interface OfficePermission {
  id: number
  officeId: number
  permissionKey: string
  permissionNameAr: string
  permissionNameEn: string | null
  scopeType: string | null
  scopeTargetJson: string | null
  canOverrideSchoolDecision: boolean
  isReadOnly: boolean
  allowedRolesJson: string | null
  isActive: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateOfficePermission = Omit<OfficePermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateOfficePermission = Partial<CreateOfficePermission> & { id: number }
