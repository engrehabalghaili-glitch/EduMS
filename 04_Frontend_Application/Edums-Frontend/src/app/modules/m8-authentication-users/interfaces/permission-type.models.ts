export interface PermissionType {
  id: number
  typeCode: string
  typeNameAr: string
  typeNameEn: string | null
  category: string | null
  scopeType: string | null
  riskLevel: 'منخفض' | 'متوسط' | 'عالي' | 'حرج' | null
  requiresApproval: boolean
  approvalLevel: string | null
  descriptionAr: string | null
  isActive: boolean
  isSystem: boolean
  sortOrder: number
  createdAt: string
  modifiedAt: string | null
}

export type CreatePermissionType = Omit<PermissionType, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdatePermissionType = Partial<CreatePermissionType> & { id: number }
