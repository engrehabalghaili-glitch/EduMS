export interface AccessPolicy {
  id: number
  schoolId: number | null
  policyCode: string
  policyNameAr: string
  policyNameEn: string | null
  policyType: 'صلاحية وصول' | 'تقييد' | 'استثناء'
  policyRuleJson: string | null
  policyEffect: 'سماح' | 'منع'
  priority: number
  appliesToType: string | null
  appliesToIdsJson: string | null
  isActive: boolean
  validFrom: string | null
  validTo: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateAccessPolicy = Omit<AccessPolicy, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateAccessPolicy = Partial<CreateAccessPolicy> & { id: number }
