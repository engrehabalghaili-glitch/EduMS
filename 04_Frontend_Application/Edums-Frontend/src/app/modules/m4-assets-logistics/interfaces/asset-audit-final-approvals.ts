export interface AssetAuditFinalApproval {
  id: number;
  schoolId: number;
  inventoryPlanId: number | null;
  complianceAuditId: number | null;
  approvalType: number;
  approvalDate: string;
  approvedByUserId: number;
  approvalDocumentUrl: string | null;
  summaryOfChanges: string | null;
  systemStatusUpdated: boolean;
  statusUpdateDate: string | null;
  statusUpdatedByUserId: number | null;
  notes: string | null;
}

export type CreateAssetAuditFinalApprovalRequest = Omit<AssetAuditFinalApproval, 'id'>;
export type UpdateAssetAuditFinalApprovalRequest = AssetAuditFinalApproval;
