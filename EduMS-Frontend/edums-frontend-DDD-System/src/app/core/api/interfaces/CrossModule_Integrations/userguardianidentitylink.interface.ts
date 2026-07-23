export interface CreateUserGuardianIdentityLinkPayload {
    systemUserId: number;
    studentGuardianRelationshipId: number;
    studentId: number;
    schoolId: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
    notes?: string;
}

export interface UpdateUserGuardianIdentityLinkPayload {
    id?: number;
    systemUserId?: number;
    studentGuardianRelationshipId?: number;
    studentId?: number;
    schoolId?: number;
    linkStatus?: number;
    linkedAt?: string;
    unlinkedAt?: string;
    notes?: string;
}

export interface UserGuardianIdentityLink {
    id: number;
    systemUserId: number;
    studentGuardianRelationshipId: number;
    studentId: number;
    schoolId: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
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
