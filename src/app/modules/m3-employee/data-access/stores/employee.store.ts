import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { Employee, CreateEmployee, UpdateEmployee } from '../models/employee.types';
import { EmployeeService } from '../services/employee.service';

interface EmployeeState {
  employees: Employee[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeState = {
  employees: [],
  isLoading: false,
  error: null,
};

export const EmployeeStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeService = inject(EmployeeService)) => ({
    loadAllEmployees: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeService.getAll().pipe(
            tapResponse({
              next: (employees) => patchState(store, { employees, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployee: rxMethod<CreateEmployee>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employees: [...store.employees(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployee: rxMethod<{ id: number; dto: UpdateEmployee }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employees: store.employees().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployee: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employees: store.employees().filter((e) => (e as { id: number }).id !== id),
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
