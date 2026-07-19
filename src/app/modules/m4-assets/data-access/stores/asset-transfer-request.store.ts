import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetTransferRequestService } from '../services/asset-transfer-request.service';
import type {
  AssetTransferRequest,
  CreateAssetTransferRequest,
  UpdateAssetTransferRequest,
} from '../models/asset-transfer-requests';

interface AssetTransferRequestState {
  assetTransferRequests: AssetTransferRequest[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetTransferRequestState = {
  assetTransferRequests: [],
  isLoading: false,
  error: null,
};

export const AssetTransferRequestStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetTransferRequestService = inject(AssetTransferRequestService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetTransferRequestService.getAll().pipe(
              tapResponse({
                next: (assetTransferRequests: AssetTransferRequest[]) =>
                  patchState(store, { assetTransferRequests, isLoading: false }),
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
            assetTransferRequestService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetTransferRequests: AssetTransferRequest[]) =>
                  patchState(store, { assetTransferRequests, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetTransferRequest: rxMethod<CreateAssetTransferRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetTransferRequestService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetTransferRequest) =>
                  patchState(store, {
                    assetTransferRequests: [...store.assetTransferRequests(), entity],
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

      updateAssetTransferRequest: rxMethod<{
        id: number;
        dto: UpdateAssetTransferRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetTransferRequestService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetTransferRequest) =>
                  patchState(store, {
                    assetTransferRequests: store
                      .assetTransferRequests()
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

      removeAssetTransferRequest: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetTransferRequestService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetTransferRequests: store
                      .assetTransferRequests()
                      .filter((e) => e.id !== id),
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
