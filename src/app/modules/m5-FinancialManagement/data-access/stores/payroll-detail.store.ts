import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PayrollDetailService } from '../services/payroll-detail.service';
import type { PayrollDetail, CreatePayrollDetailDto, UpdatePayrollDetailDto } from '../models/payroll-detail.interface';

interface PayrollDetailState {
  payrollDetails: PayrollDetail[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PayrollDetailState = {
  payrollDetails: [],
  isLoading: false,
  error: null,
};

export const PayrollDetailStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, payrollDetailService = inject(PayrollDetailService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            payrollDetailService.getAll().pipe(
              tapResponse({
                next: (payrollDetails: PayrollDetail[]) =>
                  patchState(store, { payrollDetails, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPayrollDetail: rxMethod<CreatePayrollDetailDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            payrollDetailService.create(dto).pipe(
              tapResponse({
                next: (entity: PayrollDetail) =>
                  patchState(store, {
                    payrollDetails: [...store.payrollDetails(), entity],
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

      updatePayrollDetail: rxMethod<{ id: number; dto: UpdatePayrollDetailDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            payrollDetailService.update(id, dto).pipe(
              tapResponse({
                next: (updated: PayrollDetail) =>
                  patchState(store, {
                    payrollDetails: store
                      .payrollDetails()
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

      removePayrollDetail: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            payrollDetailService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    payrollDetails: store.payrollDetails().filter((e) => e.id !== id),
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
