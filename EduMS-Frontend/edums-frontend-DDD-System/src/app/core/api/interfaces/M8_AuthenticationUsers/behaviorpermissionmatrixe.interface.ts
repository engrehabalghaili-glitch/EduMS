export interface BehaviorPermissionMatrix {
    id: number;
    schoolId: number;
    roleId: number;
    behaviorLevel: string;
    canRecord: boolean;
    canInvestigate: boolean;
    canDecidePenalty: boolean;
    canExecutePenalty: boolean;
    canWaivePenalty: boolean;
    requiresCommitteeDecision: boolean;
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

export interface CreateBehaviorPermissionMatrixPayload {
    schoolId: number;
    roleId: number;
    behaviorLevel: string;
    canRecord: boolean;
    canInvestigate: boolean;
    canDecidePenalty: boolean;
    canExecutePenalty: boolean;
    canWaivePenalty: boolean;
    requiresCommitteeDecision: boolean;
    notes?: string;
}

export interface UpdateBehaviorPermissionMatrixPayload {
    id?: number;
    schoolId?: number;
    roleId?: number;
    behaviorLevel?: string;
    canRecord?: boolean;
    canInvestigate?: boolean;
    canDecidePenalty?: boolean;
    canExecutePenalty?: boolean;
    canWaivePenalty?: boolean;
    requiresCommitteeDecision?: boolean;
    notes?: string;
}
