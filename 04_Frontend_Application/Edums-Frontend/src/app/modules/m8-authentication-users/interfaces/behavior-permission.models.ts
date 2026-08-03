export interface BehaviorPermission {
  id: number
  schoolId: number
  permissionKey: string
  permissionNameAr: string
  permissionNameEn: string | null
  category: string | null
  isConfidential: boolean
  requiresSocialWorkerRole: boolean
  allowedRolesJson: string | null
  isActive: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateBehaviorPermission = Omit<BehaviorPermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateBehaviorPermission = Partial<CreateBehaviorPermission> & { id: number }
