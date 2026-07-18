import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetFinancialsService } from '../services/asset-financials.service';
import type { AssetFinancials, CreateAssetFinancialsRequest, UpdateAssetFinancialsRequest } from '../models/asset-financials';

interface AssetFinancialsState {
  assetFinancials: AssetFinancials[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetFinancialsState = {
  assetFinancials: [],
  isLoading: false,
  error: null,
};

export const AssetFinancialsStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetFinancialsService = inject(AssetFinancialsService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetFinancialsService.getAll().pipe(
              tapResponse({
                next: (assetFinancials: AssetFinancials[]) =>
                  patchState(store, { assetFinancials, isLoading: false }),
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
            assetFinancialsService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetFinancials: AssetFinancials[]) =>
                  patchState(store, { assetFinancials, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetFinancials: rxMethod<CreateAssetFinancialsRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetFinancialsService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetFinancials) =>
                  patchState(store, {
                    assetFinancials: [...store.assetFinancials(), entity],
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

      updateAssetFinancials: rxMethod<{ id: number; dto: UpdateAssetFinancialsRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetFinancialsService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetFinancials) =>
                  patchState(store, {
                    assetFinancials: store
                      .assetFinancials()
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

      removeAssetFinancials: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetFinancialsService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetFinancials: store.assetFinancials().filter((e) => e.id !== id),
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
