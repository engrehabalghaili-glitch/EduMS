export interface UserRoleAssignment {
  id: number
  userId: number
  roleId: number
  schoolId: number | null
  isPrimary: boolean
  scopeContextJson: string | null
  startDate: string | null
  endDate: string | null
  isActive: boolean
  assignedByUserId: number | null
  assignedAt: string | null
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateUserRoleAssignment = Omit<UserRoleAssignment, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateUserRoleAssignment = Partial<CreateUserRoleAssignment> & { id: number }
