import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeViolation, CreateEmployeeViolation, UpdateEmployeeViolation } from '../models/employee-violation.types';
import { EmployeeViolationService } from '../services/employee-violation.service';

interface EmployeeViolationState {
  employeeViolations: EmployeeViolation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeViolationState = {
  employeeViolations: [],
  isLoading: false,
  error: null,
};

export const EmployeeViolationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeViolationService = inject(EmployeeViolationService)) => ({
    loadAllEmployeeViolations: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeViolationService.getAll().pipe(
            tapResponse({
              next: (employeeViolations) => patchState(store, { employeeViolations, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeViolation: rxMethod<CreateEmployeeViolation>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeViolationService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeViolations: [...store.employeeViolations(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeViolation: rxMethod<{ id: number; dto: UpdateEmployeeViolation }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeViolationService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeViolations: store.employeeViolations().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeViolation: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeViolationService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeViolations: store.employeeViolations().filter((e) => (e as { id: number }).id !== id),
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
