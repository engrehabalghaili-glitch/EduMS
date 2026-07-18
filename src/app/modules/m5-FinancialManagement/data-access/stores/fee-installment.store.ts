import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FeeInstallmentService } from '../services/fee-installment.service';
import type { FeeInstallment, CreateFeeInstallmentDto, UpdateFeeInstallmentDto } from '../models/fee-installment.interface';

interface FeeInstallmentState {
  feeInstallments: FeeInstallment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FeeInstallmentState = {
  feeInstallments: [],
  isLoading: false,
  error: null,
};

export const FeeInstallmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, feeInstallmentService = inject(FeeInstallmentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            feeInstallmentService.getAll().pipe(
              tapResponse({
                next: (feeInstallments: FeeInstallment[]) =>
                  patchState(store, { feeInstallments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFeeInstallment: rxMethod<CreateFeeInstallmentDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            feeInstallmentService.create(dto).pipe(
              tapResponse({
                next: (entity: FeeInstallment) =>
                  patchState(store, {
                    feeInstallments: [...store.feeInstallments(), entity],
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

      updateFeeInstallment: rxMethod<{ id: number; dto: UpdateFeeInstallmentDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            feeInstallmentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FeeInstallment) =>
                  patchState(store, {
                    feeInstallments: store
                      .feeInstallments()
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

      removeFeeInstallment: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            feeInstallmentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    feeInstallments: store.feeInstallments().filter((e) => e.id !== id),
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
