export type TransferStatus = 'مكتمل' | 'قيد التنفيذ' | 'معلق' | 'لم يبدأ'

export interface SchoolMerger {
  id: number
  mergerNumber: string
  mergerDate: string
  effectiveDate: string
  sourceSchoolIds: number[]
  targetSchoolId: number
  mergerReason?: string
  decisionAuthority?: string
  decisionDocumentPath?: string
  studentsTransferStatus: TransferStatus
  employeesTransferStatus: TransferStatus
  assetsTransferStatus: TransferStatus
  mergerStatus: 'مخطط' | 'قيد التنفيذ' | 'مكتمل' | 'ملغي'
  completionDate?: string
  completionNotes?: string
  notes?: string
}

export type CreateSchoolMerger = Omit<SchoolMerger, 'id'>

export type UpdateSchoolMerger = Partial<SchoolMerger> & { id: number }

export type SchoolMergerResponse = SchoolMerger

export type SchoolMergerListResponse = SchoolMerger[]
