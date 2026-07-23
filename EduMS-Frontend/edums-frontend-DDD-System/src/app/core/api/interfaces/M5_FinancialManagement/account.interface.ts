export interface Account {
    id: number;
    schoolId?: number;
    accountCode: string;
    accountNameAr: string;
    accountNameEn: string;
    parentAccountId?: number;
    accountType: number;
    levelNumber: number;
    currentBalance: number;
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

export interface CreateAccountPayload {
    schoolId?: number;
    accountCode: string;
    accountNameAr: string;
    accountNameEn: string;
    parentAccountId?: number;
    accountType: number;
    levelNumber: number;
    currentBalance: number;
    isActive: boolean;
}

export interface UpdateAccountPayload {
    id?: number;
    schoolId?: number;
    accountCode?: string;
    accountNameAr?: string;
    accountNameEn?: string;
    parentAccountId?: number;
    accountType?: number;
    levelNumber?: number;
    currentBalance?: number;
    isActive?: boolean;
}
