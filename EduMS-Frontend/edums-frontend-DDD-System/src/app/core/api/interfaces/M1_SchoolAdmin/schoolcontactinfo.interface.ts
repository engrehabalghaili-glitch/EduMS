export interface CreateSchoolContactInfoPayload {
    schoolId: number;
    officialPhone: string;
    landline?: string;
    faxNumber?: string;
    officialEmail: string;
    alternativeEmail?: string;
    fullAddress: string;
    streetName?: string;
    buildingNumber: number;
    postalCode?: string;
    districtName?: string;
    city?: string;
    gpsLatitude?: string;
    gpsLongitude?: string;
    locationMapUrl?: string;
    workingHoursJson?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    socialLinksJson?: string;
}

export interface SchoolContactInfo {
    id: number;
    schoolId: number;
    officialPhone: string;
    landline?: string;
    faxNumber?: string;
    officialEmail: string;
    alternativeEmail?: string;
    fullAddress: string;
    streetName?: string;
    buildingNumber: number;
    postalCode?: string;
    districtName?: string;
    city?: string;
    gpsLatitude?: string;
    gpsLongitude?: string;
    locationMapUrl?: string;
    workingHoursJson?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    socialLinksJson?: string;
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

export interface UpdateSchoolContactInfoPayload {
    id?: number;
    officialPhone?: string;
    landline?: string;
    faxNumber?: string;
    officialEmail?: string;
    alternativeEmail?: string;
    fullAddress?: string;
    streetName?: string;
    buildingNumber?: number;
    postalCode?: string;
    districtName?: string;
    city?: string;
    gpsLatitude?: string;
    gpsLongitude?: string;
    locationMapUrl?: string;
    workingHoursJson?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    socialLinksJson?: string;
}
