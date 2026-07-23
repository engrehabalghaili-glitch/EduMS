export interface CreateCurriculumTextbookDistributionPayload {
    schoolId: number;
    subjectId: number;
    textbookCode: string;
    textbookTitleAr: string;
    textbookTitleEn: string;
    editionYear: number;
    quantityAllocated: number;
    quantityDistributed: number;
    distributionDate: string;
    targetGradeLevel: number;
    unitCost: number;
    totalValueAmount: number;
    warehouseLocationCode?: string;
}

export interface CurriculumTextbookDistribution {
    id: number;
    schoolId: number;
    subjectId: number;
    textbookCode: string;
    textbookTitleAr: string;
    textbookTitleEn: string;
    editionYear: number;
    quantityAllocated: number;
    quantityDistributed: number;
    distributionDate: string;
    targetGradeLevel: number;
    unitCost: number;
    totalValueAmount: number;
    warehouseLocationCode?: string;
    isActive: boolean;
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

export interface UpdateCurriculumTextbookDistributionPayload {
    id?: number;
    subjectId?: number;
    textbookCode?: string;
    textbookTitleAr?: string;
    textbookTitleEn?: string;
    editionYear?: number;
    quantityAllocated?: number;
    quantityDistributed?: number;
    distributionDate?: string;
    targetGradeLevel?: number;
    unitCost?: number;
    totalValueAmount?: number;
    warehouseLocationCode?: string;
}
