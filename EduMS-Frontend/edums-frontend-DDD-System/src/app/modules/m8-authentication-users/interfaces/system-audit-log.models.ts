export interface SystemAuditLog {
  id: number
  schoolId: number | null
  userId: number
  userRoleAtExecution: string | null
  actionType: string
  entityType: string
  entityId: number | null
  oldValueJson: string | null
  newValueJson: string | null
  changeSummary: string | null
  tableName: string | null
  fieldName: string | null
  ipAddress: string | null
  deviceType: string | null
  userAgent: string | null
  sessionId: string | null
  accessContextJson: string | null
  severity: 'منخفض' | 'متوسط' | 'عالي' | 'حرج' | null
  riskScore: number
  isSuspicious: boolean
  wasAllowed: boolean
  rejectionReason: string | null
  notes: string | null
  actionTimestamp: string
  createdAt: string
}

export type CreateSystemAuditLog = Omit<SystemAuditLog, 'id' | 'createdAt'>

export type UpdateSystemAuditLog = Partial<CreateSystemAuditLog> & { id: number }
