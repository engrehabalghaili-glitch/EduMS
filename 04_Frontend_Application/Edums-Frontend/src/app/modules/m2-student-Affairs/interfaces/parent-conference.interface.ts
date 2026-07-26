import { ConferenceType } from './_types';

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
  conferenceType: ConferenceType;
  followUpActionItems?: string;
  isGuardianAttended: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentParentConferenceReservation = Omit<StudentParentConferenceReservation, 'id' | 'createdAt' | 'modifiedAt' | 'status'>;

export type UpdateStudentParentConferenceReservation = CreateStudentParentConferenceReservation & { id: number };
