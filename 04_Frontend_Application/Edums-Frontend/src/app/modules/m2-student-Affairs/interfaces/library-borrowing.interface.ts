import { StatusNumeric } from './_types';

export interface StudentLibraryBorrowingLog {
  id: number;
  studentId: number;
  schoolLibraryItemId: number;
  borrowedDate: string;
  dueDate: string;
  actualReturnDate?: string;
  borrowingStatus: StatusNumeric;
  latePenaltyFeeAmount: number;
  isPenaltyFeePaid: boolean;
  issuedByLibrarianEmployeeId?: number;
  remarks?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentLibraryBorrowingLog = Omit<StudentLibraryBorrowingLog, 'id' | 'createdAt' | 'modifiedAt' | 'borrowingStatus'>;

export type UpdateStudentLibraryBorrowingLog = CreateStudentLibraryBorrowingLog & { id: number };
