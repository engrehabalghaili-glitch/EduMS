import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { WarehouseService } from '../services/warehouse.service';
import type { Warehouse, CreateWarehouseRequest, UpdateWarehouseRequest } from '../models/warehouses';

interface WarehouseState {
  warehouses: Warehouse[];
  isLoading: boolean;
  error: string | null;
}

const initialState: WarehouseState = {
  warehouses: [],
  isLoading: false,
  error: null,
};

export const WarehouseStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, warehouseService = inject(WarehouseService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            warehouseService.getAll().pipe(
              tapResponse({
                next: (warehouses: Warehouse[]) =>
                  patchState(store, { warehouses, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByOwnerId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((ownerId) =>
            warehouseService.getByOwnerId(ownerId).pipe(
              tapResponse({
                next: (warehouses: Warehouse[]) =>
                  patchState(store, { warehouses, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewWarehouse: rxMethod<CreateWarehouseRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            warehouseService.create(dto).pipe(
              tapResponse({
                next: (entity: Warehouse) =>
                  patchState(store, {
                    warehouses: [...store.warehouses(), entity],
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

      updateWarehouse: rxMethod<{ id: number; dto: UpdateWarehouseRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            warehouseService.update(id, dto).pipe(
              tapResponse({
                next: (updated: Warehouse) =>
                  patchState(store, {
                    warehouses: store
                      .warehouses()
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

      removeWarehouse: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            warehouseService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    warehouses: store.warehouses().filter((e) => e.id !== id),
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
