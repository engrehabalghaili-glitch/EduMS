export interface AssetWarrantyContract {
    id: number;
    schoolId: number;
    contractType: number;
    contractNumber: string;
    contractName: string;
    providerName: string;
    providerContact?: string;
    startDate: string;
    endDate: string;
    coverageDetailsText?: string;
    contractValue: number;
    hasRenewalOption: boolean;
    renewalTerms?: string;
    isActive: boolean;
    contractStatus: number;
    reminderDaysBeforeExpiry: number;
    isAlertEnabled: boolean;
    lastAlertSentDate?: string;
    attachmentUrl?: string;
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

export interface CreateAssetWarrantyContractPayload {
    schoolId: number;
    contractType: number;
    contractNumber: string;
    contractName: string;
    providerName: string;
    providerContact?: string;
    startDate: string;
    endDate: string;
    coverageDetailsText?: string;
    contractValue: number;
    hasRenewalOption: boolean;
    renewalTerms?: string;
    isActive: boolean;
    contractStatus: number;
    reminderDaysBeforeExpiry: number;
    isAlertEnabled: boolean;
    lastAlertSentDate?: string;
    attachmentUrl?: string;
    notes?: string;
}

export interface UpdateAssetWarrantyContractPayload {
    id?: number;
    schoolId?: number;
    contractType?: number;
    contractNumber?: string;
    contractName?: string;
    providerName?: string;
    providerContact?: string;
    startDate?: string;
    endDate?: string;
    coverageDetailsText?: string;
    contractValue?: number;
    hasRenewalOption?: boolean;
    renewalTerms?: string;
    isActive?: boolean;
    contractStatus?: number;
    reminderDaysBeforeExpiry?: number;
    isAlertEnabled?: boolean;
    lastAlertSentDate?: string;
    attachmentUrl?: string;
    notes?: string;
}
