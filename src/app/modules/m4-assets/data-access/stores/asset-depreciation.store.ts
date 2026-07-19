import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetDepreciationService } from '../services/asset-depreciation.service';
import type { AssetDepreciation, CreateAssetDepreciationRequest, UpdateAssetDepreciationRequest } from '../models/asset-depreciations';

interface AssetDepreciationState {
  assetDepreciations: AssetDepreciation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetDepreciationState = {
  assetDepreciations: [],
  isLoading: false,
  error: null,
};

export const AssetDepreciationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetDepreciationService = inject(AssetDepreciationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetDepreciationService.getAll().pipe(
              tapResponse({
                next: (assetDepreciations: AssetDepreciation[]) =>
                  patchState(store, { assetDepreciations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByAssetId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((assetId) =>
            assetDepreciationService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetDepreciations: AssetDepreciation[]) =>
                  patchState(store, { assetDepreciations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetDepreciation: rxMethod<CreateAssetDepreciationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetDepreciationService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetDepreciation) =>
                  patchState(store, {
                    assetDepreciations: [...store.assetDepreciations(), entity],
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

      updateAssetDepreciation: rxMethod<{ id: number; dto: UpdateAssetDepreciationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetDepreciationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetDepreciation) =>
                  patchState(store, {
                    assetDepreciations: store
                      .assetDepreciations()
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

      removeAssetDepreciation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetDepreciationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetDepreciations: store.assetDepreciations().filter((e) => e.id !== id),
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
