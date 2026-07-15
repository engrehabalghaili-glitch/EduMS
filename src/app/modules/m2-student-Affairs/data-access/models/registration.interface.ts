import { Gender, RequestStatus } from './_types';

export interface Registration {
  id: number;
  parentId: number;
  schoolId: number;
  firstNameAr: string;
  fatherNameAr: string;
  grandfatherNameAr: string;
  familyNameAr: string;
  firstNameEn: string;
  fatherNameEn: string;
  grandfatherNameEn: string;
  familyNameEn: string;
  birthDate: string;
  birthPlace: string;
  countryOfBirth: string;
  gender: Gender;
  nationality: string;
  address: string;
  motherName: string;
  motherNationality: string;
  motherPhone: string;
  birthCertificate?: string;
  personalPhoto?: string;
  idCardImage?: string;
  previousSchool?: string;
  previousGrade?: string;
  requestedGradeLevelId: number;
  academicYearId: number;
  hasSpecialNeeds: boolean;
  specialNeedsDetails?: string;
  medicalNotes?: string;
  siblingInSchool: boolean;
  siblingNames?: string;
  referralSource?: string;
  emergencyContactName: string;
  emergencyContactPhone: string;
  emergencyContactRelation: string;
  requestStatus: RequestStatus;
  submissionDate: string;
  reviewedByUserId?: number;
  reviewDate?: string;
  rejectionReason?: string;
  approvalDate?: string;
  convertedToStudentId?: number;
}

export type CreateRegistration = Omit<Registration, 'id' | 'requestStatus' | 'submissionDate' | 'reviewedByUserId' | 'reviewDate' | 'rejectionReason' | 'approvalDate' | 'convertedToStudentId'>;

export type UpdateRegistration = CreateRegistration & { id: number };
