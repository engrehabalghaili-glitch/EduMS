export interface EmergencyPlan {
  id: number
  schoolId: number
  planCode: string
  planTitleAr: string
  planTitleEn: string
  evacuationProcedureSummary: string
  nextScheduledDrillDate: string
  isActive: boolean
}

export type CreateEmergencyPlan = Omit<EmergencyPlan, 'id'>

export type UpdateEmergencyPlan = Partial<EmergencyPlan> & { id: number }

export type EmergencyPlanResponse = EmergencyPlan

export type EmergencyPlanListResponse = EmergencyPlan[]
