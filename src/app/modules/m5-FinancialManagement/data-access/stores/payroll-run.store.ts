import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PayrollRunService } from '../services/payroll-run.service';
import type { PayrollRun, CreatePayrollRunDto, UpdatePayrollRunDto } from '../models/payroll-run.interface';

interface PayrollRunState {
  payrollRuns: PayrollRun[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PayrollRunState = {
  payrollRuns: [],
  isLoading: false,
  error: null,
};

export const PayrollRunStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, payrollRunService = inject(PayrollRunService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            payrollRunService.getAll().pipe(
              tapResponse({
                next: (payrollRuns: PayrollRun[]) =>
                  patchState(store, { payrollRuns, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPayrollRun: rxMethod<CreatePayrollRunDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            payrollRunService.create(dto).pipe(
              tapResponse({
                next: (entity: PayrollRun) =>
                  patchState(store, {
                    payrollRuns: [...store.payrollRuns(), entity],
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

      updatePayrollRun: rxMethod<{ id: number; dto: UpdatePayrollRunDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            payrollRunService.update(id, dto).pipe(
              tapResponse({
                next: (updated: PayrollRun) =>
                  patchState(store, {
                    payrollRuns: store
                      .payrollRuns()
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

      removePayrollRun: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            payrollRunService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    payrollRuns: store.payrollRuns().filter((e) => e.id !== id),
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
