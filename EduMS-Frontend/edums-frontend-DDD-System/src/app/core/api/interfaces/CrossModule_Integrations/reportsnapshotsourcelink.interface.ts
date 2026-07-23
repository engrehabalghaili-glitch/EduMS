export interface CreateReportSnapshotSourceLinkPayload {
    statisticalReportSnapshotId: number;
    schoolId: number;
    sourceModule: string;
    sourceEntityType: string;
    sourceEntityId?: number;
    schoolAcademicYearId?: number;
    aggregationDescription?: string;
    notes?: string;
}

export interface ReportSnapshotSourceLink {
    id: number;
    statisticalReportSnapshotId: number;
    schoolId: number;
    sourceModule: string;
    sourceEntityType: string;
    sourceEntityId?: number;
    schoolAcademicYearId?: number;
    aggregationDescription?: string;
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

export interface UpdateReportSnapshotSourceLinkPayload {
    id?: number;
    statisticalReportSnapshotId?: number;
    schoolId?: number;
    sourceModule?: string;
    sourceEntityType?: string;
    sourceEntityId?: number;
    schoolAcademicYearId?: number;
    aggregationDescription?: string;
    notes?: string;
}
