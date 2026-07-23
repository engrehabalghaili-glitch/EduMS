export interface CreateEducationalConsumableTrackingPayload {
    schoolId: number;
    consumableName: string;
    consumableCode?: string;
    category?: string;
    quantityConsumed: number;
    unitOfMeasure: string;
    consumptionDate: string;
    consumedByUserId?: number;
    departmentId?: number;
    subjectId?: number;
    purpose?: string;
    unitCost: number;
    totalCost: number;
    budgetLineCode?: string;
    notes?: string;
}

export interface EducationalConsumableTracking {
    id: number;
    schoolId: number;
    consumableName: string;
    consumableCode?: string;
    category?: string;
    quantityConsumed: number;
    unitOfMeasure: string;
    consumptionDate: string;
    consumedByUserId?: number;
    departmentId?: number;
    subjectId?: number;
    purpose?: string;
    unitCost: number;
    totalCost: number;
    budgetLineCode?: string;
    notes?: string;
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

export interface UpdateEducationalConsumableTrackingPayload {
    id?: number;
    schoolId?: number;
    consumableName?: string;
    consumableCode?: string;
    category?: string;
    quantityConsumed?: number;
    unitOfMeasure?: string;
    consumptionDate?: string;
    consumedByUserId?: number;
    departmentId?: number;
    subjectId?: number;
    purpose?: string;
    unitCost?: number;
    totalCost?: number;
    budgetLineCode?: string;
    notes?: string;
}
