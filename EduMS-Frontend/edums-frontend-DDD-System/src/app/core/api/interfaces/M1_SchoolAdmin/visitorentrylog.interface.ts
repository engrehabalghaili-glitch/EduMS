export interface CreateVisitorEntryLogPayload {
    schoolId: number;
    visitorFullName: string;
    nationalIdOrPassport: string;
    visitPurpose: string;
    hostEmployeeId?: number;
    checkInTime: string;
    checkOutTime?: string;
    visitorBadgeNumber?: string;
    visitorPhoneNumber?: string;
    visitorOrganization?: string;
    securityGateNumber?: string;
    securityOfficerEmployeeId?: number;
}

export interface UpdateVisitorEntryLogPayload {
    id?: number;
    visitorFullName?: string;
    nationalIdOrPassport?: string;
    visitPurpose?: string;
    hostEmployeeId?: number;
    checkInTime?: string;
    checkOutTime?: string;
    visitorBadgeNumber?: string;
    visitorPhoneNumber?: string;
    visitorOrganization?: string;
    securityGateNumber?: string;
    securityOfficerEmployeeId?: number;
}

export interface VisitorEntryLog {
    id: number;
    schoolId: number;
    visitorFullName: string;
    nationalIdOrPassport: string;
    visitPurpose: string;
    hostEmployeeId?: number;
    checkInTime: string;
    checkOutTime?: string;
    visitorBadgeNumber?: string;
    status: number;
    visitorPhoneNumber?: string;
    visitorOrganization?: string;
    securityGateNumber?: string;
    securityOfficerEmployeeId?: number;
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
