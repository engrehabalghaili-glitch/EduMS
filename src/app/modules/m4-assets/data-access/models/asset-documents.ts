export interface AssetDocument {
  id: number;
  assetId: number;
  contractId: number | null;
  docType: string;
  docCode: string;
  docNameAr: string;
  description: string | null;
  fileName: string | null;
  filePath: string | null;
  fileType: string | null;
  uploadDate: string | null;
  uploadedByUserId: number | null;
  isVerified: boolean;
  verifiedByUserId: number | null;
  verifiedAt: string | null;
  notes: string | null;
}

export type CreateAssetDocumentRequest = Omit<AssetDocument, 'id'>;
export type UpdateAssetDocumentRequest = AssetDocument;
