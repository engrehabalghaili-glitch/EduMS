export interface AssetRevaluationImpairment {
    id: number;
    assetId: number;
    schoolId: number;
    operationType: number;
    effectiveDate: string;
    oldBookValue: number;
    oldAccumulatedDepreciation: number;
    oldNetBookValue: number;
    newValue: number;
    newNetBookValue: number;
    differenceAmount: number;
    differenceType: number;
    valuationFirmName?: string;
    valuationReportNumber?: string;
    valuationReportDate?: string;
    reason?: string;
    attachmentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    operationStatus: number;
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

export interface CreateAssetRevaluationImpairmentPayload {
    assetId: number;
    schoolId: number;
    operationType: number;
    effectiveDate: string;
    oldBookValue: number;
    oldAccumulatedDepreciation: number;
    oldNetBookValue: number;
    newValue: number;
    newNetBookValue: number;
    differenceAmount: number;
    differenceType: number;
    valuationFirmName?: string;
    valuationReportNumber?: string;
    valuationReportDate?: string;
    reason?: string;
    attachmentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    operationStatus: number;
    notes?: string;
}

export interface UpdateAssetRevaluationImpairmentPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    operationType?: number;
    effectiveDate?: string;
    oldBookValue?: number;
    oldAccumulatedDepreciation?: number;
    oldNetBookValue?: number;
    newValue?: number;
    newNetBookValue?: number;
    differenceAmount?: number;
    differenceType?: number;
    valuationFirmName?: string;
    valuationReportNumber?: string;
    valuationReportDate?: string;
    reason?: string;
    attachmentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    operationStatus?: number;
    notes?: string;
}
