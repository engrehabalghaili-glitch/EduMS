export interface CreateStudentLibraryBorrowingLogPayload {
    studentId: number;
    schoolLibraryItemId: number;
    borrowedDate: string;
    dueDate: string;
    actualReturnDate?: string;
    latePenaltyFeeAmount: number;
    isPenaltyFeePaid: boolean;
    issuedByLibrarianEmployeeId?: number;
    remarks?: string;
}

export interface StudentLibraryBorrowingLog {
    id: number;
    studentId: number;
    schoolLibraryItemId: number;
    borrowedDate: string;
    dueDate: string;
    actualReturnDate?: string;
    borrowingStatus: number;
    latePenaltyFeeAmount: number;
    isPenaltyFeePaid: boolean;
    issuedByLibrarianEmployeeId?: number;
    remarks?: string;
    createdAt: string;
    createdByUserId: number;
    modifiedAt?: string;
    modifiedByUserId?: number;
    isDeleted: boolean;
    deletedAt?: string;
    deletedByUserId?: number;
    versionToken: string;
    lastSyncedAt?: string;
    syncStatus: string;
}

export interface UpdateStudentLibraryBorrowingLogPayload {
    id?: number;
    schoolLibraryItemId?: number;
    borrowedDate?: string;
    dueDate?: string;
    actualReturnDate?: string;
    latePenaltyFeeAmount?: number;
    isPenaltyFeePaid?: boolean;
    issuedByLibrarianEmployeeId?: number;
    remarks?: string;
}
