export interface InventoryItem {
  id: number;
  warehouseId: number;
  itemName: string;
  itemCode: string | null;
  quantity: number;
  unitOfMeasure: string;
}

export type CreateInventoryItemRequest = Omit<InventoryItem, 'id'>;
export type UpdateInventoryItemRequest = InventoryItem;
