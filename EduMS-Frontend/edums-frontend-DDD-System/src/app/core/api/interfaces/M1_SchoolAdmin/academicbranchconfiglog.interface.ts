export interface AcademicBranchConfigLog {
    id: number;
    schoolId: number;
    configKey: string;
    configValue: string;
    previousValue?: string;
    changeReason?: string;
    effectiveDate: string;
    configCategory: number;
    modifiedByEmployeeId?: number;
    requiresSupervisoryApproval: boolean;
    approvalStatus: number;
    isActive: boolean;
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

export interface CreateAcademicBranchConfigLogPayload {
    schoolId: number;
    configKey: string;
    configValue: string;
    changeReason?: string;
    configCategory: number;
    requiresSupervisoryApproval: boolean;
}

export interface UpdateAcademicBranchConfigLogPayload {
    id?: number;
    configValue?: string;
    changeReason?: string;
    configCategory?: number;
    requiresSupervisoryApproval?: boolean;
}
