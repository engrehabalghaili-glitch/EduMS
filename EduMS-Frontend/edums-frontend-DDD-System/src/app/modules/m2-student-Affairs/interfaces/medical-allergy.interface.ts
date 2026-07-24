import { VerificationStatus } from './_types';

export interface StudentMedicalAllergyLog {
  id: number;
  studentId: number;
  allergyOrConditionName: string;
  severityLevel: number;
  reactionSymptoms?: string;
  emergencyActionProtocol?: string;
  requiredMedicationName?: string;
  reportedDate: string;
  isEpiPenRequired: boolean;
  doctorContactNumber?: string;
  lastReactionDate?: string;
  nurseVerificationStatus: VerificationStatus;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentMedicalAllergyLog = Omit<StudentMedicalAllergyLog, 'id' | 'createdAt' | 'modifiedAt' | 'nurseVerificationStatus'>;

export type UpdateStudentMedicalAllergyLog = CreateStudentMedicalAllergyLog & { id: number };
