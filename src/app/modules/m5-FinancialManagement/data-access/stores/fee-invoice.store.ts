import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FeeInvoiceService } from '../services/fee-invoice.service';
import type { FeeInvoice, CreateFeeInvoiceDto, UpdateFeeInvoiceDto } from '../models/fee-invoice.interface';

interface FeeInvoiceState {
  feeInvoices: FeeInvoice[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FeeInvoiceState = {
  feeInvoices: [],
  isLoading: false,
  error: null,
};

export const FeeInvoiceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, feeInvoiceService = inject(FeeInvoiceService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            feeInvoiceService.getAll().pipe(
              tapResponse({
                next: (feeInvoices: FeeInvoice[]) =>
                  patchState(store, { feeInvoices, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFeeInvoice: rxMethod<CreateFeeInvoiceDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            feeInvoiceService.create(dto).pipe(
              tapResponse({
                next: (entity: FeeInvoice) =>
                  patchState(store, {
                    feeInvoices: [...store.feeInvoices(), entity],
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

      updateFeeInvoice: rxMethod<{ id: number; dto: UpdateFeeInvoiceDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            feeInvoiceService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FeeInvoice) =>
                  patchState(store, {
                    feeInvoices: store
                      .feeInvoices()
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

      removeFeeInvoice: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            feeInvoiceService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    feeInvoices: store.feeInvoices().filter((e) => e.id !== id),
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
