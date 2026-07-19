import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { InventoryPlanService } from '../services/inventory-plan.service';
import type { InventoryPlan, CreateInventoryPlanRequest, UpdateInventoryPlanRequest } from '../models/inventory-plans';

interface InventoryPlanState {
  inventoryPlans: InventoryPlan[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InventoryPlanState = {
  inventoryPlans: [],
  isLoading: false,
  error: null,
};

export const InventoryPlanStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, inventoryPlanService = inject(InventoryPlanService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            inventoryPlanService.getAll().pipe(
              tapResponse({
                next: (inventoryPlans: InventoryPlan[]) =>
                  patchState(store, { inventoryPlans, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            inventoryPlanService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (inventoryPlans: InventoryPlan[]) =>
                  patchState(store, { inventoryPlans, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewInventoryPlan: rxMethod<CreateInventoryPlanRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            inventoryPlanService.create(dto).pipe(
              tapResponse({
                next: (entity: InventoryPlan) =>
                  patchState(store, {
                    inventoryPlans: [...store.inventoryPlans(), entity],
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

      updateInventoryPlan: rxMethod<{ id: number; dto: UpdateInventoryPlanRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            inventoryPlanService.update(id, dto).pipe(
              tapResponse({
                next: (updated: InventoryPlan) =>
                  patchState(store, {
                    inventoryPlans: store
                      .inventoryPlans()
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

      removeInventoryPlan: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            inventoryPlanService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    inventoryPlans: store.inventoryPlans().filter((e) => e.id !== id),
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