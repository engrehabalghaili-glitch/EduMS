export interface FacilityDepartmentAssignment {
  id: number;
  schoolId: number;
  facilityType: number;
  facilityId: number;
  departmentId: number | null;
  responsibleEmployeeId: number | null;
  assignmentType: number;
  startDate: string;
  endDate: string | null;
  isShared: boolean;
  sharedWithDepartmentsJson: string | null;
  sharingScheduleJson: string | null;
  priority: number;
  assignmentStatus: number;
  notes: string | null;
}

export type CreateFacilityDepartmentAssignmentRequest = Omit<FacilityDepartmentAssignment, 'id'>;
export type UpdateFacilityDepartmentAssignmentRequest = FacilityDepartmentAssignment;
