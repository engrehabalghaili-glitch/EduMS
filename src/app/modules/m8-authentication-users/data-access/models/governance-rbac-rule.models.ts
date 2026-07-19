export interface GovernanceRbacRule {
  id: number
  roleId: number
  targetRoleId: number | null
  targetPermissionId: number | null
  allowedAction: 'إضافة' | 'تعديل' | 'حذف' | 'عرض' | 'تفويض' | 'اعتماد'
  canDelegate: boolean
  approvalRequired: boolean
  approvalRoleId: number | null
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateGovernanceRbacRule = Omit<GovernanceRbacRule, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateGovernanceRbacRule = Partial<CreateGovernanceRbacRule> & { id: number }
