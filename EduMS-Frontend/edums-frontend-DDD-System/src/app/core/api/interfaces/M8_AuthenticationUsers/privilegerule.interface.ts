export interface CreatePrivilegeRulePayload {
    schoolId?: number;
    ruleCode: string;
    ruleNameAr: string;
    ruleNameEn?: string;
    ruleCategory?: string;
    appliesToType?: string;
    conditionJson?: string;
    triggerAction?: string;
    actionParametersJson?: string;
    priority: number;
    isActive: boolean;
}

export interface PrivilegeRule {
    id: number;
    schoolId?: number;
    ruleCode: string;
    ruleNameAr: string;
    ruleNameEn?: string;
    ruleCategory?: string;
    appliesToType?: string;
    conditionJson?: string;
    triggerAction?: string;
    actionParametersJson?: string;
    priority: number;
    isActive: boolean;
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

export interface UpdatePrivilegeRulePayload {
    id?: number;
    schoolId?: number;
    ruleCode?: string;
    ruleNameAr?: string;
    ruleNameEn?: string;
    ruleCategory?: string;
    appliesToType?: string;
    conditionJson?: string;
    triggerAction?: string;
    actionParametersJson?: string;
    priority?: number;
    isActive?: boolean;
}
