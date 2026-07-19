import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeTraining, CreateEmployeeTraining, UpdateEmployeeTraining } from '../models/employee-training.types';
import { EmployeeTrainingService } from '../services/employee-training.service';

interface EmployeeTrainingState {
  employeeTrainings: EmployeeTraining[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeTrainingState = {
  employeeTrainings: [],
  isLoading: false,
  error: null,
};

export const EmployeeTrainingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeTrainingService = inject(EmployeeTrainingService)) => ({
    loadAllEmployeeTrainings: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeTrainingService.getAll().pipe(
            tapResponse({
              next: (employeeTrainings) => patchState(store, { employeeTrainings, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeTraining: rxMethod<CreateEmployeeTraining>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeTrainingService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeTrainings: [...store.employeeTrainings(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeTraining: rxMethod<{ id: number; dto: UpdateEmployeeTraining }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeTrainingService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeTrainings: store.employeeTrainings().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeTraining: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeTrainingService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeTrainings: store.employeeTrainings().filter((e) => (e as { id: number }).id !== id),
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
