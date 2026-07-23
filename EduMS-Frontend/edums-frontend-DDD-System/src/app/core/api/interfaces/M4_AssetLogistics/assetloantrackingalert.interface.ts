export interface AssetLoanTrackingAlert {
    id: number;
    loanId: number;
    schoolId: number;
    alertType: number;
    alertDate: string;
    alertMessageText: string;
    deliveryMethod: number;
    isSent: boolean;
    sentToContact?: string;
    isAcknowledged: boolean;
    acknowledgedAt?: string;
    violationRecorded: boolean;
    violationId?: number;
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

export interface CreateAssetLoanTrackingAlertPayload {
    loanId: number;
    schoolId: number;
    alertType: number;
    alertDate: string;
    alertMessageText: string;
    deliveryMethod: number;
    isSent: boolean;
    sentToContact?: string;
    isAcknowledged: boolean;
    acknowledgedAt?: string;
    violationRecorded: boolean;
    violationId?: number;
    notes?: string;
}

export interface UpdateAssetLoanTrackingAlertPayload {
    id?: number;
    loanId?: number;
    schoolId?: number;
    alertType?: number;
    alertDate?: string;
    alertMessageText?: string;
    deliveryMethod?: number;
    isSent?: boolean;
    sentToContact?: string;
    isAcknowledged?: boolean;
    acknowledgedAt?: string;
    violationRecorded?: boolean;
    violationId?: number;
    notes?: string;
}
