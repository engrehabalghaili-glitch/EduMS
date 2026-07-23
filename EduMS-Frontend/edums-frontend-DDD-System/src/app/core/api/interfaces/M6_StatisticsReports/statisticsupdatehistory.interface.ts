export interface CreateStatisticsUpdateHistoryPayload {
    statisticsDraftId?: number;
    submittedStatisticsId?: number;
    schoolId: number;
    changeType: string;
    changeCategory: string;
    oldValue?: string;
    newValue?: string;
    changeDate: string;
    updateReason?: string;
    supportingDocumentUrl?: string;
    changedByUserId?: number;
    isApproved: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface StatisticsUpdateHistory {
    id: number;
    statisticsDraftId?: number;
    submittedStatisticsId?: number;
    schoolId: number;
    changeType: string;
    changeCategory: string;
    oldValue?: string;
    newValue?: string;
    changeDate: string;
    updateReason?: string;
    supportingDocumentUrl?: string;
    changedByUserId?: number;
    isApproved: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface UpdateStatisticsUpdateHistoryPayload {
    id?: number;
    statisticsDraftId?: number;
    submittedStatisticsId?: number;
    schoolId?: number;
    changeType?: string;
    changeCategory?: string;
    oldValue?: string;
    newValue?: string;
    changeDate?: string;
    updateReason?: string;
    supportingDocumentUrl?: string;
    changedByUserId?: number;
    isApproved?: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
