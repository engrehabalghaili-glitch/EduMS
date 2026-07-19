import type { AuditFields, OrganizationalScope } from './shared.types'

export type MeetingType = 'عادية' | 'طارئة' | 'دورية' | 'مجلس_إدارة'
export type MeetingStatus = 'مجدولة' | 'منعقدة' | 'ملغاة' | 'مؤجلة'

export interface EmployeeMeetingData {
  committeeId: number | null
  meetingTitleAr: string
  meetingDateTime: string
  meetingLocation: string
  meetingType: MeetingType
  agendaJson: string | null
  minutesText: string | null
  decisionsJson: string | null
  meetingStatus: MeetingStatus
  chairmanEmployeeId: number | null
  attachmentsJson: string | null
  notes: string | null
}

export interface EmployeeMeeting extends AuditFields, OrganizationalScope, EmployeeMeetingData {}

export type CreateEmployeeMeeting = Omit<EmployeeMeeting, keyof AuditFields>

export type UpdateEmployeeMeeting = Partial<Omit<EmployeeMeeting, keyof AuditFields>> & { id: number }
