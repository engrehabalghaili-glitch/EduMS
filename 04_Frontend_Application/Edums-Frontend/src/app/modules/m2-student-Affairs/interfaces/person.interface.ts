import { Gender } from './_types';

export interface Person {
  id: number;
  fullNameAr: string;
  fullNameEn: string;
  nationalId: string;
  gender: Gender;
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
  modifiedAt?: string;
}

export type CreatePerson = Omit<Person, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdatePerson = CreatePerson & { id: number };
