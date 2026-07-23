export interface CreateSchoolPayload {
    directorateId?: number;
    educationalStageId?: number;
    schoolNameAr: string;
    schoolNameEn: string;
    schoolCode: string;
    directorate: string;
    governorate: string;
    establishmentDate?: string;
    contactPhone?: string;
    contactEmail?: string;
    websiteUrl?: string;
    postalAddress?: string;
    taxRegistrationNumber?: string;
    commercialLicenseNumber?: string;
    maxStudentCapacity: number;
    isAccredited: boolean;
}

export interface School {
    id: number;
    directorateId?: number;
    educationalStageId?: number;
    schoolNameAr: string;
    schoolNameEn: string;
    schoolCode: string;
    directorate: string;
    governorate: string;
    establishmentDate?: string;
    contactPhone?: string;
    contactEmail?: string;
    websiteUrl?: string;
    postalAddress?: string;
    taxRegistrationNumber?: string;
    commercialLicenseNumber?: string;
    maxStudentCapacity: number;
    isAccredited: boolean;
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

export interface UpdateSchoolPayload {
    id?: number;
    educationalStageId?: number;
    schoolNameAr?: string;
    schoolNameEn?: string;
    schoolCode?: string;
    directorate?: string;
    governorate?: string;
    establishmentDate?: string;
    contactPhone?: string;
    contactEmail?: string;
    websiteUrl?: string;
    postalAddress?: string;
    taxRegistrationNumber?: string;
    commercialLicenseNumber?: string;
    maxStudentCapacity?: number;
    isAccredited?: boolean;
}
