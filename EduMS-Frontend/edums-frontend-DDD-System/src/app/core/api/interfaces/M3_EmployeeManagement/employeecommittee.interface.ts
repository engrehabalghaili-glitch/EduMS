export interface CreateEmployeeCommitteePayload {
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeNameAr: string;
    committeeNameEn?: string;
    committeeCode: string;
    committeeType: number;
    formationDate: string;
    dissolutionDate?: string;
    objectives?: string;
    chairmanEmployeeId?: number;
    committeeStatus: number;
    notes?: string;
}

export interface EmployeeCommittee {
    id: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeNameAr: string;
    committeeNameEn?: string;
    committeeCode: string;
    committeeType: number;
    formationDate: string;
    dissolutionDate?: string;
    objectives?: string;
    chairmanEmployeeId?: number;
    committeeStatus: number;
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

export interface UpdateEmployeeCommitteePayload {
    id?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeNameAr?: string;
    committeeNameEn?: string;
    committeeCode?: string;
    committeeType?: number;
    formationDate?: string;
    dissolutionDate?: string;
    objectives?: string;
    chairmanEmployeeId?: number;
    committeeStatus?: number;
    notes?: string;
}
