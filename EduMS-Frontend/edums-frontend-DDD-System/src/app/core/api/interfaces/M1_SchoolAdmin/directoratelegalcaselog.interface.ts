export interface CreateDirectorateLegalCaseLogPayload {
    directorateId: number;
    caseCodeNumber: string;
    caseCategory: number;
    subjectTitle: string;
    involvedPartiesDescription: string;
    registrationDate: string;
    resolutionDate?: string;
    resolutionDecisionText?: string;
    assignedLegalCounselEmployeeId?: number;
    caseDocumentAttachmentUrl?: string;
}

export interface DirectorateLegalCaseLog {
    id: number;
    directorateId: number;
    caseCodeNumber: string;
    caseCategory: number;
    subjectTitle: string;
    involvedPartiesDescription: string;
    registrationDate: string;
    resolutionDate?: string;
    caseStatus: number;
    resolutionDecisionText?: string;
    assignedLegalCounselEmployeeId?: number;
    caseDocumentAttachmentUrl?: string;
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

export interface UpdateDirectorateLegalCaseLogPayload {
    id?: number;
    caseCodeNumber?: string;
    caseCategory?: number;
    subjectTitle?: string;
    involvedPartiesDescription?: string;
    registrationDate?: string;
    resolutionDate?: string;
    resolutionDecisionText?: string;
    assignedLegalCounselEmployeeId?: number;
    caseDocumentAttachmentUrl?: string;
}
