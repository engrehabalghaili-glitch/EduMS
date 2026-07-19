export interface Warehouse {
  id: number;
  warehouseName: string;
  ownerType: string;
  ownerId: number;
  locationAddress: string | null;
  isActive: boolean;
}

export type CreateWarehouseRequest = Omit<Warehouse, 'id'>;
export type UpdateWarehouseRequest = Warehouse;
