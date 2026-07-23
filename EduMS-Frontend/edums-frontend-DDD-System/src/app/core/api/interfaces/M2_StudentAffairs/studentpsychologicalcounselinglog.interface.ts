export interface CreateStudentPsychologicalCounselingLogPayload {
    studentId: number;
    counselorEmployeeId: number;
    sessionDate: string;
    sessionCategory: number;
    sessionNotes?: string;
    recommendedIntervention?: string;
    isConfidential: boolean;
    followUpDate?: string;
    referralSource: number;
    riskAssessmentLevel: number;
    isParentInvolved: boolean;
}

export interface StudentPsychologicalCounselingLog {
    id: number;
    studentId: number;
    counselorEmployeeId: number;
    sessionDate: string;
    sessionCategory: number;
    sessionNotes?: string;
    recommendedIntervention?: string;
    isConfidential: boolean;
    followUpDate?: string;
    referralSource: number;
    riskAssessmentLevel: number;
    isParentInvolved: boolean;
    caseStatus: number;
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

export interface UpdateStudentPsychologicalCounselingLogPayload {
    id?: number;
    counselorEmployeeId?: number;
    sessionDate?: string;
    sessionCategory?: number;
    sessionNotes?: string;
    recommendedIntervention?: string;
    isConfidential?: boolean;
    followUpDate?: string;
    referralSource?: number;
    riskAssessmentLevel?: number;
    isParentInvolved?: boolean;
}
