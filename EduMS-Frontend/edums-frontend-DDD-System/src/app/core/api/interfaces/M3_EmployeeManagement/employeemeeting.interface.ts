export interface CreateEmployeeMeetingPayload {
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeId?: number;
    meetingTitleAr: string;
    meetingDateTime: string;
    meetingLocation: string;
    meetingType: number;
    agendaJson?: string;
    minutesText?: string;
    decisionsJson?: string;
    meetingStatus: number;
    chairmanEmployeeId?: number;
    attachmentsJson?: string;
    notes?: string;
}

export interface EmployeeMeeting {
    id: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeId?: number;
    meetingTitleAr: string;
    meetingDateTime: string;
    meetingLocation: string;
    meetingType: number;
    agendaJson?: string;
    minutesText?: string;
    decisionsJson?: string;
    meetingStatus: number;
    chairmanEmployeeId?: number;
    attachmentsJson?: string;
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

export interface UpdateEmployeeMeetingPayload {
    id?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    committeeId?: number;
    meetingTitleAr?: string;
    meetingDateTime?: string;
    meetingLocation?: string;
    meetingType?: number;
    agendaJson?: string;
    minutesText?: string;
    decisionsJson?: string;
    meetingStatus?: number;
    chairmanEmployeeId?: number;
    attachmentsJson?: string;
    notes?: string;
}
