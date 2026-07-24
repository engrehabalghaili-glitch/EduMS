import type { MaintenanceType, RecordStatus } from './common';

export interface SchoolFacilityMaintenanceLog {
  id: number;
  schoolFacilityId: number;
  maintenanceCode: string;
  scheduledDate: string;
  completedDate: string | null;
  maintenanceType: MaintenanceType;
  descriptionDetails: string;
  totalCostAmount: number;
  responsibleEmployeeId: number | null;
  externalContractorName: string | null;
  status: RecordStatus;
  inspectionRemarks: string | null;
}

export type CreateSchoolFacilityMaintenanceLogDto = Omit<SchoolFacilityMaintenanceLog, 'id' | 'status'>;

export type UpdateSchoolFacilityMaintenanceLogDto = Omit<SchoolFacilityMaintenanceLog, 'status'>;
