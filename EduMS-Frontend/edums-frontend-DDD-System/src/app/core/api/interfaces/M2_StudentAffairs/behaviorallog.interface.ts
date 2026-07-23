export interface BehavioralLog {
    id: number;
    studentId: number;
    incidentDate: string;
    behaviorCategory: number;
    incidentTitleAr: string;
    description: string;
    actionTaken?: string;
    recordedByEmployeeId?: number;
    status: number;
    incidentTitleEn?: string;
    demeritOrMeritPoints: number;
    incidentLocation?: string;
    parentNotificationStatus: number;
    investigationNotes?: string;
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

export interface CreateBehavioralLogPayload {
    studentId: number;
    incidentDate: string;
    behaviorCategory: number;
    incidentTitleAr: string;
    description: string;
    actionTaken?: string;
    incidentTitleEn?: string;
    demeritOrMeritPoints: number;
    incidentLocation?: string;
    investigationNotes?: string;
}

export interface UpdateBehavioralLogPayload {
    id?: number;
    incidentDate?: string;
    behaviorCategory?: number;
    incidentTitleAr?: string;
    description?: string;
    actionTaken?: string;
    incidentTitleEn?: string;
    demeritOrMeritPoints?: number;
    incidentLocation?: string;
    investigationNotes?: string;
}
