export interface CreateStudentFinancialAidApplicationPayload {
    studentId: number;
    guardianId: number;
    applicationReferenceNumber: string;
    applicationDate: string;
    aidCategory: number;
    requestedAidAmountOrPercentage: number;
    verifiedGuardianAnnualIncome: number;
    familyMembersCount: number;
    approvedDiscountPercentage: number;
    reviewedByCommitteeEmployeeId?: number;
    incomeProofAttachmentUrl?: string;
    committeeDecisionRemarks?: string;
}

export interface StudentFinancialAidApplication {
    id: number;
    studentId: number;
    guardianId: number;
    applicationReferenceNumber: string;
    applicationDate: string;
    aidCategory: number;
    requestedAidAmountOrPercentage: number;
    verifiedGuardianAnnualIncome: number;
    familyMembersCount: number;
    applicationStatus: number;
    approvedDiscountPercentage: number;
    reviewedByCommitteeEmployeeId?: number;
    incomeProofAttachmentUrl?: string;
    committeeDecisionRemarks?: string;
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

export interface UpdateStudentFinancialAidApplicationPayload {
    id?: number;
    guardianId?: number;
    applicationReferenceNumber?: string;
    applicationDate?: string;
    aidCategory?: number;
    requestedAidAmountOrPercentage?: number;
    verifiedGuardianAnnualIncome?: number;
    familyMembersCount?: number;
    approvedDiscountPercentage?: number;
    reviewedByCommitteeEmployeeId?: number;
    incomeProofAttachmentUrl?: string;
    committeeDecisionRemarks?: string;
}
