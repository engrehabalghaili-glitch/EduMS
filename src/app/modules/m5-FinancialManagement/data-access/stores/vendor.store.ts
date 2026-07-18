import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { VendorService } from '../services/vendor.service';
import type { Vendor, CreateVendorDto, UpdateVendorDto } from '../models/vendor.interface';

interface VendorState {
  vendors: Vendor[];
  isLoading: boolean;
  error: string | null;
}

const initialState: VendorState = {
  vendors: [],
  isLoading: false,
  error: null,
};

export const VendorStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, vendorService = inject(VendorService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            vendorService.getAll().pipe(
              tapResponse({
                next: (vendors: Vendor[]) =>
                  patchState(store, { vendors, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewVendor: rxMethod<CreateVendorDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            vendorService.create(dto).pipe(
              tapResponse({
                next: (entity: Vendor) =>
                  patchState(store, {
                    vendors: [...store.vendors(), entity],
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

      updateVendor: rxMethod<{ id: number; dto: UpdateVendorDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            vendorService.update(id, dto).pipe(
              tapResponse({
                next: (updated: Vendor) =>
                  patchState(store, {
                    vendors: store
                      .vendors()
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

      removeVendor: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            vendorService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    vendors: store.vendors().filter((e) => e.id !== id),
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
