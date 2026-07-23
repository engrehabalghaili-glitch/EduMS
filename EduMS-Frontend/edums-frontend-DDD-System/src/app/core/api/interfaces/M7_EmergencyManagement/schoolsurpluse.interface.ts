export interface CreateSchoolSurplusPayload {
    schoolId: number;
    surplusNumber: string;
    surplusType: string;
    surplusCategory?: string;
    surplusAmount: number;
    availableAmount: number;
    requiredAmount: number;
    surplusDescription?: string;
    utilizationPlan?: string;
    utilizationType?: string;
    potentialBeneficiary?: string;
    discoveryDate: string;
    discoveredByUserId?: number;
    surplusStatus: number;
    statusUpdateDate?: string;
    utilizationDate?: string;
    actualUtilizationDate?: string;
    utilizedByUserId?: number;
    utilizationNotes?: string;
    relatedRemediationPlanId?: number;
    attachmentsJson?: string;
    notes?: string;
}

export interface SchoolSurplus {
    id: number;
    schoolId: number;
    surplusNumber: string;
    surplusType: string;
    surplusCategory?: string;
    surplusAmount: number;
    availableAmount: number;
    requiredAmount: number;
    surplusDescription?: string;
    utilizationPlan?: string;
    utilizationType?: string;
    potentialBeneficiary?: string;
    discoveryDate: string;
    discoveredByUserId?: number;
    surplusStatus: number;
    statusUpdateDate?: string;
    utilizationDate?: string;
    actualUtilizationDate?: string;
    utilizedByUserId?: number;
    utilizationNotes?: string;
    relatedRemediationPlanId?: number;
    attachmentsJson?: string;
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

export interface UpdateSchoolSurplusPayload {
    id?: number;
    schoolId?: number;
    surplusNumber?: string;
    surplusType?: string;
    surplusCategory?: string;
    surplusAmount?: number;
    availableAmount?: number;
    requiredAmount?: number;
    surplusDescription?: string;
    utilizationPlan?: string;
    utilizationType?: string;
    potentialBeneficiary?: string;
    discoveryDate?: string;
    discoveredByUserId?: number;
    surplusStatus?: number;
    statusUpdateDate?: string;
    utilizationDate?: string;
    actualUtilizationDate?: string;
    utilizedByUserId?: number;
    utilizationNotes?: string;
    relatedRemediationPlanId?: number;
    attachmentsJson?: string;
    notes?: string;
}
