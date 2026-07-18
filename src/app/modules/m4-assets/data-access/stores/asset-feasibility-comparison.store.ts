import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetFeasibilityComparisonService } from '../services/asset-feasibility-comparison.service';
import type { AssetFeasibilityComparison, CreateAssetFeasibilityComparisonRequest, UpdateAssetFeasibilityComparisonRequest } from '../models/asset-feasibility-comparisons';

interface AssetFeasibilityComparisonState {
  assetFeasibilityComparisons: AssetFeasibilityComparison[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetFeasibilityComparisonState = {
  assetFeasibilityComparisons: [],
  isLoading: false,
  error: null,
};

export const AssetFeasibilityComparisonStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetFeasibilityComparisonService = inject(AssetFeasibilityComparisonService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetFeasibilityComparisonService.getAll().pipe(
              tapResponse({
                next: (assetFeasibilityComparisons: AssetFeasibilityComparison[]) =>
                  patchState(store, { assetFeasibilityComparisons, isLoading: false }),
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
            assetFeasibilityComparisonService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetFeasibilityComparisons: AssetFeasibilityComparison[]) =>
                  patchState(store, { assetFeasibilityComparisons, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetFeasibilityComparison: rxMethod<CreateAssetFeasibilityComparisonRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetFeasibilityComparisonService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetFeasibilityComparison) =>
                  patchState(store, {
                    assetFeasibilityComparisons: [...store.assetFeasibilityComparisons(), entity],
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

      updateAssetFeasibilityComparison: rxMethod<{ id: number; dto: UpdateAssetFeasibilityComparisonRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetFeasibilityComparisonService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetFeasibilityComparison) =>
                  patchState(store, {
                    assetFeasibilityComparisons: store
                      .assetFeasibilityComparisons()
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

      removeAssetFeasibilityComparison: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetFeasibilityComparisonService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetFeasibilityComparisons: store.assetFeasibilityComparisons().filter((e) => e.id !== id),
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
