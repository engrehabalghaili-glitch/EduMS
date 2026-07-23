export interface CreateSchoolFacilityPayload {
    schoolId: number;
    facilityCode: string;
    facilityNameAr: string;
    facilityNameEn: string;
    facilityType: number;
    capacity: number;
    assignedSupervisorId?: number;
    isOperational: boolean;
    locationFloor?: string;
    buildingName?: string;
    safetyInspectionDate?: string;
}

export interface SchoolFacility {
    id: number;
    schoolId: number;
    facilityCode: string;
    facilityNameAr: string;
    facilityNameEn: string;
    facilityType: number;
    capacity: number;
    assignedSupervisorId?: number;
    isOperational: boolean;
    locationFloor?: string;
    buildingName?: string;
    safetyInspectionDate?: string;
    maintenanceStatus: number;
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

export interface UpdateSchoolFacilityPayload {
    id?: number;
    facilityCode?: string;
    facilityNameAr?: string;
    facilityNameEn?: string;
    facilityType?: number;
    capacity?: number;
    assignedSupervisorId?: number;
    isOperational?: boolean;
    locationFloor?: string;
    buildingName?: string;
    safetyInspectionDate?: string;
}
