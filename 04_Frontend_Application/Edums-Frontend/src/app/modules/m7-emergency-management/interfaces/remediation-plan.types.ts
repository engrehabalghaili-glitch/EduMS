import type { ActionStep, TeamMember } from './shared.types'

export interface RemediationPlan {
  id: number
  schoolId: number
  planNumber: string
  planName: string
  relatedDeficitId?: number
  relatedSurplusId?: number
  planType: 'معالجة عجز' | 'استغلال فائض' | 'تطوير عام'
  selectedOption?: string
  optionDetails?: string
  objectives?: string
  actionSteps?: ActionStep[]
  plannedStartDate?: string
  plannedEndDate?: string
  actualStartDate?: string
  actualEndDate?: string
  estimatedBudget: number
  actualCost: number
  currency?: string
  executionLeadEmployeeId?: number
  executionTeam?: TeamMember[]
  progressPercentage: number
  planStatus: 'مخطط' | 'قيد التنفيذ' | 'مكتمل' | 'متأخر'
  approvalDate?: string
  approvedByUserId?: number
  completionReport?: string
  lessonsLearned?: string
  notes?: string
}

export type CreateRemediationPlan = Omit<RemediationPlan, 'id'>

export type UpdateRemediationPlan = Partial<RemediationPlan> & { id: number }

export type RemediationPlanResponse = RemediationPlan

export type RemediationPlanListResponse = RemediationPlan[]
