export interface AssetMaintenanceTicket {
  id: number;
  schoolId: number;
  ticketNumber: string;
  assetId: number;
  reportedByUserId: number;
  reportDate: string;
  issueType: number;
  severityLevel: number;
  issueDescriptionText: string;
  assignedToEmployeeId: number | null;
  assignedDate: string | null;
  diagnosis: string | null;
  estimatedCost: number;
  estimatedCompletionDate: string | null;
  actualCompletionDate: string | null;
  resolutionDetails: string | null;
  resolutionCost: number;
  ticketStatus: number;
  closedByUserId: number | null;
  closedAt: string | null;
  attachmentsJson: string | null;
  notes: string | null;
}

export type CreateAssetMaintenanceTicketRequest = Omit<AssetMaintenanceTicket, 'id'>;
export type UpdateAssetMaintenanceTicketRequest = AssetMaintenanceTicket;
