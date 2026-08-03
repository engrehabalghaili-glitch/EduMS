export interface PrivilegeRule {
  id: number
  schoolId: number | null
  ruleCode: string
  ruleNameAr: string
  ruleNameEn: string | null
  ruleCategory: string | null
  appliesToType: string | null
  conditionJson: string | null
  triggerAction: string | null
  actionParametersJson: string | null
  priority: number
  isActive: boolean
  createdAt: string
  modifiedAt: string | null
}

export type CreatePrivilegeRule = Omit<PrivilegeRule, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdatePrivilegeRule = Partial<CreatePrivilegeRule> & { id: number }
