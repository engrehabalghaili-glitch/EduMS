export interface CommitteeMember {
    id: number;
    committeeId: number;
    employeeId: number;
    memberRole: number;
    joinDate: string;
    exitDate?: string;
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

export interface CreateCommitteeMemberPayload {
    committeeId: number;
    employeeId: number;
    memberRole: number;
    joinDate: string;
    exitDate?: string;
    isActive: boolean;
    notes?: string;
}

export interface UpdateCommitteeMemberPayload {
    id?: number;
    committeeId?: number;
    employeeId?: number;
    memberRole?: number;
    joinDate?: string;
    exitDate?: string;
    isActive?: boolean;
    notes?: string;
}
