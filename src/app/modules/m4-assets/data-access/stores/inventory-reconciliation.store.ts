import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { InventoryReconciliationService } from '../services/inventory-reconciliation.service';
import type { InventoryReconciliation, CreateInventoryReconciliationRequest, UpdateInventoryReconciliationRequest } from '../models/inventory-reconciliations';

interface InventoryReconciliationState {
  inventoryReconciliations: InventoryReconciliation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InventoryReconciliationState = {
  inventoryReconciliations: [],
  isLoading: false,
  error: null,
};

export const InventoryReconciliationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, inventoryReconciliationService = inject(InventoryReconciliationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            inventoryReconciliationService.getAll().pipe(
              tapResponse({
                next: (inventoryReconciliations: InventoryReconciliation[]) =>
                  patchState(store, { inventoryReconciliations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByInventoryPlanId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((inventoryPlanId) =>
            inventoryReconciliationService.getByInventoryPlanId(inventoryPlanId).pipe(
              tapResponse({
                next: (inventoryReconciliations: InventoryReconciliation[]) =>
                  patchState(store, { inventoryReconciliations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewInventoryReconciliation: rxMethod<CreateInventoryReconciliationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            inventoryReconciliationService.create(dto).pipe(
              tapResponse({
                next: (entity: InventoryReconciliation) =>
                  patchState(store, {
                    inventoryReconciliations: [...store.inventoryReconciliations(), entity],
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

      updateInventoryReconciliation: rxMethod<{ id: number; dto: UpdateInventoryReconciliationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            inventoryReconciliationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: InventoryReconciliation) =>
                  patchState(store, {
                    inventoryReconciliations: store
                      .inventoryReconciliations()
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

      removeInventoryReconciliation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            inventoryReconciliationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    inventoryReconciliations: store.inventoryReconciliations().filter((e) => e.id !== id),
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