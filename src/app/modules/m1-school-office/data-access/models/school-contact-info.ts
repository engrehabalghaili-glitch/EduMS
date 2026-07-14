export interface SchoolContactInfo {
  id: number;
  schoolId: number;
  officialPhone: string;
  landline: string | null;
  faxNumber: string | null;
  officialEmail: string;
  alternativeEmail: string | null;
  fullAddress: string;
  streetName: string | null;
  buildingNumber: number;
  postalCode: string | null;
  districtName: string | null;
  city: string | null;
  gpsLatitude: string | null;
  gpsLongitude: string | null;
  locationMapUrl: string | null;
  workingHoursJson: string | null;
  emergencyContactName: string | null;
  emergencyContactPhone: string | null;
  socialLinksJson: string | null;
}

export type CreateSchoolContactInfoDto = Omit<SchoolContactInfo, 'id'>;

export type UpdateSchoolContactInfoDto = Omit<SchoolContactInfo, 'schoolId'>;
