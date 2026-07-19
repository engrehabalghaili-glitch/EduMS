import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeePayroll, CreateEmployeePayroll, UpdateEmployeePayroll } from '../models/employee-payroll.types';
import { EmployeePayrollService } from '../services/employee-payroll.service';

interface EmployeePayrollState {
  employeePayrolls: EmployeePayroll[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeePayrollState = {
  employeePayrolls: [],
  isLoading: false,
  error: null,
};

export const EmployeePayrollStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeePayrollService = inject(EmployeePayrollService)) => ({
    loadAllEmployeePayrolls: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeePayrollService.getAll().pipe(
            tapResponse({
              next: (employeePayrolls) => patchState(store, { employeePayrolls, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeePayroll: rxMethod<CreateEmployeePayroll>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeePayrollService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeePayrolls: [...store.employeePayrolls(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeePayroll: rxMethod<{ id: number; dto: UpdateEmployeePayroll }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeePayrollService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeePayrolls: store.employeePayrolls().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeePayroll: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeePayrollService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeePayrolls: store.employeePayrolls().filter((e) => (e as { id: number }).id !== id),
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
