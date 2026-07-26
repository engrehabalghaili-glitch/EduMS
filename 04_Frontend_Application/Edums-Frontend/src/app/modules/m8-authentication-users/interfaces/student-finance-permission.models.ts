export interface StudentFinancePermission {
  id: number
  schoolId: number
  permissionKey: string
  permissionNameAr: string
  permissionNameEn: string | null
  category: string | null
  maxAmountLimit: number
  maxDiscountPercentage: number
  requiresDirectorApproval: boolean
  requiresBoardApproval: boolean
  allowedRolesJson: string | null
  isActive: boolean
  notes: string | null
  createdAt: string
  modifiedAt: string | null
}

export type CreateStudentFinancePermission = Omit<StudentFinancePermission, 'id' | 'createdAt' | 'modifiedAt'>

export type UpdateStudentFinancePermission = Partial<CreateStudentFinancePermission> & { id: number }
