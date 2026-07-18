import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetSuspensionRequestService } from '../services/asset-suspension-request.service';
import type { AssetSuspensionRequest, CreateAssetSuspensionRequest, UpdateAssetSuspensionRequest } from '../models/asset-suspension-requests';

interface AssetSuspensionRequestState {
  assetSuspensionRequests: AssetSuspensionRequest[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetSuspensionRequestState = {
  assetSuspensionRequests: [],
  isLoading: false,
  error: null,
};

export const AssetSuspensionRequestStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetSuspensionRequestService = inject(AssetSuspensionRequestService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetSuspensionRequestService.getAll().pipe(
              tapResponse({
                next: (assetSuspensionRequests: AssetSuspensionRequest[]) =>
                  patchState(store, { assetSuspensionRequests, isLoading: false }),
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
            assetSuspensionRequestService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetSuspensionRequests: AssetSuspensionRequest[]) =>
                  patchState(store, { assetSuspensionRequests, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetSuspensionRequest: rxMethod<CreateAssetSuspensionRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetSuspensionRequestService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetSuspensionRequest) =>
                  patchState(store, {
                    assetSuspensionRequests: [...store.assetSuspensionRequests(), entity],
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

      updateAssetSuspensionRequest: rxMethod<{ id: number; dto: UpdateAssetSuspensionRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetSuspensionRequestService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetSuspensionRequest) =>
                  patchState(store, {
                    assetSuspensionRequests: store
                      .assetSuspensionRequests()
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

      removeAssetSuspensionRequest: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetSuspensionRequestService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetSuspensionRequests: store.assetSuspensionRequests().filter((e) => e.id !== id),
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
