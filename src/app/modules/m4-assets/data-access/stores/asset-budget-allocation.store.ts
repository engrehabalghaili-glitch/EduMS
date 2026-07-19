import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetBudgetAllocationService } from '../services/asset-budget-allocation.service';
import type { AssetBudgetAllocation, CreateAssetBudgetAllocationRequest, UpdateAssetBudgetAllocationRequest } from '../models/asset-budget-allocations';

interface AssetBudgetAllocationState {
  assetBudgetAllocations: AssetBudgetAllocation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetBudgetAllocationState = {
  assetBudgetAllocations: [],
  isLoading: false,
  error: null,
};

export const AssetBudgetAllocationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetBudgetAllocationService = inject(AssetBudgetAllocationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetBudgetAllocationService.getAll().pipe(
              tapResponse({
                next: (assetBudgetAllocations: AssetBudgetAllocation[]) =>
                  patchState(store, { assetBudgetAllocations, isLoading: false }),
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
            assetBudgetAllocationService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetBudgetAllocations: AssetBudgetAllocation[]) =>
                  patchState(store, { assetBudgetAllocations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetBudgetAllocation: rxMethod<CreateAssetBudgetAllocationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetBudgetAllocationService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetBudgetAllocation) =>
                  patchState(store, {
                    assetBudgetAllocations: [...store.assetBudgetAllocations(), entity],
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

      updateAssetBudgetAllocation: rxMethod<{ id: number; dto: UpdateAssetBudgetAllocationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetBudgetAllocationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetBudgetAllocation) =>
                  patchState(store, {
                    assetBudgetAllocations: store
                      .assetBudgetAllocations()
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

      removeAssetBudgetAllocation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetBudgetAllocationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetBudgetAllocations: store.assetBudgetAllocations().filter((e) => e.id !== id),
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
