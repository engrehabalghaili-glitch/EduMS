export interface AssetComplianceAudit {
  id: number;
  schoolId: number;
  auditNumber: string;
  auditDate: string;
  auditType: number;
  standardType: string | null;
  auditedByUserId: number;
  auditScope: string | null;
  complianceScore: number;
  violationsFoundJson: string | null;
  correctiveActionsRequired: string | null;
  correctiveActionsDeadline: string | null;
  correctiveActionsStatus: number;
  followUpAuditDate: string | null;
  auditReportUrl: string | null;
  auditStatus: number;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateAssetComplianceAuditRequest = Omit<AssetComplianceAudit, 'id'>;
export type UpdateAssetComplianceAuditRequest = AssetComplianceAudit;
