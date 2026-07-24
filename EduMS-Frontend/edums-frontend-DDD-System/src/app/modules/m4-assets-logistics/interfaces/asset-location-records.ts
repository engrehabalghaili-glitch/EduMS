export interface AssetLocationRecord {
  id: number;
  schoolId: number;
  parentLocationId: number | null;
  locationCode: string;
  locationNameAr: string;
  locationNameEn: string | null;
  locationType: number;
  buildingName: string | null;
  floorNumber: number | null;
  roomNumber: string | null;
  isActive: boolean;
  responsiblePersonId: number | null;
  mapReference: string | null;
  qrCode: string | null;
  notes: string | null;
}

export type CreateAssetLocationRecordRequest = Omit<AssetLocationRecord, 'id'>;
export type UpdateAssetLocationRecordRequest = AssetLocationRecord;
