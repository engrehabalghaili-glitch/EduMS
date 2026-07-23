export interface CreateStudentMedicalAllergyLogPayload {
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
}

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
    nurseVerificationStatus: number;
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

export interface UpdateStudentMedicalAllergyLogPayload {
    id?: number;
    allergyOrConditionName?: string;
    severityLevel?: number;
    reactionSymptoms?: string;
    emergencyActionProtocol?: string;
    requiredMedicationName?: string;
    reportedDate?: string;
    isEpiPenRequired?: boolean;
    doctorContactNumber?: string;
    lastReactionDate?: string;
}
