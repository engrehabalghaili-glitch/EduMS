export interface CreateSchoolFacilityMaintenanceLogPayload {
    schoolFacilityId: number;
    maintenanceCode: string;
    scheduledDate: string;
    completedDate?: string;
    maintenanceType: number;
    descriptionDetails: string;
    totalCostAmount: number;
    responsibleEmployeeId?: number;
    externalContractorName?: string;
    inspectionRemarks?: string;
}

export interface SchoolFacilityMaintenanceLog {
    id: number;
    schoolFacilityId: number;
    maintenanceCode: string;
    scheduledDate: string;
    completedDate?: string;
    maintenanceType: number;
    descriptionDetails: string;
    totalCostAmount: number;
    responsibleEmployeeId?: number;
    externalContractorName?: string;
    status: number;
    inspectionRemarks?: string;
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

export interface UpdateSchoolFacilityMaintenanceLogPayload {
    id?: number;
    schoolFacilityId?: number;
    maintenanceCode?: string;
    scheduledDate?: string;
    completedDate?: string;
    maintenanceType?: number;
    descriptionDetails?: string;
    totalCostAmount?: number;
    responsibleEmployeeId?: number;
    externalContractorName?: string;
    inspectionRemarks?: string;
}
