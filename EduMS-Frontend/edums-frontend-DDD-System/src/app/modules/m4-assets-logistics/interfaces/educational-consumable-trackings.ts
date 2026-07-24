export interface EducationalConsumableTracking {
  id: number;
  schoolId: number;
  consumableName: string;
  consumableCode: string | null;
  category: string | null;
  quantityConsumed: number;
  unitOfMeasure: string;
  consumptionDate: string;
  consumedByUserId: number | null;
  departmentId: number | null;
  subjectId: number | null;
  purpose: string | null;
  unitCost: number;
  totalCost: number;
  budgetLineCode: string | null;
  notes: string | null;
}

export type CreateEducationalConsumableTrackingRequest = Omit<EducationalConsumableTracking, 'id'>;
export type UpdateEducationalConsumableTrackingRequest = EducationalConsumableTracking;
