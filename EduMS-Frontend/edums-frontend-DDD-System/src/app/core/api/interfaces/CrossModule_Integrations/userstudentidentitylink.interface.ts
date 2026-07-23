export interface CreateUserStudentIdentityLinkPayload {
    systemUserId: number;
    studentId: number;
    schoolId: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
    linkedByUserId?: number;
    notes?: string;
}

export interface UpdateUserStudentIdentityLinkPayload {
    id?: number;
    systemUserId?: number;
    studentId?: number;
    schoolId?: number;
    linkStatus?: number;
    linkedAt?: string;
    unlinkedAt?: string;
    linkedByUserId?: number;
    notes?: string;
}

export interface UserStudentIdentityLink {
    id: number;
    systemUserId: number;
    studentId: number;
    schoolId: number;
    linkStatus: number;
    linkedAt: string;
    unlinkedAt?: string;
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
