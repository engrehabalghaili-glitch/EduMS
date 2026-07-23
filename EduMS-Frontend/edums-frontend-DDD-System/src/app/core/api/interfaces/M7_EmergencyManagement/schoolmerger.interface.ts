export interface CreateSchoolMergerPayload {
    mergerNumber: string;
    mergerDate: string;
    effectiveDate: string;
    sourceSchoolIdsJson: string;
    targetSchoolId: number;
    mergerReason?: string;
    decisionAuthority?: string;
    decisionDocumentPath?: string;
    studentsTransferStatus: number;
    employeesTransferStatus: number;
    assetsTransferStatus: number;
    mergerStatus: number;
    completionDate?: string;
    completionNotes?: string;
    notes?: string;
}

export interface SchoolMerger {
    id: number;
    mergerNumber: string;
    mergerDate: string;
    effectiveDate: string;
    sourceSchoolIdsJson: string;
    targetSchoolId: number;
    mergerReason?: string;
    decisionAuthority?: string;
    decisionDocumentPath?: string;
    studentsTransferStatus: number;
    employeesTransferStatus: number;
    assetsTransferStatus: number;
    mergerStatus: number;
    completionDate?: string;
    completionNotes?: string;
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

export interface UpdateSchoolMergerPayload {
    id?: number;
    mergerNumber?: string;
    mergerDate?: string;
    effectiveDate?: string;
    sourceSchoolIdsJson?: string;
    targetSchoolId?: number;
    mergerReason?: string;
    decisionAuthority?: string;
    decisionDocumentPath?: string;
    studentsTransferStatus?: number;
    employeesTransferStatus?: number;
    assetsTransferStatus?: number;
    mergerStatus?: number;
    completionDate?: string;
    completionNotes?: string;
    notes?: string;
}
