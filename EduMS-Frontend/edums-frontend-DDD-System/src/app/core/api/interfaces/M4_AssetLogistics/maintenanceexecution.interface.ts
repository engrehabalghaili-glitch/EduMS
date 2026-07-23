export interface CreateMaintenanceExecutionPayload {
    schoolId: number;
    executionNumber: string;
    maintenanceTicketId?: number;
    preventiveScheduleId?: number;
    assetId: number;
    executionType: number;
    startDateTime: string;
    endDateTime?: string;
    executedByEmployeeId: number;
    workPerformedDescription: string;
    sparePartsUsedJson?: string;
    maintenanceCost: number;
    isOperationalAfterMaintenance: boolean;
    newAssetStatusId?: number;
    resolutionSummary?: string;
    attachmentsJson?: string;
    executionStatus: number;
    notes?: string;
}

export interface MaintenanceExecution {
    id: number;
    schoolId: number;
    executionNumber: string;
    maintenanceTicketId?: number;
    preventiveScheduleId?: number;
    assetId: number;
    executionType: number;
    startDateTime: string;
    endDateTime?: string;
    executedByEmployeeId: number;
    workPerformedDescription: string;
    sparePartsUsedJson?: string;
    maintenanceCost: number;
    isOperationalAfterMaintenance: boolean;
    newAssetStatusId?: number;
    resolutionSummary?: string;
    attachmentsJson?: string;
    executionStatus: number;
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

export interface UpdateMaintenanceExecutionPayload {
    id?: number;
    schoolId?: number;
    executionNumber?: string;
    maintenanceTicketId?: number;
    preventiveScheduleId?: number;
    assetId?: number;
    executionType?: number;
    startDateTime?: string;
    endDateTime?: string;
    executedByEmployeeId?: number;
    workPerformedDescription?: string;
    sparePartsUsedJson?: string;
    maintenanceCost?: number;
    isOperationalAfterMaintenance?: boolean;
    newAssetStatusId?: number;
    resolutionSummary?: string;
    attachmentsJson?: string;
    executionStatus?: number;
    notes?: string;
}
