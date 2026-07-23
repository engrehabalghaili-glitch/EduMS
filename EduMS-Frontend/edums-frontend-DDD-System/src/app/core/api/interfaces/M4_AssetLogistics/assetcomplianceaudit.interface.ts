export interface AssetComplianceAudit {
    id: number;
    schoolId: number;
    auditNumber: string;
    auditDate: string;
    auditType: number;
    standardType?: string;
    auditedByUserId: number;
    auditScope?: string;
    complianceScore: number;
    violationsFoundJson?: string;
    correctiveActionsRequired?: string;
    correctiveActionsDeadline?: string;
    correctiveActionsStatus: number;
    followUpAuditDate?: string;
    auditReportUrl?: string;
    auditStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface CreateAssetComplianceAuditPayload {
    schoolId: number;
    auditNumber: string;
    auditDate: string;
    auditType: number;
    standardType?: string;
    auditedByUserId: number;
    auditScope?: string;
    complianceScore: number;
    violationsFoundJson?: string;
    correctiveActionsRequired?: string;
    correctiveActionsDeadline?: string;
    correctiveActionsStatus: number;
    followUpAuditDate?: string;
    auditReportUrl?: string;
    auditStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface UpdateAssetComplianceAuditPayload {
    id?: number;
    schoolId?: number;
    auditNumber?: string;
    auditDate?: string;
    auditType?: number;
    standardType?: string;
    auditedByUserId?: number;
    auditScope?: string;
    complianceScore?: number;
    violationsFoundJson?: string;
    correctiveActionsRequired?: string;
    correctiveActionsDeadline?: string;
    correctiveActionsStatus?: number;
    followUpAuditDate?: string;
    auditReportUrl?: string;
    auditStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
