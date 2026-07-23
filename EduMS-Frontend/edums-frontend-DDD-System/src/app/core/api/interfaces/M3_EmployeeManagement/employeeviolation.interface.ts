export interface CreateEmployeeViolationPayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    violationReferenceNumber: string;
    violationDate: string;
    violationCategory: number;
    violationDescriptionAr: string;
    supportingDocumentUrl?: string;
    sanctionType: number;
    penaltyDeductionAmount: number;
    violationStatus: number;
    reportedByEmployeeId?: number;
    investigatingEmployeeId?: number;
    investigationDate?: string;
    investigationNotes?: string;
    decisionText?: string;
    decisionDate?: string;
    isAppealed: boolean;
    appealDate?: string;
    appealResult?: string;
    notes?: string;
}

export interface EmployeeViolation {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    violationReferenceNumber: string;
    violationDate: string;
    violationCategory: number;
    violationDescriptionAr: string;
    supportingDocumentUrl?: string;
    sanctionType: number;
    penaltyDeductionAmount: number;
    violationStatus: number;
    reportedByEmployeeId?: number;
    investigatingEmployeeId?: number;
    investigationDate?: string;
    investigationNotes?: string;
    decisionText?: string;
    decisionDate?: string;
    isAppealed: boolean;
    appealDate?: string;
    appealResult?: string;
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

export interface UpdateEmployeeViolationPayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    violationReferenceNumber?: string;
    violationDate?: string;
    violationCategory?: number;
    violationDescriptionAr?: string;
    supportingDocumentUrl?: string;
    sanctionType?: number;
    penaltyDeductionAmount?: number;
    violationStatus?: number;
    reportedByEmployeeId?: number;
    investigatingEmployeeId?: number;
    investigationDate?: string;
    investigationNotes?: string;
    decisionText?: string;
    decisionDate?: string;
    isAppealed?: boolean;
    appealDate?: string;
    appealResult?: string;
    notes?: string;
}
