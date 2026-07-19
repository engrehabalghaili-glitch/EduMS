export interface UserActivityLog {
  id: number
  userId: number
  schoolId: number | null
  activityType: string
  activityTimestamp: string
  activityStatus: 'ناجح' | 'فاشل' | 'محظور' | 'معلق'
  failureReason: string | null
  ipAddress: string | null
  deviceType: string | null
  deviceName: string | null
  operatingSystem: string | null
  browser: string | null
  userAgent: string | null
  locationText: string | null
  sessionId: string | null
  actionDetailsJson: string | null
  notes: string | null
  createdAt: string
}

export type CreateUserActivityLog = Omit<UserActivityLog, 'id' | 'createdAt'>

export type UpdateUserActivityLog = Partial<CreateUserActivityLog> & { id: number }
