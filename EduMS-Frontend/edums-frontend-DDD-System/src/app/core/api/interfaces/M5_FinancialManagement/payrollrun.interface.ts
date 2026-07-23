export interface CreatePayrollRunPayload {
    runNumber: string;
    month: number;
    year: number;
    processDate: string;
    description: string;
    status: number;
}

export interface PayrollRun {
    id: number;
    runNumber: string;
    month: number;
    year: number;
    processDate: string;
    description: string;
    status: number;
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

export interface UpdatePayrollRunPayload {
    id?: number;
    runNumber?: string;
    month?: number;
    year?: number;
    processDate?: string;
    description?: string;
    status?: number;
}
