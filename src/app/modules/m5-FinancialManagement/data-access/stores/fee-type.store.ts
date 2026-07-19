import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FeeTypeService } from '../services/fee-type.service';
import type { FeeType, CreateFeeTypeDto, UpdateFeeTypeDto } from '../models/fee-type.interface';

interface FeeTypeState {
  feeTypes: FeeType[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FeeTypeState = {
  feeTypes: [],
  isLoading: false,
  error: null,
};

export const FeeTypeStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, feeTypeService = inject(FeeTypeService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            feeTypeService.getAll().pipe(
              tapResponse({
                next: (feeTypes: FeeType[]) =>
                  patchState(store, { feeTypes, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFeeType: rxMethod<CreateFeeTypeDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            feeTypeService.create(dto).pipe(
              tapResponse({
                next: (entity: FeeType) =>
                  patchState(store, {
                    feeTypes: [...store.feeTypes(), entity],
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

      updateFeeType: rxMethod<{ id: number; dto: UpdateFeeTypeDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            feeTypeService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FeeType) =>
                  patchState(store, {
                    feeTypes: store
                      .feeTypes()
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

      removeFeeType: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            feeTypeService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    feeTypes: store.feeTypes().filter((e) => e.id !== id),
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
