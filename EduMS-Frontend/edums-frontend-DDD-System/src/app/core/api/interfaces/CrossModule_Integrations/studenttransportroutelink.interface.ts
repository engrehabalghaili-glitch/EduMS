export interface CreateStudentTransportRouteLinkPayload {
    studentTransportationSubscriptionId: number;
    transportationServiceId: number;
    studentId: number;
    schoolId: number;
    assignedSeatNumber?: string;
    subscriptionStatus: number;
    effectiveFrom?: string;
    effectiveTo?: string;
    notes?: string;
}

export interface StudentTransportRouteLink {
    id: number;
    studentTransportationSubscriptionId: number;
    transportationServiceId: number;
    studentId: number;
    schoolId: number;
    assignedSeatNumber?: string;
    subscriptionStatus: number;
    effectiveFrom?: string;
    effectiveTo?: string;
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

export interface UpdateStudentTransportRouteLinkPayload {
    id?: number;
    studentTransportationSubscriptionId?: number;
    transportationServiceId?: number;
    studentId?: number;
    schoolId?: number;
    assignedSeatNumber?: string;
    subscriptionStatus?: number;
    effectiveFrom?: string;
    effectiveTo?: string;
    notes?: string;
}
