export interface AttendanceDetail {
    id: number;
    studentId: number;
    classroomId: number;
    attendanceDate: string;
    attendanceStatus: number;
    absenceReason?: string;
    durationMinutes: number;
    recordedByEmployeeId?: number;
    periodNumber: number;
    checkInTime?: string;
    checkOutTime?: string;
    isParentNotified: boolean;
    excusalDocumentUrl?: string;
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

export interface CreateAttendanceDetailPayload {
    studentId: number;
    classroomId: number;
    attendanceDate: string;
    absenceReason?: string;
    durationMinutes: number;
    periodNumber: number;
    checkInTime?: string;
    checkOutTime?: string;
    isParentNotified: boolean;
    excusalDocumentUrl?: string;
}

export interface UpdateAttendanceDetailPayload {
    id?: number;
    classroomId?: number;
    attendanceDate?: string;
    absenceReason?: string;
    durationMinutes?: number;
    periodNumber?: number;
    checkInTime?: string;
    checkOutTime?: string;
    isParentNotified?: boolean;
    excusalDocumentUrl?: string;
}
