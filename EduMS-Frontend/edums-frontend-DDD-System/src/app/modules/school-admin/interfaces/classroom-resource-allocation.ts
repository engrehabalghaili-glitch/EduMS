import type { ResourceType } from './common';

export interface ClassroomResourceAllocation {
  id: number;
  classroomId: number;
  resourceNameAr: string;
  resourceCode: string;
  resourceType: ResourceType;
  quantity: number;
  assignedDate: string;
  conditionStatus: string | null;
  resourceNameEn: string | null;
  assetSerialNumber: string | null;
  unitPurchaseCost: number;
  lastInspectionDate: string | null;
  nextMaintenanceDate: string | null;
}

export type CreateClassroomResourceAllocationDto = Omit<ClassroomResourceAllocation, 'id' | 'conditionStatus'>;

export type UpdateClassroomResourceAllocationDto = Omit<ClassroomResourceAllocation, 'conditionStatus'>;
