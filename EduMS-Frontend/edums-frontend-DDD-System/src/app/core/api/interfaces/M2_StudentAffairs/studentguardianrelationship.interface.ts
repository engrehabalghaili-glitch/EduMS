export interface CreateStudentGuardianRelationshipPayload {
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
}

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
    createdByUserId: number;
    modifiedAt?: string;
    modifiedByUserId?: number;
    isDeleted: boolean;
    deletedAt?: string;
    deletedByUserId?: number;
    versionToken: string;
    lastSyncedAt?: string;
    syncStatus: string;
}

export interface UpdateStudentGuardianRelationshipPayload {
    id?: number;
    guardianId?: number;
    relationshipType?: number;
    isPrimaryContact?: boolean;
    isEmergencyContact?: boolean;
    hasFinancialResponsibility?: boolean;
    hasLegalCustody?: boolean;
    custodyDocumentReference?: string;
    isAuthorizedForMedicalDecisions?: boolean;
    isLivingTogether?: boolean;
}
