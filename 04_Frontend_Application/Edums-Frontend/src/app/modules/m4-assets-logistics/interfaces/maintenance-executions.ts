export interface MaintenanceExecution {
  id: number;
  schoolId: number;
  executionNumber: string;
  maintenanceTicketId: number | null;
  preventiveScheduleId: number | null;
  assetId: number;
  executionType: number;
  startDateTime: string;
  endDateTime: string | null;
  executedByEmployeeId: number;
  workPerformedDescription: string;
  sparePartsUsedJson: string | null;
  maintenanceCost: number;
  isOperationalAfterMaintenance: boolean;
  newAssetStatusId: number | null;
  resolutionSummary: string | null;
  attachmentsJson: string | null;
  executionStatus: number;
  notes: string | null;
}

export type CreateMaintenanceExecutionRequest = Omit<MaintenanceExecution, 'id'>;
export type UpdateMaintenanceExecutionRequest = MaintenanceExecution;
