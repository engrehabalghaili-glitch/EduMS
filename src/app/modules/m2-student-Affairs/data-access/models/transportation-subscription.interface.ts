import { SubscriptionType, SubscriptionStatus } from './_types';

export interface StudentTransportationSubscription {
  id: number;
  studentId: number;
  schoolTransportationRouteId: number;
  subscriptionStartDate: string;
  subscriptionEndDate?: string;
  pickupStationAddress?: string;
  dropoffStationAddress?: string;
  subscriptionStatus: SubscriptionStatus;
  subscriptionType: SubscriptionType;
  agreedMonthlyFee: number;
  pickupTime?: string;
  dropoffTime?: string;
  assignedBusStopOrder: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentTransportationSubscription = Omit<StudentTransportationSubscription, 'id' | 'createdAt' | 'modifiedAt' | 'subscriptionStatus'>;

export type UpdateStudentTransportationSubscription = CreateStudentTransportationSubscription & { id: number };
