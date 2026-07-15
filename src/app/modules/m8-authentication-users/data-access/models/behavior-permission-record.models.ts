export interface BehaviorPermissionRecord {
  id: number
  schoolId: number | null
  roleId: number | null
  category: string
  subCategory: string | null
  permissionKey: string
  allowedActionsJson: string | null
  scope: string | null
  isSensitive: boolean
  requiresJustification: boolean
  justificationApprovalRequired: boolean
  descriptionAr: string | null
  isActive: boolean
  createdAt: string
  modifiedAt: string | null
}

export type CreateBehaviorPermissionRecord = Omit<BehaviorPermissionRecord, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateBehaviorPermissionRecord = Partial<CreateBehaviorPermissionRecord> & { id: number }
