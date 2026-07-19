import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeAttendance, CreateEmployeeAttendance, UpdateEmployeeAttendance } from '../models/employee-attendance.types';
import { EmployeeAttendanceService } from '../services/employee-attendance.service';

interface EmployeeAttendanceState {
  employeeAttendances: EmployeeAttendance[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeAttendanceState = {
  employeeAttendances: [],
  isLoading: false,
  error: null,
};

export const EmployeeAttendanceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeAttendanceService = inject(EmployeeAttendanceService)) => ({
    loadAllEmployeeAttendances: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeAttendanceService.getAll().pipe(
            tapResponse({
              next: (employeeAttendances) => patchState(store, { employeeAttendances, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeAttendance: rxMethod<CreateEmployeeAttendance>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeAttendanceService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeAttendances: [...store.employeeAttendances(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeAttendance: rxMethod<{ id: number; dto: UpdateEmployeeAttendance }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeAttendanceService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeAttendances: store.employeeAttendances().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeAttendance: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeAttendanceService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeAttendances: store.employeeAttendances().filter((e) => (e as { id: number }).id !== id),
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
