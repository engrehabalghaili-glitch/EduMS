import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { DepreciationTransactionService } from '../services/depreciation-transaction.service';
import type {
  DepreciationTransaction,
  CreateDepreciationTransactionRequest,
  UpdateDepreciationTransactionRequest,
} from '../models/depreciation-transactions';

interface DepreciationTransactionState {
  depreciationTransactions: DepreciationTransaction[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DepreciationTransactionState = {
  depreciationTransactions: [],
  isLoading: false,
  error: null,
};

export const DepreciationTransactionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, depreciationTransactionService = inject(DepreciationTransactionService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            depreciationTransactionService.getAll().pipe(
              tapResponse({
                next: (depreciationTransactions: DepreciationTransaction[]) =>
                  patchState(store, { depreciationTransactions, isLoading: false }),
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
            depreciationTransactionService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (depreciationTransactions: DepreciationTransaction[]) =>
                  patchState(store, { depreciationTransactions, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewDepreciationTransaction: rxMethod<CreateDepreciationTransactionRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            depreciationTransactionService.create(dto).pipe(
              tapResponse({
                next: (entity: DepreciationTransaction) =>
                  patchState(store, {
                    depreciationTransactions: [...store.depreciationTransactions(), entity],
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

      updateDepreciationTransaction: rxMethod<{
        id: number;
        dto: UpdateDepreciationTransactionRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            depreciationTransactionService.update(id, dto).pipe(
              tapResponse({
                next: (updated: DepreciationTransaction) =>
                  patchState(store, {
                    depreciationTransactions: store
                      .depreciationTransactions()
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

      removeDepreciationTransaction: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            depreciationTransactionService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    depreciationTransactions: store
                      .depreciationTransactions()
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
