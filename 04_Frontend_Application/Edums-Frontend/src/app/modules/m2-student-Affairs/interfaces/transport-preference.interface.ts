import { TransportType } from './_types';

export interface StudentTransportPreference {
  id: number;
  studentId: number;
  schoolAcademicYearId?: number;
  transportType: TransportType;
  preferredBusRouteId?: number;
  pickupAddress?: string;
  pickupGpsLatitude?: string;
  pickupGpsLongitude?: string;
  preferredPickupTime?: string;
  preferredDropoffTime?: string;
  useMorningPickup: boolean;
  useAfternoonDropoff: boolean;
  weeklyDaysJson?: string;
  requiresEscort: boolean;
  escortName?: string;
  escortPhone?: string;
  escortRelationToStudent?: string;
  requiresSpecialNeedsTransport: boolean;
  specialNeedsTransportDetails?: string;
  isWheelchairAccessibleBusRequired: boolean;
  subscriptionStatus: number;
  subscriptionStartDate?: string;
  subscriptionEndDate?: string;
  subscriptionFeeAmount: number;
  isTransportContractSigned: boolean;
  transportContractFileUrl?: string;
  authorizedPickupPersonsJson?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentTransportPreference = Omit<StudentTransportPreference, 'id' | 'createdAt' | 'modifiedAt' | 'subscriptionStatus'>;

export type UpdateStudentTransportPreference = CreateStudentTransportPreference & { id: number };
