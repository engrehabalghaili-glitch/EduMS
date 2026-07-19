export interface StudentPermissionAuditLog {
  id: number
  studentId: number
  schoolId: number
  userId: number
  userRole: string | null
  permissionKey: string
  entityType: string
  entityId: number | null
  actionType: string
  accessContextJson: string | null
  wasAllowed: boolean
  rejectionReason: string | null
  riskScore: number
  actionTimestamp: string
  createdAt: string
}

export type CreateStudentPermissionAuditLog = Omit<StudentPermissionAuditLog, 'id' | 'createdAt'>

export type UpdateStudentPermissionAuditLog = Partial<CreateStudentPermissionAuditLog> & { id: number }
