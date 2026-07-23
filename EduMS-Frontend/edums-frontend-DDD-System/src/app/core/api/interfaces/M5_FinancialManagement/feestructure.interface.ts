export interface CreateFeeStructurePayload {
    schoolId: number;
    feeCode: string;
    feeNameAr: string;
    feeNameEn: string;
    gradeLevel: number;
    amount: number;
    academicYear: string;
}

export interface FeeStructure {
    id: number;
    schoolId: number;
    feeCode: string;
    feeNameAr: string;
    feeNameEn: string;
    gradeLevel: number;
    amount: number;
    academicYear: string;
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

export interface UpdateFeeStructurePayload {
    id?: number;
    schoolId?: number;
    feeCode?: string;
    feeNameAr?: string;
    feeNameEn?: string;
    gradeLevel?: number;
    amount?: number;
    academicYear?: string;
}
