export interface StudentExemption {
  id: number;
  studentId: number;
  exemptionCategory: number;
  discountPercentage: number;
  reasonDescription?: string;
  approvedByEmployeeId?: number;
  startDate: string;
  endDate?: string;
  exemptionCode?: string;
  supportingDocumentUrl?: string;
  annualMaxDiscountAmount: number;
  isRenewable: boolean;
  isActive: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentExemption = Omit<StudentExemption, 'id' | 'createdAt' | 'modifiedAt' | 'isActive' | 'approvedByEmployeeId'>;

export type UpdateStudentExemption = CreateStudentExemption & { id: number };
