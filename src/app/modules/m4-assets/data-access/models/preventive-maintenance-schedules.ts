export interface PreventiveMaintenanceSchedule {
  id: number;
  schoolId: number;
  scheduleCode: string;
  assetId: number | null;
  assetCategoryId: number | null;
  taskNameAr: string;
  taskNameEn: string | null;
  maintenanceType: number;
  frequencyUnit: number;
  frequencyValue: number;
  nextDueDate: string | null;
  lastServiceDate: string | null;
  estimatedDurationMinutes: number;
  assignedToTeamText: string | null;
  instructionsText: string | null;
  checklistJson: string | null;
  estimatedCost: number;
  maintenanceContractId: number | null;
  isReminderActive: boolean;
  reminderDaysBefore: number;
  scheduleStatus: number;
  notes: string | null;
}

export type CreatePreventiveMaintenanceScheduleRequest = Omit<PreventiveMaintenanceSchedule, 'id'>;
export type UpdatePreventiveMaintenanceScheduleRequest = PreventiveMaintenanceSchedule;
