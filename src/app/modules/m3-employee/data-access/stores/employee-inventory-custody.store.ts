import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeInventoryCustody, CreateEmployeeInventoryCustody, UpdateEmployeeInventoryCustody } from '../models/employee-inventory-custody.types';
import { EmployeeInventoryCustodyService } from '../services/employee-inventory-custody.service';

interface EmployeeInventoryCustodyState {
  employeeInventoryCustodies: EmployeeInventoryCustody[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeInventoryCustodyState = {
  employeeInventoryCustodies: [],
  isLoading: false,
  error: null,
};

export const EmployeeInventoryCustodyStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeInventoryCustodyService = inject(EmployeeInventoryCustodyService)) => ({
    loadAllEmployeeInventoryCustodies: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeInventoryCustodyService.getAll().pipe(
            tapResponse({
              next: (employeeInventoryCustodies) => patchState(store, { employeeInventoryCustodies, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeInventoryCustody: rxMethod<CreateEmployeeInventoryCustody>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeInventoryCustodyService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeInventoryCustodies: [...store.employeeInventoryCustodies(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeInventoryCustody: rxMethod<{ id: number; dto: UpdateEmployeeInventoryCustody }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeInventoryCustodyService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeInventoryCustodies: store.employeeInventoryCustodies().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeInventoryCustody: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeInventoryCustodyService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeInventoryCustodies: store.employeeInventoryCustodies().filter((e) => (e as { id: number }).id !== id),
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
