import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeLeave, CreateEmployeeLeave, UpdateEmployeeLeave } from '../models/employee-leave.types';
import { EmployeeLeaveService } from '../services/employee-leave.service';

interface EmployeeLeaveState {
  employeeLeaves: EmployeeLeave[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeLeaveState = {
  employeeLeaves: [],
  isLoading: false,
  error: null,
};

export const EmployeeLeaveStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeLeaveService = inject(EmployeeLeaveService)) => ({
    loadAllEmployeeLeaves: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeLeaveService.getAll().pipe(
            tapResponse({
              next: (employeeLeaves) => patchState(store, { employeeLeaves, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeLeave: rxMethod<CreateEmployeeLeave>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeLeaveService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeLeaves: [...store.employeeLeaves(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeLeave: rxMethod<{ id: number; dto: UpdateEmployeeLeave }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeLeaveService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeLeaves: store.employeeLeaves().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeLeave: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeLeaveService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeLeaves: store.employeeLeaves().filter((e) => (e as { id: number }).id !== id),
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
