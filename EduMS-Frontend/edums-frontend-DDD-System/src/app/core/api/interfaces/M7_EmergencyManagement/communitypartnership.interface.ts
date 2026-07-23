export interface CommunityPartnership {
    id: number;
    schoolId: number;
    partnershipNumber: string;
    partnerName: string;
    partnerType?: string;
    supportType?: string;
    agreementDate?: string;
    startDate: string;
    endDate?: string;
    isRenewable: boolean;
    agreementDocumentPath?: string;
    supportValueAmount: number;
    supportValueCurrency?: string;
    supportInKindJson?: string;
    impact?: string;
    impactRating: number;
    responsibleEmployeeId?: number;
    partnerContactPerson?: string;
    partnerContactEmail?: string;
    partnerContactPhone?: string;
    partnershipStatus: number;
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

export interface CreateCommunityPartnershipPayload {
    schoolId: number;
    partnershipNumber: string;
    partnerName: string;
    partnerType?: string;
    supportType?: string;
    agreementDate?: string;
    startDate: string;
    endDate?: string;
    isRenewable: boolean;
    agreementDocumentPath?: string;
    supportValueAmount: number;
    supportValueCurrency?: string;
    supportInKindJson?: string;
    impact?: string;
    impactRating: number;
    responsibleEmployeeId?: number;
    partnerContactPerson?: string;
    partnerContactEmail?: string;
    partnerContactPhone?: string;
    partnershipStatus: number;
    notes?: string;
}

export interface UpdateCommunityPartnershipPayload {
    id?: number;
    schoolId?: number;
    partnershipNumber?: string;
    partnerName?: string;
    partnerType?: string;
    supportType?: string;
    agreementDate?: string;
    startDate?: string;
    endDate?: string;
    isRenewable?: boolean;
    agreementDocumentPath?: string;
    supportValueAmount?: number;
    supportValueCurrency?: string;
    supportInKindJson?: string;
    impact?: string;
    impactRating?: number;
    responsibleEmployeeId?: number;
    partnerContactPerson?: string;
    partnerContactEmail?: string;
    partnerContactPhone?: string;
    partnershipStatus?: number;
    notes?: string;
}
