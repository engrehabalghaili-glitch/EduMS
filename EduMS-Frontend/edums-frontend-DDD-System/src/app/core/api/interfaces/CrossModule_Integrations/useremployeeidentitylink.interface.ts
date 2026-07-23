export interface CreateUserEmployeeIdentityLinkPayload {
    systemUserId: number;
    employeeId: number;
    schoolId: number;
    directorateId?: number;
    organizationalSectorId?: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
    unlinkReason?: string;
    linkedByUserId?: number;
    notes?: string;
}

export interface UpdateUserEmployeeIdentityLinkPayload {
    id?: number;
    systemUserId?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    linkStatus?: number;
    linkedAt?: string;
    unlinkedAt?: string;
    unlinkReason?: string;
    linkedByUserId?: number;
    notes?: string;
}

export interface UserEmployeeIdentityLink {
    id: number;
    systemUserId: number;
    employeeId: number;
    schoolId: number;
    directorateId?: number;
    organizationalSectorId?: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
    unlinkReason?: string;
    linkedByUserId?: number;
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
