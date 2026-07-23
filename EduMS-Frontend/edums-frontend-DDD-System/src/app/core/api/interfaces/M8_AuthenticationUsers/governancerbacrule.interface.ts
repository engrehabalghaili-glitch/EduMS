export interface CreateGovernanceRbacRulePayload {
    roleId: number;
    targetRoleId?: number;
    targetPermissionId?: number;
    allowedAction: string;
    canDelegate: boolean;
    approvalRequired: boolean;
    approvalRoleId?: number;
    notes?: string;
}

export interface GovernanceRbacRule {
    id: number;
    roleId: number;
    targetRoleId?: number;
    targetPermissionId?: number;
    allowedAction: string;
    canDelegate: boolean;
    approvalRequired: boolean;
    approvalRoleId?: number;
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

export interface UpdateGovernanceRbacRulePayload {
    id?: number;
    roleId?: number;
    targetRoleId?: number;
    targetPermissionId?: number;
    allowedAction?: string;
    canDelegate?: boolean;
    approvalRequired?: boolean;
    approvalRoleId?: number;
    notes?: string;
}
