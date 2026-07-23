export interface CreateOrganizationalSectorPayload {
    sectorCode: string;
    sectorNameAr: string;
    sectorNameEn?: string;
    sectorType: number;
    parentSectorId?: number;
    directorateId?: number;
    schoolId?: number;
    costCenterCode?: string;
    annualHrBudget: number;
    headOfSectorEmployeeId?: number;
    isActive: boolean;
    notes?: string;
}

export interface OrganizationalSector {
    id: number;
    sectorCode: string;
    sectorNameAr: string;
    sectorNameEn?: string;
    sectorType: number;
    parentSectorId?: number;
    directorateId?: number;
    schoolId?: number;
    costCenterCode?: string;
    annualHrBudget: number;
    headOfSectorEmployeeId?: number;
    isActive: boolean;
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

export interface UpdateOrganizationalSectorPayload {
    id?: number;
    sectorCode?: string;
    sectorNameAr?: string;
    sectorNameEn?: string;
    sectorType?: number;
    parentSectorId?: number;
    directorateId?: number;
    schoolId?: number;
    costCenterCode?: string;
    annualHrBudget?: number;
    headOfSectorEmployeeId?: number;
    isActive?: boolean;
    notes?: string;
}
