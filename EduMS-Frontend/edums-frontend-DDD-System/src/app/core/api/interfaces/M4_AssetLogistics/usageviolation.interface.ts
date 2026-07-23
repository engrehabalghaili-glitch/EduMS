export interface CreateUsageViolationPayload {
    schoolId: number;
    assetId: number;
    violationType: string;
    violationDate: string;
    reportedByUserId: number;
    reportedDate: string;
    violatingUserId: number;
    description: string;
    evidenceJson?: string;
    penaltyAction?: string;
    penaltyAmount: number;
    penaltyAmountCurrency?: string;
    deductionFromSalary: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    status: string;
    closedAt?: string;
    notes?: string;
}

export interface UpdateUsageViolationPayload {
    id?: number;
    schoolId?: number;
    assetId?: number;
    violationType?: string;
    violationDate?: string;
    reportedByUserId?: number;
    reportedDate?: string;
    violatingUserId?: number;
    description?: string;
    evidenceJson?: string;
    penaltyAction?: string;
    penaltyAmount?: number;
    penaltyAmountCurrency?: string;
    deductionFromSalary?: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    status?: string;
    closedAt?: string;
    notes?: string;
}

export interface UsageViolation {
    id: number;
    schoolId: number;
    assetId: number;
    violationType: string;
    violationDate: string;
    reportedByUserId: number;
    reportedDate: string;
    violatingUserId: number;
    description: string;
    evidenceJson?: string;
    penaltyAction?: string;
    penaltyAmount: number;
    penaltyAmountCurrency?: string;
    deductionFromSalary: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    status: string;
    closedAt?: string;
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
