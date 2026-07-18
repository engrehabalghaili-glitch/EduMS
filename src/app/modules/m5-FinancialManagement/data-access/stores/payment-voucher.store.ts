import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PaymentVoucherService } from '../services/payment-voucher.service';
import type { PaymentVoucher, CreatePaymentVoucherDto, UpdatePaymentVoucherDto } from '../models/payment-voucher.interface';

interface PaymentVoucherState {
  paymentVouchers: PaymentVoucher[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PaymentVoucherState = {
  paymentVouchers: [],
  isLoading: false,
  error: null,
};

export const PaymentVoucherStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, paymentVoucherService = inject(PaymentVoucherService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            paymentVoucherService.getAll().pipe(
              tapResponse({
                next: (paymentVouchers: PaymentVoucher[]) =>
                  patchState(store, { paymentVouchers, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPaymentVoucher: rxMethod<CreatePaymentVoucherDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            paymentVoucherService.create(dto).pipe(
              tapResponse({
                next: (entity: PaymentVoucher) =>
                  patchState(store, {
                    paymentVouchers: [...store.paymentVouchers(), entity],
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

      updatePaymentVoucher: rxMethod<{ id: number; dto: UpdatePaymentVoucherDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            paymentVoucherService.update(id, dto).pipe(
              tapResponse({
                next: (updated: PaymentVoucher) =>
                  patchState(store, {
                    paymentVouchers: store
                      .paymentVouchers()
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

      removePaymentVoucher: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            paymentVoucherService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    paymentVouchers: store.paymentVouchers().filter((e) => e.id !== id),
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
