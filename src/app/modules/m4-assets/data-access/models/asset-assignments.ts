export interface AssetAssignment {
  id: number;
  assetId: number;
  schoolId: number;
  assigneeType: number;
  assigneeId: number;
  assigneeName: string;
  assignerUserId: number | null;
  assignmentDate: string;
  expectedReturnDate: string | null;
  actualReturnDate: string | null;
  assignmentReason: string | null;
  conditionAtAssignment: number;
  conditionNotesAtAssignment: string | null;
  conditionAtReturn: number;
  conditionNotesAtReturn: string | null;
  penaltyAmount: number;
  penaltyStatus: number;
  assignmentStatus: number;
  isReturned: boolean;
  returnedToUserId: number | null;
  notes: string | null;
}

export type CreateAssetAssignmentRequest = Omit<AssetAssignment, 'id'>;
export type UpdateAssetAssignmentRequest = AssetAssignment;
