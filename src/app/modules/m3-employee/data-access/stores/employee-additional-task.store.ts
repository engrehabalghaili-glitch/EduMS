import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeAdditionalTask, CreateEmployeeAdditionalTask, UpdateEmployeeAdditionalTask } from '../models/employee-additional-task.types';
import { EmployeeAdditionalTaskService } from '../services/employee-additional-task.service';

interface EmployeeAdditionalTaskState {
  employeeAdditionalTasks: EmployeeAdditionalTask[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeAdditionalTaskState = {
  employeeAdditionalTasks: [],
  isLoading: false,
  error: null,
};

export const EmployeeAdditionalTaskStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeAdditionalTaskService = inject(EmployeeAdditionalTaskService)) => ({
    loadAllEmployeeAdditionalTasks: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeAdditionalTaskService.getAll().pipe(
            tapResponse({
              next: (employeeAdditionalTasks) => patchState(store, { employeeAdditionalTasks, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeAdditionalTask: rxMethod<CreateEmployeeAdditionalTask>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeAdditionalTaskService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeAdditionalTasks: [...store.employeeAdditionalTasks(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeAdditionalTask: rxMethod<{ id: number; dto: UpdateEmployeeAdditionalTask }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeAdditionalTaskService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeAdditionalTasks: store.employeeAdditionalTasks().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeAdditionalTask: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeAdditionalTaskService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeAdditionalTasks: store.employeeAdditionalTasks().filter((e) => (e as { id: number }).id !== id),
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
