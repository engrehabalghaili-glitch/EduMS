import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { InventoryItemService } from '../services/inventory-item.service';
import type { InventoryItem, CreateInventoryItemRequest, UpdateInventoryItemRequest } from '../models/inventory-items';

interface InventoryItemState {
  inventoryItems: InventoryItem[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InventoryItemState = {
  inventoryItems: [],
  isLoading: false,
  error: null,
};

export const InventoryItemStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, inventoryItemService = inject(InventoryItemService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            inventoryItemService.getAll().pipe(
              tapResponse({
                next: (inventoryItems: InventoryItem[]) =>
                  patchState(store, { inventoryItems, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByWarehouseId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((warehouseId) =>
            inventoryItemService.getByWarehouseId(warehouseId).pipe(
              tapResponse({
                next: (inventoryItems: InventoryItem[]) =>
                  patchState(store, { inventoryItems, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewInventoryItem: rxMethod<CreateInventoryItemRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            inventoryItemService.create(dto).pipe(
              tapResponse({
                next: (entity: InventoryItem) =>
                  patchState(store, {
                    inventoryItems: [...store.inventoryItems(), entity],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateInventoryItem: rxMethod<{ id: number; dto: UpdateInventoryItemRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            inventoryItemService.update(id, dto).pipe(
              tapResponse({
                next: (updated: InventoryItem) =>
                  patchState(store, {
                    inventoryItems: store
                      .inventoryItems()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeInventoryItem: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            inventoryItemService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    inventoryItems: store.inventoryItems().filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);