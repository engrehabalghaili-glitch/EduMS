export interface StudentGuardianRelationship {
  id: number;
  studentId: number;
  guardianId: number;
  relationshipType: number;
  isPrimaryContact: boolean;
  isEmergencyContact: boolean;
  hasFinancialResponsibility: boolean;
  hasLegalCustody: boolean;
  custodyDocumentReference?: string;
  isAuthorizedForMedicalDecisions: boolean;
  isLivingTogether: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentGuardianRelationship = Omit<StudentGuardianRelationship, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentGuardianRelationship = CreateStudentGuardianRelationship & { id: number };
