export interface AssetSuspensionRequest {
    id: number;
    schoolId: number;
    requestNumber: number;
    assetId: number;
    requestedByUserId: number;
    requestDate: string;
    reason: string;
    reasonDetails?: string;
    startDate: string;
    expectedEndDate?: string;
    attachmentsJson?: string;
    approvalStatus: string;
    approvedByUserId?: number;
    approvalDate?: string;
    approvalNotes?: string;
    rejectionReason?: string;
    isRevoked: boolean;
    revokeDate?: string;
    revokeReason?: string;
    revokedByUserId?: number;
    actualEndDate?: string;
    status: string;
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

export interface CreateAssetSuspensionRequestPayload {
    schoolId: number;
    requestNumber: number;
    assetId: number;
    requestedByUserId: number;
    requestDate: string;
    reason: string;
    reasonDetails?: string;
    startDate: string;
    expectedEndDate?: string;
    attachmentsJson?: string;
    approvalStatus: string;
    approvedByUserId?: number;
    approvalDate?: string;
    approvalNotes?: string;
    rejectionReason?: string;
    isRevoked: boolean;
    revokeDate?: string;
    revokeReason?: string;
    revokedByUserId?: number;
    actualEndDate?: string;
    status: string;
    notes?: string;
}

export interface UpdateAssetSuspensionRequestPayload {
    id?: number;
    schoolId?: number;
    requestNumber?: number;
    assetId?: number;
    requestedByUserId?: number;
    requestDate?: string;
    reason?: string;
    reasonDetails?: string;
    startDate?: string;
    expectedEndDate?: string;
    attachmentsJson?: string;
    approvalStatus?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    approvalNotes?: string;
    rejectionReason?: string;
    isRevoked?: boolean;
    revokeDate?: string;
    revokeReason?: string;
    revokedByUserId?: number;
    actualEndDate?: string;
    status?: string;
    notes?: string;
}
