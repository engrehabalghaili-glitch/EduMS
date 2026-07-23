export interface AssetAssignment {
    id: number;
    assetId: number;
    schoolId: number;
    assigneeType: number;
    assigneeId: number;
    assigneeName: string;
    assignerUserId?: number;
    assignmentDate: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    assignmentReason?: string;
    conditionAtAssignment: number;
    conditionNotesAtAssignment?: string;
    conditionAtReturn: number;
    conditionNotesAtReturn?: string;
    penaltyAmount: number;
    penaltyStatus: number;
    assignmentStatus: number;
    isReturned: boolean;
    returnedToUserId?: number;
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

export interface CreateAssetAssignmentPayload {
    assetId: number;
    schoolId: number;
    assigneeType: number;
    assigneeId: number;
    assigneeName: string;
    assignerUserId?: number;
    assignmentDate: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    assignmentReason?: string;
    conditionAtAssignment: number;
    conditionNotesAtAssignment?: string;
    conditionAtReturn: number;
    conditionNotesAtReturn?: string;
    penaltyAmount: number;
    penaltyStatus: number;
    assignmentStatus: number;
    isReturned: boolean;
    returnedToUserId?: number;
    notes?: string;
}

export interface UpdateAssetAssignmentPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    assigneeType?: number;
    assigneeId?: number;
    assigneeName?: string;
    assignerUserId?: number;
    assignmentDate?: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    assignmentReason?: string;
    conditionAtAssignment?: number;
    conditionNotesAtAssignment?: string;
    conditionAtReturn?: number;
    conditionNotesAtReturn?: string;
    penaltyAmount?: number;
    penaltyStatus?: number;
    assignmentStatus?: number;
    isReturned?: boolean;
    returnedToUserId?: number;
    notes?: string;
}
