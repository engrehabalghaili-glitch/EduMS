export interface CreateGuardianPayload {
    familyNumber: string;
    relationshipType: string;
    jobTitle?: string;
    employerName?: string;
    workPhoneNumber?: string;
    emergencyContactPriority: number;
    isAuthorizedPickup: boolean;
    preferredLanguage?: string;
    annualIncomeRange?: string;
}

export interface Guardian {
    familyNumber: string;
    relationshipType: string;
    jobTitle?: string;
    employerName?: string;
    workPhoneNumber?: string;
    emergencyContactPriority: number;
    isAuthorizedPickup: boolean;
    preferredLanguage?: string;
    annualIncomeRange?: string;
}

export interface UpdateGuardianPayload {
    familyNumber?: string;
    relationshipType?: string;
    jobTitle?: string;
    employerName?: string;
    workPhoneNumber?: string;
    emergencyContactPriority?: number;
    isAuthorizedPickup?: boolean;
    preferredLanguage?: string;
    annualIncomeRange?: string;
}
