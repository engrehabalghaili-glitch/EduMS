import type { AuditFields } from './shared.types'

export type DocumentStatus = 'قيد_المراجعة' | 'موثق' | 'مرفوض' | 'منتهي'
export type DocumentFileType = 'pdf' | 'docx' | 'xlsx' | 'jpg' | 'png' | 'zip'

export interface EmployeeDocumentData {
  employeeId: number
  documentType: string
  documentSubType: string | null
  documentName: string
  documentNumber: string | null
  issueDate: string | null
  expiryDate: string | null
  issuedBy: string | null
  isExpiryRequired: boolean
  expiryReminderSent: boolean
  filePath: string | null
  fileSize: number | null
  fileType: DocumentFileType | null
  thumbnailPath: string | null
  description: string | null
  isRequired: boolean
  isVerified: boolean
  verifiedByUserId: number | null
  verificationDate: string | null
  verificationNotes: string | null
  rejectionReason: string | null
  documentStatus: DocumentStatus
  isConfidential: boolean
  isArchived: boolean
  notes: string | null
}

export interface EmployeeDocument extends AuditFields, EmployeeDocumentData {}

export type CreateEmployeeDocument = Omit<EmployeeDocument, keyof AuditFields>

export type UpdateEmployeeDocument = Partial<Omit<EmployeeDocument, keyof AuditFields>> & { id: number }
