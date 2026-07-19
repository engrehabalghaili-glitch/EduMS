import type { AuditFields } from './shared.types'

export type CustodySummaryStatus = 'نشط' | 'مسدد' | 'قيد_التسديد'

export interface StaffCustodySummaryData {
  employeeId: number
  custodySummaryJson: string | null
  totalItemsCount: number
  totalEstimatedValue: number
  custodyIssuedDate: string | null
  lastUpdateDate: string | null
  custodyStatus: CustodySummaryStatus
  clearanceDate: string | null
  clearedByUserId: number | null
  clearanceNotes: string | null
  clearanceDocumentUrl: string | null
  notes: string | null
}

export interface StaffCustodySummary extends AuditFields, StaffCustodySummaryData {}

export type CreateStaffCustodySummary = Omit<StaffCustodySummary, keyof AuditFields>

export type UpdateStaffCustodySummary = Partial<Omit<StaffCustodySummary, keyof AuditFields>> & { id: number }
