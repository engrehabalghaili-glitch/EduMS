export interface CreateSchoolTransportationRoutePayload {
    schoolId: number;
    routeCode: string;
    routeNameAr: string;
    driverEmployeeId?: number;
    busPlateNumber?: string;
    totalSeats: number;
    morningStartHour: string;
    eveningReturnHour: string;
    monthlyFee: number;
    routeNameEn?: string;
    busSupervisorEmployeeId?: number;
    busModelAndYear?: string;
    totalSubscribedStudents: number;
    gpsTrackingDeviceId?: string;
}

export interface SchoolTransportationRoute {
    id: number;
    schoolId: number;
    routeCode: string;
    routeNameAr: string;
    driverEmployeeId?: number;
    busPlateNumber?: string;
    totalSeats: number;
    morningStartHour: string;
    eveningReturnHour: string;
    monthlyFee: number;
    routeNameEn?: string;
    busSupervisorEmployeeId?: number;
    busModelAndYear?: string;
    totalSubscribedStudents: number;
    gpsTrackingDeviceId?: string;
    isActive: boolean;
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

export interface UpdateSchoolTransportationRoutePayload {
    id?: number;
    routeCode?: string;
    routeNameAr?: string;
    driverEmployeeId?: number;
    busPlateNumber?: string;
    totalSeats?: number;
    morningStartHour?: string;
    eveningReturnHour?: string;
    monthlyFee?: number;
    routeNameEn?: string;
    busSupervisorEmployeeId?: number;
    busModelAndYear?: string;
    totalSubscribedStudents?: number;
    gpsTrackingDeviceId?: string;
}
