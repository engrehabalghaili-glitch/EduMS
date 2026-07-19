import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetLoanService } from '../services/asset-loan.service';
import type { AssetLoan, CreateAssetLoanRequest, UpdateAssetLoanRequest } from '../models/asset-loans';

interface AssetLoanState {
  assetLoans: AssetLoan[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetLoanState = {
  assetLoans: [],
  isLoading: false,
  error: null,
};

export const AssetLoanStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetLoanService = inject(AssetLoanService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetLoanService.getAll().pipe(
              tapResponse({
                next: (assetLoans: AssetLoan[]) =>
                  patchState(store, { assetLoans, isLoading: false }),
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
            assetLoanService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetLoans: AssetLoan[]) =>
                  patchState(store, { assetLoans, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetLoan: rxMethod<CreateAssetLoanRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetLoanService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetLoan) =>
                  patchState(store, {
                    assetLoans: [...store.assetLoans(), entity],
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

      updateAssetLoan: rxMethod<{ id: number; dto: UpdateAssetLoanRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetLoanService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetLoan) =>
                  patchState(store, {
                    assetLoans: store
                      .assetLoans()
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

      removeAssetLoan: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetLoanService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetLoans: store.assetLoans().filter((e) => e.id !== id),
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
