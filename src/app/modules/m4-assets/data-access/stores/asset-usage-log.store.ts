import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetUsageLogService } from '../services/asset-usage-log.service';
import type {
  AssetUsageLog,
  CreateAssetUsageLogRequest,
  UpdateAssetUsageLogRequest,
} from '../models/asset-usage-logs';

interface AssetUsageLogState {
  assetUsageLogs: AssetUsageLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetUsageLogState = {
  assetUsageLogs: [],
  isLoading: false,
  error: null,
};

export const AssetUsageLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetUsageLogService = inject(AssetUsageLogService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetUsageLogService.getAll().pipe(
              tapResponse({
                next: (assetUsageLogs: AssetUsageLog[]) =>
                  patchState(store, { assetUsageLogs, isLoading: false }),
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
            assetUsageLogService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetUsageLogs: AssetUsageLog[]) =>
                  patchState(store, { assetUsageLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetUsageLog: rxMethod<CreateAssetUsageLogRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetUsageLogService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetUsageLog) =>
                  patchState(store, {
                    assetUsageLogs: [...store.assetUsageLogs(), entity],
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

      updateAssetUsageLog: rxMethod<{
        id: number;
        dto: UpdateAssetUsageLogRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetUsageLogService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetUsageLog) =>
                  patchState(store, {
                    assetUsageLogs: store
                      .assetUsageLogs()
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

      removeAssetUsageLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetUsageLogService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetUsageLogs: store.assetUsageLogs().filter((e) => e.id !== id),
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
