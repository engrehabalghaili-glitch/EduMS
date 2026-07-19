import type { AuditFields } from './shared.types'

export type AttendanceMethod = 'حضوري' | 'عن_بعد' | 'تسجيل_فيديو'

export interface MeetingAttendanceRecordData {
  meetingId: number
  employeeId: number
  isAttended: boolean
  attendanceMethod: AttendanceMethod | null
  absenceReason: string | null
  isExcused: boolean
  notes: string | null
}

export interface MeetingAttendanceRecord extends AuditFields, MeetingAttendanceRecordData {}

export type CreateMeetingAttendanceRecord = Omit<MeetingAttendanceRecord, keyof AuditFields>

export type UpdateMeetingAttendanceRecord = Partial<Omit<MeetingAttendanceRecord, keyof AuditFields>> & { id: number }
