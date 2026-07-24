import { PaymentMethod } from './_types';

export interface StudentCanteenPurchaseLog {
  id: number;
  studentId: number;
  schoolCanteenItemId: number;
  purchaseDate: string;
  quantityPurchased: number;
  totalCost: number;
  paymentMethod: PaymentMethod;
  servedByEmployeeId?: number;
  transactionReferenceNumber?: string;
  nutritionalCalorieCount: number;
  isAllergyAlertTriggered: boolean;
  paymentTransactionId?: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentCanteenPurchaseLog = Omit<StudentCanteenPurchaseLog, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentCanteenPurchaseLog = CreateStudentCanteenPurchaseLog & { id: number };
