import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetMovementHistoryService } from '../services/asset-movement-history.service';
import type { AssetMovementHistory, CreateAssetMovementHistoryRequest, UpdateAssetMovementHistoryRequest } from '../models/asset-movement-histories';

interface AssetMovementHistoryState {
  assetMovementHistories: AssetMovementHistory[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetMovementHistoryState = {
  assetMovementHistories: [],
  isLoading: false,
  error: null,
};

export const AssetMovementHistoryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetMovementHistoryService = inject(AssetMovementHistoryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetMovementHistoryService.getAll().pipe(
              tapResponse({
                next: (assetMovementHistories: AssetMovementHistory[]) =>
                  patchState(store, { assetMovementHistories, isLoading: false }),
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
            assetMovementHistoryService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetMovementHistories: AssetMovementHistory[]) =>
                  patchState(store, { assetMovementHistories, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetMovementHistory: rxMethod<CreateAssetMovementHistoryRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetMovementHistoryService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetMovementHistory) =>
                  patchState(store, {
                    assetMovementHistories: [...store.assetMovementHistories(), entity],
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

      updateAssetMovementHistory: rxMethod<{ id: number; dto: UpdateAssetMovementHistoryRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetMovementHistoryService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetMovementHistory) =>
                  patchState(store, {
                    assetMovementHistories: store
                      .assetMovementHistories()
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

      removeAssetMovementHistory: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetMovementHistoryService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetMovementHistories: store.assetMovementHistories().filter((e) => e.id !== id),
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
