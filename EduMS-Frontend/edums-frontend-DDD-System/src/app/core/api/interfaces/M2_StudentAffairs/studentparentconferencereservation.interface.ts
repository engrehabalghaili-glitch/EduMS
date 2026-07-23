export interface CreateStudentParentConferenceReservationPayload {
    studentId: number;
    guardianId: number;
    teacherEmployeeId: number;
    schoolEventCalendarId?: number;
    reservedDateTime: string;
    meetingDurationMinutes: number;
    discussionTopic?: string;
    conferenceNotes?: string;
    meetingRoomOrLink?: string;
    conferenceType: number;
    followUpActionItems?: string;
    isGuardianAttended: boolean;
}

export interface StudentParentConferenceReservation {
    id: number;
    studentId: number;
    guardianId: number;
    teacherEmployeeId: number;
    schoolEventCalendarId?: number;
    reservedDateTime: string;
    meetingDurationMinutes: number;
    discussionTopic?: string;
    conferenceNotes?: string;
    status: number;
    meetingRoomOrLink?: string;
    conferenceType: number;
    followUpActionItems?: string;
    isGuardianAttended: boolean;
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

export interface UpdateStudentParentConferenceReservationPayload {
    id?: number;
    guardianId?: number;
    teacherEmployeeId?: number;
    schoolEventCalendarId?: number;
    reservedDateTime?: string;
    meetingDurationMinutes?: number;
    discussionTopic?: string;
    conferenceNotes?: string;
    meetingRoomOrLink?: string;
    conferenceType?: number;
    followUpActionItems?: string;
    isGuardianAttended?: boolean;
}
