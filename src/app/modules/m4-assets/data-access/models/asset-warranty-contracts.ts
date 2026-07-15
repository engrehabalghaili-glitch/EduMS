export interface AssetWarrantyContract {
  id: number;
  schoolId: number;
  contractType: number;
  contractNumber: string;
  contractName: string;
  providerName: string;
  providerContact: string | null;
  startDate: string;
  endDate: string;
  coverageDetailsText: string | null;
  contractValue: number;
  hasRenewalOption: boolean;
  renewalTerms: string | null;
  isActive: boolean;
  contractStatus: number;
  reminderDaysBeforeExpiry: number;
  isAlertEnabled: boolean;
  lastAlertSentDate: string | null;
  attachmentUrl: string | null;
  notes: string | null;
}

export type CreateAssetWarrantyContractRequest = Omit<AssetWarrantyContract, 'id'>;
export type UpdateAssetWarrantyContractRequest = AssetWarrantyContract;
