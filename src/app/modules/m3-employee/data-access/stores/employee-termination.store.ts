import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeTermination, CreateEmployeeTermination, UpdateEmployeeTermination } from '../models/employee-termination.types';
import { EmployeeTerminationService } from '../services/employee-termination.service';

interface EmployeeTerminationState {
  employeeTerminations: EmployeeTermination[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeTerminationState = {
  employeeTerminations: [],
  isLoading: false,
  error: null,
};

export const EmployeeTerminationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeTerminationService = inject(EmployeeTerminationService)) => ({
    loadAllEmployeeTerminations: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeTerminationService.getAll().pipe(
            tapResponse({
              next: (employeeTerminations) => patchState(store, { employeeTerminations, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeTermination: rxMethod<CreateEmployeeTermination>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeTerminationService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeTerminations: [...store.employeeTerminations(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeTermination: rxMethod<{ id: number; dto: UpdateEmployeeTermination }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeTerminationService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeTerminations: store.employeeTerminations().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeTermination: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeTerminationService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeTerminations: store.employeeTerminations().filter((e) => (e as { id: number }).id !== id),
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
