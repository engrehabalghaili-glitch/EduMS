export interface AccessPolicy {
    id: number;
    schoolId?: number;
    policyCode: string;
    policyNameAr: string;
    policyNameEn?: string;
    policyType: number;
    policyRuleJson?: string;
    policyEffect: number;
    priority: number;
    appliesToType?: string;
    appliesToIdsJson?: string;
    isActive: boolean;
    validFrom?: string;
    validTo?: string;
    createdAt: string;
    createdByUserId: number;
    modifiedAt?: string;
    modifiedByUserId?: number;
    isDeleted: boolean;
    deletedAt?: string;
    deletedByUserId?: number;
    versionToken: string;
    lastSyncedAt?: string;
    syncStatus: string;
}

export interface CreateAccessPolicyPayload {
    schoolId?: number;
    policyCode: string;
    policyNameAr: string;
    policyNameEn?: string;
    policyType: number;
    policyRuleJson?: string;
    policyEffect: number;
    priority: number;
    appliesToType?: string;
    appliesToIdsJson?: string;
    isActive: boolean;
    validFrom?: string;
    validTo?: string;
}

export interface UpdateAccessPolicyPayload {
    id?: number;
    schoolId?: number;
    policyCode?: string;
    policyNameAr?: string;
    policyNameEn?: string;
    policyType?: number;
    policyRuleJson?: string;
    policyEffect?: number;
    priority?: number;
    appliesToType?: string;
    appliesToIdsJson?: string;
    isActive?: boolean;
    validFrom?: string;
    validTo?: string;
}
