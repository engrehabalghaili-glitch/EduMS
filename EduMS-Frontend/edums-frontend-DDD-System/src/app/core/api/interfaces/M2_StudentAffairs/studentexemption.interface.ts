export interface CreateStudentExemptionPayload {
    studentId: number;
    exemptionCategory: number;
    discountPercentage: number;
    reasonDescription?: string;
    startDate: string;
    endDate?: string;
    exemptionCode?: string;
    supportingDocumentUrl?: string;
    annualMaxDiscountAmount: number;
    isRenewable: boolean;
}

export interface StudentExemption {
    id: number;
    studentId: number;
    exemptionCategory: number;
    discountPercentage: number;
    reasonDescription?: string;
    approvedByEmployeeId?: number;
    startDate: string;
    endDate?: string;
    exemptionCode?: string;
    supportingDocumentUrl?: string;
    annualMaxDiscountAmount: number;
    isRenewable: boolean;
    isActive: boolean;
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

export interface UpdateStudentExemptionPayload {
    id?: number;
    exemptionCategory?: number;
    discountPercentage?: number;
    reasonDescription?: string;
    startDate?: string;
    endDate?: string;
    exemptionCode?: string;
    supportingDocumentUrl?: string;
    annualMaxDiscountAmount?: number;
    isRenewable?: boolean;
}
