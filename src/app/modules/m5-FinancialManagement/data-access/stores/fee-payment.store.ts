import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FeePaymentService } from '../services/fee-payment.service';
import type { FeePayment, CreateFeePaymentDto, UpdateFeePaymentDto } from '../models/fee-payment.interface';

interface FeePaymentState {
  feePayments: FeePayment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FeePaymentState = {
  feePayments: [],
  isLoading: false,
  error: null,
};

export const FeePaymentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, feePaymentService = inject(FeePaymentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            feePaymentService.getAll().pipe(
              tapResponse({
                next: (feePayments: FeePayment[]) =>
                  patchState(store, { feePayments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFeePayment: rxMethod<CreateFeePaymentDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            feePaymentService.create(dto).pipe(
              tapResponse({
                next: (entity: FeePayment) =>
                  patchState(store, {
                    feePayments: [...store.feePayments(), entity],
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

      updateFeePayment: rxMethod<{ id: number; dto: UpdateFeePaymentDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            feePaymentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FeePayment) =>
                  patchState(store, {
                    feePayments: store
                      .feePayments()
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

      removeFeePayment: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            feePaymentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    feePayments: store.feePayments().filter((e) => e.id !== id),
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
