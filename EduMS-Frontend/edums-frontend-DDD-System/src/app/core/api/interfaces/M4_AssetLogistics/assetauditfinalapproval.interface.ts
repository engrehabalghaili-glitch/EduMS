export interface AssetAuditFinalApproval {
    id: number;
    schoolId: number;
    inventoryPlanId?: number;
    complianceAuditId?: number;
    approvalType: number;
    approvalDate: string;
    approvedByUserId: number;
    approvalDocumentUrl?: string;
    summaryOfChanges?: string;
    systemStatusUpdated: boolean;
    statusUpdateDate?: string;
    statusUpdatedByUserId?: number;
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

export interface CreateAssetAuditFinalApprovalPayload {
    schoolId: number;
    inventoryPlanId?: number;
    complianceAuditId?: number;
    approvalType: number;
    approvalDate: string;
    approvedByUserId: number;
    approvalDocumentUrl?: string;
    summaryOfChanges?: string;
    systemStatusUpdated: boolean;
    statusUpdateDate?: string;
    statusUpdatedByUserId?: number;
    notes?: string;
}

export interface UpdateAssetAuditFinalApprovalPayload {
    id?: number;
    schoolId?: number;
    inventoryPlanId?: number;
    complianceAuditId?: number;
    approvalType?: number;
    approvalDate?: string;
    approvedByUserId?: number;
    approvalDocumentUrl?: string;
    summaryOfChanges?: string;
    systemStatusUpdated?: boolean;
    statusUpdateDate?: string;
    statusUpdatedByUserId?: number;
    notes?: string;
}
