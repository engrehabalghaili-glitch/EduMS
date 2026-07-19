import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PurchaseOrderService } from '../services/purchase-order.service';
import type { PurchaseOrder, CreatePurchaseOrderRequest, UpdatePurchaseOrderRequest } from '../models/purchase-orders';

interface PurchaseOrderState {
  purchaseOrders: PurchaseOrder[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PurchaseOrderState = {
  purchaseOrders: [],
  isLoading: false,
  error: null,
};

export const PurchaseOrderStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, purchaseOrderService = inject(PurchaseOrderService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            purchaseOrderService.getAll().pipe(
              tapResponse({
                next: (purchaseOrders: PurchaseOrder[]) =>
                  patchState(store, { purchaseOrders, isLoading: false }),
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
            purchaseOrderService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (purchaseOrders: PurchaseOrder[]) =>
                  patchState(store, { purchaseOrders, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPurchaseOrder: rxMethod<CreatePurchaseOrderRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            purchaseOrderService.create(dto).pipe(
              tapResponse({
                next: (entity: PurchaseOrder) =>
                  patchState(store, {
                    purchaseOrders: [...store.purchaseOrders(), entity],
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

      updatePurchaseOrder: rxMethod<{ id: number; dto: UpdatePurchaseOrderRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            purchaseOrderService.update(id, dto).pipe(
              tapResponse({
                next: (updated: PurchaseOrder) =>
                  patchState(store, {
                    purchaseOrders: store
                      .purchaseOrders()
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

      removePurchaseOrder: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            purchaseOrderService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    purchaseOrders: store.purchaseOrders().filter((e) => e.id !== id),
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
