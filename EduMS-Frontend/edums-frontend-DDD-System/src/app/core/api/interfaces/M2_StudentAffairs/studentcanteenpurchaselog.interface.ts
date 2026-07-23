export interface CreateStudentCanteenPurchaseLogPayload {
    studentId: number;
    schoolCanteenItemId: number;
    purchaseDate: string;
    quantityPurchased: number;
    totalCost: number;
    paymentMethod: number;
    servedByEmployeeId?: number;
    transactionReferenceNumber?: string;
    nutritionalCalorieCount: number;
    isAllergyAlertTriggered: boolean;
    paymentTransactionId?: number;
}

export interface StudentCanteenPurchaseLog {
    id: number;
    studentId: number;
    schoolCanteenItemId: number;
    purchaseDate: string;
    quantityPurchased: number;
    totalCost: number;
    paymentMethod: number;
    servedByEmployeeId?: number;
    transactionReferenceNumber?: string;
    nutritionalCalorieCount: number;
    isAllergyAlertTriggered: boolean;
    paymentTransactionId?: number;
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

export interface UpdateStudentCanteenPurchaseLogPayload {
    id?: number;
    schoolCanteenItemId?: number;
    purchaseDate?: string;
    quantityPurchased?: number;
    totalCost?: number;
    paymentMethod?: number;
    servedByEmployeeId?: number;
    transactionReferenceNumber?: string;
    nutritionalCalorieCount?: number;
    isAllergyAlertTriggered?: boolean;
    paymentTransactionId?: number;
}
