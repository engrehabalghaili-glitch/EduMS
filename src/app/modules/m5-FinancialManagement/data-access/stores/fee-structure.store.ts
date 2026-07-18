import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FeeStructureService } from '../services/fee-structure.service';
import type { FeeStructure, CreateFeeStructureDto, UpdateFeeStructureDto } from '../models/fee-structure.interface';

interface FeeStructureState {
  feeStructures: FeeStructure[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FeeStructureState = {
  feeStructures: [],
  isLoading: false,
  error: null,
};

export const FeeStructureStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, feeStructureService = inject(FeeStructureService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            feeStructureService.getAll().pipe(
              tapResponse({
                next: (feeStructures: FeeStructure[]) =>
                  patchState(store, { feeStructures, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFeeStructure: rxMethod<CreateFeeStructureDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            feeStructureService.create(dto).pipe(
              tapResponse({
                next: (entity: FeeStructure) =>
                  patchState(store, {
                    feeStructures: [...store.feeStructures(), entity],
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

      updateFeeStructure: rxMethod<{ id: number; dto: UpdateFeeStructureDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            feeStructureService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FeeStructure) =>
                  patchState(store, {
                    feeStructures: store
                      .feeStructures()
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

      removeFeeStructure: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            feeStructureService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    feeStructures: store.feeStructures().filter((e) => e.id !== id),
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
