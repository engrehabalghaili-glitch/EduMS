import { ItemCondition, PenaltyStatus } from './_types';

export interface StudentInventoryCustody {
  id: number;
  studentId: number;
  schoolAcademicYearId?: number;
  itemType: number;
  itemCode: string;
  itemNameAr: string;
  itemNameEn?: string;
  quantityDelivered: number;
  conditionAtDelivery: ItemCondition;
  conditionNotes?: string;
  deliveryDate: string;
  deliveredByEmployeeId?: number;
  receivedByName: string;
  expectedReturnDate?: string;
  actualReturnDate?: string;
  conditionAtReturn: ItemCondition;
  returnNotes?: string;
  isReturned: boolean;
  isDamaged: boolean;
  damageDescription?: string;
  damageDiscoveredDate?: string;
  isLost: boolean;
  lostReportedDate?: string;
  penaltyAmount: number;
  penaltyStatus: PenaltyStatus;
  penaltyPaidDate?: string;
  isExemptFromPenalty: boolean;
  exemptionReason?: string;
  replacementRequired: boolean;
  notes?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentInventoryCustody = Omit<StudentInventoryCustody, 'id' | 'createdAt' | 'modifiedAt' | 'penaltyStatus'>;

export type UpdateStudentInventoryCustody = CreateStudentInventoryCustody & { id: number };
