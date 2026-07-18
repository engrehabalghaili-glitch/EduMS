import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { InvoiceItemService } from '../services/invoice-item.service';
import type { InvoiceItem, CreateInvoiceItemDto, UpdateInvoiceItemDto } from '../models/invoice-item.interface';

interface InvoiceItemState {
  invoiceItems: InvoiceItem[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InvoiceItemState = {
  invoiceItems: [],
  isLoading: false,
  error: null,
};

export const InvoiceItemStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, invoiceItemService = inject(InvoiceItemService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            invoiceItemService.getAll().pipe(
              tapResponse({
                next: (invoiceItems: InvoiceItem[]) =>
                  patchState(store, { invoiceItems, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewInvoiceItem: rxMethod<CreateInvoiceItemDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            invoiceItemService.create(dto).pipe(
              tapResponse({
                next: (entity: InvoiceItem) =>
                  patchState(store, {
                    invoiceItems: [...store.invoiceItems(), entity],
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

      updateInvoiceItem: rxMethod<{ id: number; dto: UpdateInvoiceItemDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            invoiceItemService.update(id, dto).pipe(
              tapResponse({
                next: (updated: InvoiceItem) =>
                  patchState(store, {
                    invoiceItems: store
                      .invoiceItems()
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

      removeInvoiceItem: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            invoiceItemService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    invoiceItems: store.invoiceItems().filter((e) => e.id !== id),
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
