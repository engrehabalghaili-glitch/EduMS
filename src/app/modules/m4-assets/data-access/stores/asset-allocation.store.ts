import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetAllocationService } from '../services/asset-allocation.service';
import type { AssetAllocation, CreateAssetAllocationRequest, UpdateAssetAllocationRequest } from '../models/asset-allocations';

interface AssetAllocationState {
  assetAllocations: AssetAllocation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetAllocationState = {
  assetAllocations: [],
  isLoading: false,
  error: null,
};

export const AssetAllocationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetAllocationService = inject(AssetAllocationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetAllocationService.getAll().pipe(
              tapResponse({
                next: (assetAllocations: AssetAllocation[]) =>
                  patchState(store, { assetAllocations, isLoading: false }),
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
            assetAllocationService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetAllocations: AssetAllocation[]) =>
                  patchState(store, { assetAllocations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetAllocation: rxMethod<CreateAssetAllocationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetAllocationService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetAllocation) =>
                  patchState(store, {
                    assetAllocations: [...store.assetAllocations(), entity],
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

      updateAssetAllocation: rxMethod<{ id: number; dto: UpdateAssetAllocationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetAllocationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetAllocation) =>
                  patchState(store, {
                    assetAllocations: store
                      .assetAllocations()
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

      removeAssetAllocation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetAllocationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetAllocations: store.assetAllocations().filter((e) => e.id !== id),
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
