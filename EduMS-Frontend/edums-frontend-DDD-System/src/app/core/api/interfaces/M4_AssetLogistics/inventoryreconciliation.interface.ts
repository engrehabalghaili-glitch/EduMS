export interface CreateInventoryReconciliationPayload {
    inventoryPlanId: number;
    schoolId: number;
    assetId: number;
    discrepancyType: number;
    systemLocationId?: number;
    actualLocationText?: string;
    systemCondition: number;
    actualCondition: number;
    reasonForDiscrepancy?: string;
    investigationNotes?: string;
    correctiveAction?: string;
    isResolved: boolean;
    resolutionDate?: string;
    resolvedByUserId?: number;
    resolutionNotes?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    reconciliationStatus: number;
    notes?: string;
}

export interface InventoryReconciliation {
    id: number;
    inventoryPlanId: number;
    schoolId: number;
    assetId: number;
    discrepancyType: number;
    systemLocationId?: number;
    actualLocationText?: string;
    systemCondition: number;
    actualCondition: number;
    reasonForDiscrepancy?: string;
    investigationNotes?: string;
    correctiveAction?: string;
    isResolved: boolean;
    resolutionDate?: string;
    resolvedByUserId?: number;
    resolutionNotes?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    reconciliationStatus: number;
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

export interface UpdateInventoryReconciliationPayload {
    id?: number;
    inventoryPlanId?: number;
    schoolId?: number;
    assetId?: number;
    discrepancyType?: number;
    systemLocationId?: number;
    actualLocationText?: string;
    systemCondition?: number;
    actualCondition?: number;
    reasonForDiscrepancy?: string;
    investigationNotes?: string;
    correctiveAction?: string;
    isResolved?: boolean;
    resolutionDate?: string;
    resolvedByUserId?: number;
    resolutionNotes?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    reconciliationStatus?: number;
    notes?: string;
}
