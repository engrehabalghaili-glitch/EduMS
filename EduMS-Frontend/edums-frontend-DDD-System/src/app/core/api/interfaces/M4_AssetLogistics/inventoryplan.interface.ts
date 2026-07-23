export interface CreateInventoryPlanPayload {
    schoolId: number;
    planNumber: string;
    planNameAr: string;
    inventoryType: number;
    scopeType: number;
    scopeValueId?: number;
    startDate: string;
    targetEndDate?: string;
    actualEndDate?: string;
    teamLeaderEmployeeId?: number;
    assignedTeamMembersJson?: string;
    instructions?: string;
    planStatus: number;
    completionPercentage: number;
    notes?: string;
}

export interface InventoryPlan {
    id: number;
    schoolId: number;
    planNumber: string;
    planNameAr: string;
    inventoryType: number;
    scopeType: number;
    scopeValueId?: number;
    startDate: string;
    targetEndDate?: string;
    actualEndDate?: string;
    teamLeaderEmployeeId?: number;
    assignedTeamMembersJson?: string;
    instructions?: string;
    planStatus: number;
    completionPercentage: number;
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

export interface UpdateInventoryPlanPayload {
    id?: number;
    schoolId?: number;
    planNumber?: string;
    planNameAr?: string;
    inventoryType?: number;
    scopeType?: number;
    scopeValueId?: number;
    startDate?: string;
    targetEndDate?: string;
    actualEndDate?: string;
    teamLeaderEmployeeId?: number;
    assignedTeamMembersJson?: string;
    instructions?: string;
    planStatus?: number;
    completionPercentage?: number;
    notes?: string;
}
