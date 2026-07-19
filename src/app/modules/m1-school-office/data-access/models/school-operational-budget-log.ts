import type { RecordStatus } from './common';

export interface SchoolOperationalBudgetLog {
  id: number;
  directorateId: number | null;
  schoolId: number | null;
  fiscalYear: string;
  budgetCategoryCode: string;
  categoryNameAr: string;
  allocatedAmount: number;
  consumedAmount: number;
  remainingAmount: number;
  status: RecordStatus;
  categoryNameEn: string | null;
  quarterNumber: number;
  approvedByDirectorId: number | null;
  lastTransactionDate: string | null;
  notesDescription: string | null;
}

export type CreateSchoolOperationalBudgetLogDto = Omit<SchoolOperationalBudgetLog, 'id' | 'status' | 'approvedByDirectorId'>;

export type UpdateSchoolOperationalBudgetLogDto = Omit<SchoolOperationalBudgetLog, 'directorateId' | 'schoolId' | 'status' | 'approvedByDirectorId'>;
