import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetLocationRecordService } from '../services/asset-location-record.service';
import type { AssetLocationRecord, CreateAssetLocationRecordRequest, UpdateAssetLocationRecordRequest } from '../models/asset-location-records';

interface AssetLocationRecordState {
  assetLocationRecords: AssetLocationRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetLocationRecordState = {
  assetLocationRecords: [],
  isLoading: false,
  error: null,
};

export const AssetLocationRecordStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetLocationRecordService = inject(AssetLocationRecordService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetLocationRecordService.getAll().pipe(
              tapResponse({
                next: (assetLocationRecords: AssetLocationRecord[]) =>
                  patchState(store, { assetLocationRecords, isLoading: false }),
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
            assetLocationRecordService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetLocationRecords: AssetLocationRecord[]) =>
                  patchState(store, { assetLocationRecords, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetLocationRecord: rxMethod<CreateAssetLocationRecordRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetLocationRecordService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetLocationRecord) =>
                  patchState(store, {
                    assetLocationRecords: [...store.assetLocationRecords(), entity],
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

      updateAssetLocationRecord: rxMethod<{ id: number; dto: UpdateAssetLocationRecordRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetLocationRecordService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetLocationRecord) =>
                  patchState(store, {
                    assetLocationRecords: store
                      .assetLocationRecords()
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

      removeAssetLocationRecord: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetLocationRecordService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetLocationRecords: store.assetLocationRecords().filter((e) => e.id !== id),
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
