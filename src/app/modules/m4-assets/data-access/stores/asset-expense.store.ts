import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetExpenseService } from '../services/asset-expense.service';
import type { AssetExpense, CreateAssetExpenseRequest, UpdateAssetExpenseRequest } from '../models/asset-expenses';

interface AssetExpenseState {
  assetExpenses: AssetExpense[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetExpenseState = {
  assetExpenses: [],
  isLoading: false,
  error: null,
};

export const AssetExpenseStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetExpenseService = inject(AssetExpenseService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetExpenseService.getAll().pipe(
              tapResponse({
                next: (assetExpenses: AssetExpense[]) =>
                  patchState(store, { assetExpenses, isLoading: false }),
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
            assetExpenseService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetExpenses: AssetExpense[]) =>
                  patchState(store, { assetExpenses, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetExpense: rxMethod<CreateAssetExpenseRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetExpenseService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetExpense) =>
                  patchState(store, {
                    assetExpenses: [...store.assetExpenses(), entity],
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

      updateAssetExpense: rxMethod<{ id: number; dto: UpdateAssetExpenseRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetExpenseService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetExpense) =>
                  patchState(store, {
                    assetExpenses: store
                      .assetExpenses()
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

      removeAssetExpense: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetExpenseService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetExpenses: store.assetExpenses().filter((e) => e.id !== id),
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
