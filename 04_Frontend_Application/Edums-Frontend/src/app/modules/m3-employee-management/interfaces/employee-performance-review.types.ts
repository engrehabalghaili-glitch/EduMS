import type { AuditFields, AcademicScope } from './shared.types'

export type ReviewPeriodType = 'سنوي' | 'نصف_سنوي' | 'ربع_سنوي' | 'شهري'
export type PerformanceLevel = 'ممتاز' | 'جيد_جداً' | 'جيد' | 'مقبول' | 'ضعيف'
export type ReviewApprovalStatus = 'قيد_المراجعة' | 'معتمد' | 'مرفوض' | 'مطعون'

export interface EmployeePerformanceReviewData {
  employeeId: number
  reviewPeriodType: ReviewPeriodType
  reviewPeriodStart: string
  reviewPeriodEnd: string
  reviewedByEmployeeId: number
  reviewDate: string
  overallScore: number
  performanceLevel: PerformanceLevel | null
  kpiScoresJson: string | null
  strengthsText: string | null
  areasForImprovementText: string | null
  developmentPlanText: string | null
  employeeResponseText: string | null
  approvalStatus: ReviewApprovalStatus
  isDisputed: boolean
  disputeReason: string | null
  disputeDate: string | null
  finalDecisionText: string | null
  notes: string | null
}

export interface EmployeePerformanceReview extends AuditFields, AcademicScope, EmployeePerformanceReviewData {}

export type CreateEmployeePerformanceReview = Omit<EmployeePerformanceReview, keyof AuditFields>

export type UpdateEmployeePerformanceReview = Partial<Omit<EmployeePerformanceReview, keyof AuditFields>> & { id: number }
