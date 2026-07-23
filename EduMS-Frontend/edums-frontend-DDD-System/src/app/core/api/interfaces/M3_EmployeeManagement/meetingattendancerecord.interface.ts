export interface CreateMeetingAttendanceRecordPayload {
    meetingId: number;
    employeeId: number;
    isAttended: boolean;
    attendanceMethod?: string;
    absenceReason?: string;
    isExcused: boolean;
    notes?: string;
}

export interface MeetingAttendanceRecord {
    id: number;
    meetingId: number;
    employeeId: number;
    isAttended: boolean;
    attendanceMethod?: string;
    absenceReason?: string;
    isExcused: boolean;
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

export interface UpdateMeetingAttendanceRecordPayload {
    id?: number;
    meetingId?: number;
    employeeId?: number;
    isAttended?: boolean;
    attendanceMethod?: string;
    absenceReason?: string;
    isExcused?: boolean;
    notes?: string;
}
