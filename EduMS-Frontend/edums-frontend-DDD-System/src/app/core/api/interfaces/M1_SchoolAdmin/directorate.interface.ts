export interface CreateDirectoratePayload {
    directorateCode: string;
    directorateNameAr: string;
    directorateNameEn: string;
    address?: string;
    contactPhone?: string;
    contactEmail?: string;
    directorName?: string;
    governorate?: string;
    establishmentDate?: string;
    regionCode?: string;
    supervisoryScopeDescription?: string;
    annualBudgetLimit: number;
    employeeCount: number;
}

export interface Directorate {
    id: number;
    directorateCode: string;
    directorateNameAr: string;
    directorateNameEn: string;
    address?: string;
    contactPhone?: string;
    contactEmail?: string;
    directorName?: string;
    governorate?: string;
    establishmentDate?: string;
    regionCode?: string;
    supervisoryScopeDescription?: string;
    annualBudgetLimit: number;
    employeeCount: number;
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

export interface UpdateDirectoratePayload {
    id?: number;
    directorateCode?: string;
    directorateNameAr?: string;
    directorateNameEn?: string;
    address?: string;
    contactPhone?: string;
    contactEmail?: string;
    directorName?: string;
    governorate?: string;
    establishmentDate?: string;
    regionCode?: string;
    supervisoryScopeDescription?: string;
    annualBudgetLimit?: number;
    employeeCount?: number;
}
