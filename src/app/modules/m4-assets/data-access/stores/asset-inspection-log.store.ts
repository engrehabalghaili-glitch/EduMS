import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetInspectionLogService } from '../services/asset-inspection-log.service';
import type { AssetInspectionLog, CreateAssetInspectionLogRequest, UpdateAssetInspectionLogRequest } from '../models/asset-inspection-logs';

interface AssetInspectionLogState {
  assetInspectionLogs: AssetInspectionLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetInspectionLogState = {
  assetInspectionLogs: [],
  isLoading: false,
  error: null,
};

export const AssetInspectionLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetInspectionLogService = inject(AssetInspectionLogService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetInspectionLogService.getAll().pipe(
              tapResponse({
                next: (assetInspectionLogs: AssetInspectionLog[]) =>
                  patchState(store, { assetInspectionLogs, isLoading: false }),
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
            assetInspectionLogService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetInspectionLogs: AssetInspectionLog[]) =>
                  patchState(store, { assetInspectionLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetInspectionLog: rxMethod<CreateAssetInspectionLogRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetInspectionLogService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetInspectionLog) =>
                  patchState(store, {
                    assetInspectionLogs: [...store.assetInspectionLogs(), entity],
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

      updateAssetInspectionLog: rxMethod<{ id: number; dto: UpdateAssetInspectionLogRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetInspectionLogService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetInspectionLog) =>
                  patchState(store, {
                    assetInspectionLogs: store
                      .assetInspectionLogs()
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

      removeAssetInspectionLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetInspectionLogService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetInspectionLogs: store.assetInspectionLogs().filter((e) => e.id !== id),
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
