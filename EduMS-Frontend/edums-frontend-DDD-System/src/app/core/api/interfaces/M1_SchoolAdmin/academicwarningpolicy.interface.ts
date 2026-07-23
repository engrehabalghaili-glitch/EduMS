export interface AcademicWarningPolicy {
    id: number;
    schoolId: number;
    policyCode: string;
    policyTitleAr: string;
    warningCategory: number;
    thresholdValue: number;
    actionRequired: number;
    policyTitleEn?: string;
    consecutiveOccurrenceLimit: number;
    autoTriggerNotification: boolean;
    escalationPolicyId?: number;
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

export interface CreateAcademicWarningPolicyPayload {
    schoolId: number;
    policyCode: string;
    policyTitleAr: string;
    warningCategory: number;
    thresholdValue: number;
    actionRequired: number;
    policyTitleEn?: string;
    consecutiveOccurrenceLimit: number;
    autoTriggerNotification: boolean;
    escalationPolicyId?: number;
}

export interface UpdateAcademicWarningPolicyPayload {
    id?: number;
    policyCode?: string;
    policyTitleAr?: string;
    warningCategory?: number;
    thresholdValue?: number;
    actionRequired?: number;
    policyTitleEn?: string;
    consecutiveOccurrenceLimit?: number;
    autoTriggerNotification?: boolean;
    escalationPolicyId?: number;
}
