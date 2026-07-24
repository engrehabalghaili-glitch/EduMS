export interface SystemPermission {
  id: number
  permissionKey: string
  module: string
  subModule: string | null
  actionType: string | null
  permissionTypeId: number | null
  defaultScope: string | null
  nameAr: string
  nameEn: string | null
  descriptionAr: string | null
  riskLevel: 'منخفض' | 'متوسط' | 'عالي' | 'حرج' | null
  isSensitive: boolean
  requiresLogging: boolean
  conditionsJson: string | null
  isActive: boolean
  createdAt: string
  modifiedAt: string | null
}

export type CreateSystemPermission = Omit<SystemPermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateSystemPermission = Partial<CreateSystemPermission> & { id: number }
