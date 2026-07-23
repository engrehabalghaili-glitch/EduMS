export interface CreateEmergencyClosurePayload {
    schoolId: number;
    closureNumber: string;
    closureReason: string;
    decisionAuthority?: string;
    authorityDecisionNumber?: string;
    startDate: string;
    endDate?: string;
    actualEndDate?: string;
    totalClosureDays: number;
    schoolDaysAffected: number;
    alternativeEducationActivated: boolean;
    alternativeEducationType?: string;
    altEducationPlatform?: string;
    altEducationDetails?: string;
    wasCompensated: boolean;
    compensationRemediationPlanId?: number;
    parentNotificationSent: boolean;
    parentNotificationDate?: string;
    parentNotificationMethod?: string;
    closureStatus: number;
    notes?: string;
}

export interface EmergencyClosure {
    id: number;
    schoolId: number;
    closureNumber: string;
    closureReason: string;
    decisionAuthority?: string;
    authorityDecisionNumber?: string;
    startDate: string;
    endDate?: string;
    actualEndDate?: string;
    totalClosureDays: number;
    schoolDaysAffected: number;
    alternativeEducationActivated: boolean;
    alternativeEducationType?: string;
    altEducationPlatform?: string;
    altEducationDetails?: string;
    wasCompensated: boolean;
    compensationRemediationPlanId?: number;
    parentNotificationSent: boolean;
    parentNotificationDate?: string;
    parentNotificationMethod?: string;
    closureStatus: number;
    notes?: string;
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

export interface UpdateEmergencyClosurePayload {
    id?: number;
    schoolId?: number;
    closureNumber?: string;
    closureReason?: string;
    decisionAuthority?: string;
    authorityDecisionNumber?: string;
    startDate?: string;
    endDate?: string;
    actualEndDate?: string;
    totalClosureDays?: number;
    schoolDaysAffected?: number;
    alternativeEducationActivated?: boolean;
    alternativeEducationType?: string;
    altEducationPlatform?: string;
    altEducationDetails?: string;
    wasCompensated?: boolean;
    compensationRemediationPlanId?: number;
    parentNotificationSent?: boolean;
    parentNotificationDate?: string;
    parentNotificationMethod?: string;
    closureStatus?: number;
    notes?: string;
}
