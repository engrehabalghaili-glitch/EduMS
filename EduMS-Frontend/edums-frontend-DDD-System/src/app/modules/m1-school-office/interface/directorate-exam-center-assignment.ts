import type { RecordStatus } from './common';

export interface DirectorateExamCenterAssignment {
  id: number;
  directorateId: number;
  hostedAtSchoolId: number;
  examCenterCode: string;
  examSessionTitleAr: string;
  academicYear: string;
  targetEducationalStageId: number;
  totalAllocatedCandidatesCount: number;
  totalExaminationRoomsCount: number;
  chiefSuperintendentEmployeeId: number | null;
  residentSecurityOfficerEmployeeId: number | null;
  sessionStartDate: string;
  sessionEndDate: string;
  centerStatus: RecordStatus;
}

export type CreateDirectorateExamCenterAssignmentDto = Omit<DirectorateExamCenterAssignment, 'id' | 'centerStatus'>;

export type UpdateDirectorateExamCenterAssignmentDto = Omit<DirectorateExamCenterAssignment, 'directorateId' | 'centerStatus'>;
