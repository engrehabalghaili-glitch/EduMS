import type { AuditFields, AcademicScope } from './shared.types'

export type CheckMethod = 'بصمة' | 'وجه' | 'يدوي' | 'تطبيق' | 'بطاقة'
export type AttendanceStatus = 'حاضر' | 'غائب' | 'متأخر' | 'مغادر_مبكراً' | 'إجازة' | 'مهمة_رسمية'

export interface EmployeeAttendanceData {
  employeeId: number
  attendanceDate: string
  dayOfWeek: string
  shiftId: number | null
  expectedCheckIn: string | null
  expectedCheckOut: string | null
  checkInTime: string | null
  checkOutTime: string | null
  checkInMethod: CheckMethod
  checkOutMethod: CheckMethod
  locationVerified: boolean
  checkInLocationGps: string | null
  attendanceStatus: AttendanceStatus
  lateMinutes: number
  earlyDepartureMinutes: number
  overtimeMinutes: number
  isOvertimeApproved: boolean
  totalWorkHours: number
  isExcused: boolean
  excuseLeaveId: number | null
  excuseDocumentUrl: string | null
  isHoliday: boolean
  isWeekend: boolean
  isWorkingDay: boolean
  isOverridden: boolean
  overrideReason: string | null
  overriddenByUserId: number | null
  isSyncedWithPayroll: boolean
  payrollId: number | null
  notes: string | null
}

export interface EmployeeAttendance extends AuditFields, AcademicScope, EmployeeAttendanceData {}

export type CreateEmployeeAttendance = Omit<EmployeeAttendance, keyof AuditFields>

export type UpdateEmployeeAttendance = Partial<Omit<EmployeeAttendance, keyof AuditFields>> & { id: number }
