export interface CreateStudentPermissionAuditLogPayload {
    studentId: number;
    schoolId: number;
    userId: number;
    userRole?: string;
    permissionKey: string;
    entityType: string;
    entityId?: number;
    actionType: string;
    accessContextJson?: string;
    wasAllowed: boolean;
    rejectionReason?: string;
    riskScore: number;
    actionTimestamp: string;
}

export interface StudentPermissionAuditLog {
    id: number;
    studentId: number;
    schoolId: number;
    userId: number;
    userRole?: string;
    permissionKey: string;
    entityType: string;
    entityId?: number;
    actionType: string;
    accessContextJson?: string;
    wasAllowed: boolean;
    rejectionReason?: string;
    riskScore: number;
    actionTimestamp: string;
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

export interface UpdateStudentPermissionAuditLogPayload {
    id?: number;
    studentId?: number;
    schoolId?: number;
    userId?: number;
    userRole?: string;
    permissionKey?: string;
    entityType?: string;
    entityId?: number;
    actionType?: string;
    accessContextJson?: string;
    wasAllowed?: boolean;
    rejectionReason?: string;
    riskScore?: number;
    actionTimestamp?: string;
}
