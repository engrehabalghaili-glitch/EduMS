import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetStatusRecordService } from '../services/asset-status-record.service';
import type { AssetStatusRecord, CreateAssetStatusRecordRequest, UpdateAssetStatusRecordRequest } from '../models/asset-status-records';

interface AssetStatusRecordState {
  assetStatusRecords: AssetStatusRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetStatusRecordState = {
  assetStatusRecords: [],
  isLoading: false,
  error: null,
};

export const AssetStatusRecordStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetStatusRecordService = inject(AssetStatusRecordService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetStatusRecordService.getAll().pipe(
              tapResponse({
                next: (assetStatusRecords: AssetStatusRecord[]) =>
                  patchState(store, { assetStatusRecords, isLoading: false }),
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
            assetStatusRecordService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetStatusRecords: AssetStatusRecord[]) =>
                  patchState(store, { assetStatusRecords, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetStatusRecord: rxMethod<CreateAssetStatusRecordRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetStatusRecordService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetStatusRecord) =>
                  patchState(store, {
                    assetStatusRecords: [...store.assetStatusRecords(), entity],
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

      updateAssetStatusRecord: rxMethod<{ id: number; dto: UpdateAssetStatusRecordRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetStatusRecordService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetStatusRecord) =>
                  patchState(store, {
                    assetStatusRecords: store
                      .assetStatusRecords()
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

      removeAssetStatusRecord: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetStatusRecordService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetStatusRecords: store.assetStatusRecords().filter((e) => e.id !== id),
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
