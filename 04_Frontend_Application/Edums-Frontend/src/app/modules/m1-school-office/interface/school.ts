export interface School {
  id: number;
  directorateId: number | null;
  educationalStageId: number | null;
  schoolNameAr: string;
  schoolNameEn: string;
  schoolCode: string;
  directorate: string;
  governorate: string;
  establishmentDate: string | null;
  contactPhone: string | null;
  contactEmail: string | null;
  websiteUrl: string | null;
  postalAddress: string | null;
  taxRegistrationNumber: string | null;
  commercialLicenseNumber: string | null;
  maxStudentCapacity: number;
  isAccredited: boolean;
  isActive: boolean;
}

export type CreateSchoolDto = Omit<School, 'id' | 'isActive'>;

export type UpdateSchoolDto = Omit<School, 'isActive' | 'directorateId'>;
