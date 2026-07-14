import { Person } from './person.interface';

export interface Guardian extends Person {
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

export type CreateGuardian = Omit<Guardian, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateGuardian = CreateGuardian & { id: number };
