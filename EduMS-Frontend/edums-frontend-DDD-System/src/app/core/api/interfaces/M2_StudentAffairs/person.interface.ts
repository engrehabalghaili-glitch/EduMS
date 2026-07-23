export interface CreatePersonPayload {
    fullNameAr: string;
    fullNameEn: string;
    nationalId: string;
    gender: number;
    contactNumber?: string;
    medicalInfo?: string;
    dateOfBirth?: string;
    placeOfBirth?: string;
    nationalityCode?: string;
    emailAddress?: string;
    bloodGroup?: string;
    residentialAddress?: string;
    passportNumber?: string;
    isActivePerson: boolean;
}

export interface Person {
    id: number;
    fullNameAr: string;
    fullNameEn: string;
    nationalId: string;
    gender: number;
    contactNumber?: string;
    medicalInfo?: string;
    dateOfBirth?: string;
    placeOfBirth?: string;
    nationalityCode?: string;
    emailAddress?: string;
    bloodGroup?: string;
    residentialAddress?: string;
    passportNumber?: string;
    isActivePerson: boolean;
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

export interface UpdatePersonPayload {
    id?: number;
    fullNameAr?: string;
    fullNameEn?: string;
    nationalId?: string;
    gender?: number;
    contactNumber?: string;
    medicalInfo?: string;
    dateOfBirth?: string;
    placeOfBirth?: string;
    nationalityCode?: string;
    emailAddress?: string;
    bloodGroup?: string;
    residentialAddress?: string;
    passportNumber?: string;
    isActivePerson?: boolean;
}
