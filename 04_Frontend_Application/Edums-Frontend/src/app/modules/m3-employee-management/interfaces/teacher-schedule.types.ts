import type { AuditFields, AcademicScope } from './shared.types'

export interface TeacherScheduleData {
  teacherEmployeeId: number
  dayOfWeek: string
  classPeriodId: number | null
  periodNumber: number
  subjectId: number | null
  classSectionId: number | null
  gradeCapacityId: number | null
  classroomId: number | null
  isSubstitute: boolean
  originalTeacherEmployeeId: number | null
  substituteDate: string | null
  substituteReason: string | null
  isActive: boolean
  isCancelled: boolean
  cancellationReason: string | null
}

export interface TeacherSchedule extends AuditFields, AcademicScope, TeacherScheduleData {}

export type CreateTeacherSchedule = Omit<TeacherSchedule, keyof AuditFields>

export type UpdateTeacherSchedule = Partial<Omit<TeacherSchedule, keyof AuditFields>> & { id: number }
