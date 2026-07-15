export interface AssetReceiving {
  id: number;
  schoolId: number;
  purchaseOrderId: number;
  receivingNumber: string;
  receivedDate: string;
  receivedByEmployeeId: number;
  inspectorEmployeeId: number | null;
  deliveryNoteNumber: string | null;
  deliveryCompany: string | null;
  inspectionResult: number;
  inspectionDate: string | null;
  inspectionNotes: string | null;
  deliveryStatus: number;
  receivedItemsDetailsJson: string | null;
  rejectedItemsJson: string | null;
  returnRequested: boolean;
  returnDate: string | null;
  finalDecision: number;
  attachmentsJson: string | null;
  receivingStatus: number;
  notes: string | null;
}

export type CreateAssetReceivingRequest = Omit<AssetReceiving, 'id'>;
export type UpdateAssetReceivingRequest = AssetReceiving;
