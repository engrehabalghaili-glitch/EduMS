export interface CreateJobApplicantPayload {
    vacantPositionId: number;
    applicantFullNameAr: string;
    applicantFullNameEn?: string;
    nationalIdNumber: string;
    phonePrimary: string;
    emailAddress: string;
    academicQualification: string;
    qualificationSource?: string;
    experienceYears: number;
    cvDocumentUrl?: string;
    coverLetterUrl?: string;
    applicationStatus: number;
    interviewDate?: string;
    interviewNotes?: string;
    rejectionReason?: string;
    reviewedByEmployeeId?: number;
    notes?: string;
}

export interface JobApplicant {
    id: number;
    vacantPositionId: number;
    applicantFullNameAr: string;
    applicantFullNameEn?: string;
    nationalIdNumber: string;
    phonePrimary: string;
    emailAddress: string;
    academicQualification: string;
    qualificationSource?: string;
    experienceYears: number;
    cvDocumentUrl?: string;
    coverLetterUrl?: string;
    applicationStatus: number;
    interviewDate?: string;
    interviewNotes?: string;
    rejectionReason?: string;
    reviewedByEmployeeId?: number;
    notes?: string;
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

export interface UpdateJobApplicantPayload {
    id?: number;
    vacantPositionId?: number;
    applicantFullNameAr?: string;
    applicantFullNameEn?: string;
    nationalIdNumber?: string;
    phonePrimary?: string;
    emailAddress?: string;
    academicQualification?: string;
    qualificationSource?: string;
    experienceYears?: number;
    cvDocumentUrl?: string;
    coverLetterUrl?: string;
    applicationStatus?: number;
    interviewDate?: string;
    interviewNotes?: string;
    rejectionReason?: string;
    reviewedByEmployeeId?: number;
    notes?: string;
}
