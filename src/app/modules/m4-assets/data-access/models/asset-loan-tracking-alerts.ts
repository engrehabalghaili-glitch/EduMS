export interface AssetLoanTrackingAlert {
  id: number;
  loanId: number;
  schoolId: number;
  alertType: number;
  alertDate: string;
  alertMessageText: string;
  deliveryMethod: number;
  isSent: boolean;
  sentToContact: string | null;
  isAcknowledged: boolean;
  acknowledgedAt: string | null;
  violationRecorded: boolean;
  violationId: number | null;
  notes: string | null;
}

export type CreateAssetLoanTrackingAlertRequest = Omit<AssetLoanTrackingAlert, 'id'>;
export type UpdateAssetLoanTrackingAlertRequest = AssetLoanTrackingAlert;
