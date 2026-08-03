import type { AuditFields } from './shared.types'

export type CustodyCondition = 'جديد' | 'جيد' | 'مقبول' | 'سيء' | 'تالف'
export type PenaltyStatus = 'غير_مطبق' | 'مطبق' | 'مسدد'
export type CustodyStatus = 'بيد_الموظف' | 'مسترجع' | 'مفقود' | 'تالف'

export interface EmployeeInventoryCustodyData {
  employeeId: number
  assetId: number | null
  itemType: string
  itemNameAr: string
  itemBrand: string | null
  itemModel: string | null
  itemSerialNumber: string | null
  itemCode: string | null
  estimatedValue: number
  conditionAtHandover: CustodyCondition
  handoverDate: string
  handoverNotes: string | null
  issuedByEmployeeId: number | null
  receiptSignatureUrl: string | null
  expectedReturnDate: string | null
  actualReturnDate: string | null
  conditionAtReturn: CustodyCondition
  returnNotes: string | null
  isReturned: boolean
  isDamaged: boolean
  damageDescription: string | null
  penaltyAmount: number
  penaltyStatus: PenaltyStatus
  isLost: boolean
  replacementRequired: boolean
  custodyStatus: CustodyStatus
  notes: string | null
}

export interface EmployeeInventoryCustody extends AuditFields, EmployeeInventoryCustodyData {}

export type CreateEmployeeInventoryCustody = Omit<EmployeeInventoryCustody, keyof AuditFields>

export type UpdateEmployeeInventoryCustody = Partial<Omit<EmployeeInventoryCustody, keyof AuditFields>> & { id: number }
