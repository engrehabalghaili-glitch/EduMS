export interface CreateStudentTransportationSubscriptionPayload {
    studentId: number;
    schoolTransportationRouteId: number;
    subscriptionStartDate: string;
    subscriptionEndDate?: string;
    pickupStationAddress?: string;
    dropoffStationAddress?: string;
    subscriptionType: number;
    agreedMonthlyFee: number;
    pickupTime?: string;
    dropoffTime?: string;
    assignedBusStopOrder: number;
}

export interface StudentTransportationSubscription {
    id: number;
    studentId: number;
    schoolTransportationRouteId: number;
    subscriptionStartDate: string;
    subscriptionEndDate?: string;
    pickupStationAddress?: string;
    dropoffStationAddress?: string;
    subscriptionStatus: number;
    subscriptionType: number;
    agreedMonthlyFee: number;
    pickupTime?: string;
    dropoffTime?: string;
    assignedBusStopOrder: number;
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

export interface UpdateStudentTransportationSubscriptionPayload {
    id?: number;
    schoolTransportationRouteId?: number;
    subscriptionStartDate?: string;
    subscriptionEndDate?: string;
    pickupStationAddress?: string;
    dropoffStationAddress?: string;
    subscriptionType?: number;
    agreedMonthlyFee?: number;
    pickupTime?: string;
    dropoffTime?: string;
    assignedBusStopOrder?: number;
}
