export interface AssetMaintenanceTicket {
    id: number;
    schoolId: number;
    ticketNumber: string;
    assetId: number;
    reportedByUserId: number;
    reportDate: string;
    issueType: number;
    severityLevel: number;
    issueDescriptionText: string;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    diagnosis?: string;
    estimatedCost: number;
    estimatedCompletionDate?: string;
    actualCompletionDate?: string;
    resolutionDetails?: string;
    resolutionCost: number;
    ticketStatus: number;
    closedByUserId?: number;
    closedAt?: string;
    attachmentsJson?: string;
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

export interface CreateAssetMaintenanceTicketPayload {
    schoolId: number;
    ticketNumber: string;
    assetId: number;
    reportedByUserId: number;
    reportDate: string;
    issueType: number;
    severityLevel: number;
    issueDescriptionText: string;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    diagnosis?: string;
    estimatedCost: number;
    estimatedCompletionDate?: string;
    actualCompletionDate?: string;
    resolutionDetails?: string;
    resolutionCost: number;
    ticketStatus: number;
    closedByUserId?: number;
    closedAt?: string;
    attachmentsJson?: string;
    notes?: string;
}

export interface UpdateAssetMaintenanceTicketPayload {
    id?: number;
    schoolId?: number;
    ticketNumber?: string;
    assetId?: number;
    reportedByUserId?: number;
    reportDate?: string;
    issueType?: number;
    severityLevel?: number;
    issueDescriptionText?: string;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    diagnosis?: string;
    estimatedCost?: number;
    estimatedCompletionDate?: string;
    actualCompletionDate?: string;
    resolutionDetails?: string;
    resolutionCost?: number;
    ticketStatus?: number;
    closedByUserId?: number;
    closedAt?: string;
    attachmentsJson?: string;
    notes?: string;
}
