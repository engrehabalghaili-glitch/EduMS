import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeFinancialTransaction, CreateEmployeeFinancialTransaction, UpdateEmployeeFinancialTransaction } from '../models/employee-financial-transaction.types';
import { EmployeeFinancialTransactionService } from '../services/employee-financial-transaction.service';

interface EmployeeFinancialTransactionState {
  employeeFinancialTransactions: EmployeeFinancialTransaction[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeFinancialTransactionState = {
  employeeFinancialTransactions: [],
  isLoading: false,
  error: null,
};

export const EmployeeFinancialTransactionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeFinancialTransactionService = inject(EmployeeFinancialTransactionService)) => ({
    loadAllEmployeeFinancialTransactions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeFinancialTransactionService.getAll().pipe(
            tapResponse({
              next: (employeeFinancialTransactions) => patchState(store, { employeeFinancialTransactions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeFinancialTransaction: rxMethod<CreateEmployeeFinancialTransaction>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeFinancialTransactionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeFinancialTransactions: [...store.employeeFinancialTransactions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeFinancialTransaction: rxMethod<{ id: number; dto: UpdateEmployeeFinancialTransaction }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeFinancialTransactionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeFinancialTransactions: store.employeeFinancialTransactions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeFinancialTransaction: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeFinancialTransactionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeFinancialTransactions: store.employeeFinancialTransactions().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
