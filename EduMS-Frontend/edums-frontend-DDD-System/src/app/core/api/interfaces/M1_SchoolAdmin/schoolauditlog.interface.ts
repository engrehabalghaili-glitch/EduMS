export interface CreateSchoolAuditLogPayload {
    schoolId: number;
    affectedTableName: string;
    affectedEntityId: number;
    operationType: number;
    changeTypeSummary: string;
    oldValueJson?: string;
    newValueJson?: string;
    changeSummaryText: string;
    performedByUserId: number;
    performedByUserName: string;
    performedByUserRole: string;
    ipAddress?: string;
    deviceInfo?: string;
    actionDate: string;
    severityLevel: number;
    isSuspicious: boolean;
    decisionDocumentUrl?: string;
    notes?: string;
}

export interface SchoolAuditLog {
    id: number;
    schoolId: number;
    affectedTableName: string;
    affectedEntityId: number;
    operationType: number;
    changeTypeSummary: string;
    oldValueJson?: string;
    newValueJson?: string;
    changeSummaryText: string;
    performedByUserId: number;
    performedByUserName: string;
    performedByUserRole: string;
    ipAddress?: string;
    deviceInfo?: string;
    actionDate: string;
    severityLevel: number;
    isSuspicious: boolean;
    decisionDocumentUrl?: string;
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

export interface UpdateSchoolAuditLogPayload {
    id?: number;
    affectedTableName?: string;
    affectedEntityId?: number;
    operationType?: number;
    changeTypeSummary?: string;
    oldValueJson?: string;
    newValueJson?: string;
    changeSummaryText?: string;
    performedByUserId?: number;
    performedByUserName?: string;
    performedByUserRole?: string;
    ipAddress?: string;
    deviceInfo?: string;
    actionDate?: string;
    severityLevel?: number;
    isSuspicious?: boolean;
    decisionDocumentUrl?: string;
    notes?: string;
}
