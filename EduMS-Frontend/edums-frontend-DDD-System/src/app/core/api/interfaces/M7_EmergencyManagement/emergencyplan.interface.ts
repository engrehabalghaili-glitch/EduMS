export interface CreateEmergencyPlanPayload {
    schoolId: number;
    planCode: string;
    planTitleAr: string;
    planTitleEn: string;
    evacuationProcedureSummary: string;
    nextScheduledDrillDate: string;
    isActive: boolean;
}

export interface EmergencyPlan {
    id: number;
    schoolId: number;
    planCode: string;
    planTitleAr: string;
    planTitleEn: string;
    evacuationProcedureSummary: string;
    nextScheduledDrillDate: string;
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

export interface UpdateEmergencyPlanPayload {
    id?: number;
    schoolId?: number;
    planCode?: string;
    planTitleAr?: string;
    planTitleEn?: string;
    evacuationProcedureSummary?: string;
    nextScheduledDrillDate?: string;
    isActive?: boolean;
}
