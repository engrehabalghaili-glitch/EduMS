import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetRequirementRequestService } from '../services/asset-requirement-request.service';
import type { AssetRequirementRequest, CreateAssetRequirementRequest, UpdateAssetRequirementRequest } from '../models/asset-requirement-requests';

interface AssetRequirementRequestState {
  assetRequirementRequests: AssetRequirementRequest[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetRequirementRequestState = {
  assetRequirementRequests: [],
  isLoading: false,
  error: null,
};

export const AssetRequirementRequestStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetRequirementRequestService = inject(AssetRequirementRequestService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetRequirementRequestService.getAll().pipe(
              tapResponse({
                next: (assetRequirementRequests: AssetRequirementRequest[]) =>
                  patchState(store, { assetRequirementRequests, isLoading: false }),
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
            assetRequirementRequestService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetRequirementRequests: AssetRequirementRequest[]) =>
                  patchState(store, { assetRequirementRequests, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetRequirementRequest: rxMethod<CreateAssetRequirementRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetRequirementRequestService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetRequirementRequest) =>
                  patchState(store, {
                    assetRequirementRequests: [...store.assetRequirementRequests(), entity],
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

      updateAssetRequirementRequest: rxMethod<{ id: number; dto: UpdateAssetRequirementRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetRequirementRequestService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetRequirementRequest) =>
                  patchState(store, {
                    assetRequirementRequests: store
                      .assetRequirementRequests()
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

      removeAssetRequirementRequest: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetRequirementRequestService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetRequirementRequests: store.assetRequirementRequests().filter((e) => e.id !== id),
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
