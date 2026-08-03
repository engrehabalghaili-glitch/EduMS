import type { FacilityType, MaintenanceStatus } from './common';

export interface SchoolFacility {
  id: number;
  schoolId: number;
  facilityCode: string;
  facilityNameAr: string;
  facilityNameEn: string;
  facilityType: FacilityType;
  capacity: number;
  assignedSupervisorId: number | null;
  isOperational: boolean;
  locationFloor: string | null;
  buildingName: string | null;
  safetyInspectionDate: string | null;
  maintenanceStatus: MaintenanceStatus;
}

export type CreateSchoolFacilityDto = Omit<SchoolFacility, 'id' | 'maintenanceStatus'>;

export type UpdateSchoolFacilityDto = Omit<SchoolFacility, 'schoolId' | 'maintenanceStatus'>;
