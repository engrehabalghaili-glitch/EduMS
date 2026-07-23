export interface CreateStudentComplaintLogPayload {
    studentId: number;
    submittedByGuardianId?: number;
    complaintReferenceNumber: string;
    submissionDate: string;
    complaintCategory: number;
    complaintTitleAr: string;
    complaintDescriptionText: string;
    supportingDocumentUrl?: string;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    expectedResolutionDate?: string;
    actualResolutionDate?: string;
    investigationNotes?: string;
    resolutionDecisionText?: string;
    isGuardianNotifiedOfResolution: boolean;
    guardianNotificationDate?: string;
    guardianSatisfactionRating: number;
    isEscalatedToDirectorate: boolean;
    escalationDate?: string;
}

export interface StudentComplaintLog {
    id: number;
    studentId: number;
    submittedByGuardianId?: number;
    complaintReferenceNumber: string;
    submissionDate: string;
    complaintCategory: number;
    complaintTitleAr: string;
    complaintDescriptionText: string;
    supportingDocumentUrl?: string;
    complaintStatus: number;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    expectedResolutionDate?: string;
    actualResolutionDate?: string;
    investigationNotes?: string;
    resolutionDecisionText?: string;
    isGuardianNotifiedOfResolution: boolean;
    guardianNotificationDate?: string;
    guardianSatisfactionRating: number;
    isEscalatedToDirectorate: boolean;
    escalationDate?: string;
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

export interface UpdateStudentComplaintLogPayload {
    id?: number;
    submittedByGuardianId?: number;
    complaintReferenceNumber?: string;
    submissionDate?: string;
    complaintCategory?: number;
    complaintTitleAr?: string;
    complaintDescriptionText?: string;
    supportingDocumentUrl?: string;
    assignedToEmployeeId?: number;
    assignedDate?: string;
    expectedResolutionDate?: string;
    actualResolutionDate?: string;
    investigationNotes?: string;
    resolutionDecisionText?: string;
    isGuardianNotifiedOfResolution?: boolean;
    guardianNotificationDate?: string;
    guardianSatisfactionRating?: number;
    isEscalatedToDirectorate?: boolean;
    escalationDate?: string;
}
