export interface CreateEnrollmentFinancialLinkPayload {
    enrollmentId: number;
    studentAccountId: number;
    studentId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    tuitionFeeDue: number;
    discountApplied: number;
    exemptionApplied: number;
    netPayable: number;
    isSettled: boolean;
    settlementDate?: string;
    notes?: string;
}

export interface EnrollmentFinancialLink {
    id: number;
    enrollmentId: number;
    studentAccountId: number;
    studentId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    tuitionFeeDue: number;
    discountApplied: number;
    exemptionApplied: number;
    netPayable: number;
    isSettled: boolean;
    settlementDate?: string;
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

export interface UpdateEnrollmentFinancialLinkPayload {
    id?: number;
    enrollmentId?: number;
    studentAccountId?: number;
    studentId?: number;
    schoolId?: number;
    schoolAcademicYearId?: number;
    tuitionFeeDue?: number;
    discountApplied?: number;
    exemptionApplied?: number;
    netPayable?: number;
    isSettled?: boolean;
    settlementDate?: string;
    notes?: string;
}
