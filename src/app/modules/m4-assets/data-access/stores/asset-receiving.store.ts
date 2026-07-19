import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetReceivingService } from '../services/asset-receiving.service';
import type { AssetReceiving, CreateAssetReceivingRequest, UpdateAssetReceivingRequest } from '../models/asset-receivings';

interface AssetReceivingState {
  assetReceivings: AssetReceiving[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetReceivingState = {
  assetReceivings: [],
  isLoading: false,
  error: null,
};

export const AssetReceivingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetReceivingService = inject(AssetReceivingService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetReceivingService.getAll().pipe(
              tapResponse({
                next: (assetReceivings: AssetReceiving[]) =>
                  patchState(store, { assetReceivings, isLoading: false }),
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
            assetReceivingService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetReceivings: AssetReceiving[]) =>
                  patchState(store, { assetReceivings, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetReceiving: rxMethod<CreateAssetReceivingRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetReceivingService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetReceiving) =>
                  patchState(store, {
                    assetReceivings: [...store.assetReceivings(), entity],
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

      updateAssetReceiving: rxMethod<{ id: number; dto: UpdateAssetReceivingRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetReceivingService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetReceiving) =>
                  patchState(store, {
                    assetReceivings: store
                      .assetReceivings()
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

      removeAssetReceiving: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetReceivingService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetReceivings: store.assetReceivings().filter((e) => e.id !== id),
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
