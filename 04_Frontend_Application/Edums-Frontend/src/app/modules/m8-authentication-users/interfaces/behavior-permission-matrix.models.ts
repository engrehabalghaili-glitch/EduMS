export interface BehaviorPermissionMatrix {
  id: number
  schoolId: number
  roleId: number
  behaviorLevel: 'بسيط' | 'متوسط' | 'شديد' | 'خطير'
  canRecord: boolean
  canInvestigate: boolean
  canDecidePenalty: boolean
  canExecutePenalty: boolean
  canWaivePenalty: boolean
  requiresCommitteeDecision: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateBehaviorPermissionMatrix = Omit<BehaviorPermissionMatrix, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateBehaviorPermissionMatrix = Partial<CreateBehaviorPermissionMatrix> & { id: number }
