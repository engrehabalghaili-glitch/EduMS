import { AttendanceStatus } from './_types';

export interface AttendanceDetail {
  id: number;
  studentId: number;
  classroomId: number;
  attendanceDate: string;
  attendanceStatus: AttendanceStatus;
  absenceReason?: string;
  durationMinutes: number;
  recordedByEmployeeId?: number;
  periodNumber: number;
  checkInTime?: string;
  checkOutTime?: string;
  isParentNotified: boolean;
  excusalDocumentUrl?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateAttendanceDetail = Omit<AttendanceDetail, 'id' | 'createdAt' | 'modifiedAt' | 'attendanceStatus' | 'recordedByEmployeeId'>;

export type UpdateAttendanceDetail = CreateAttendanceDetail & { id: number };
