import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeCommittee, CreateEmployeeCommittee, UpdateEmployeeCommittee } from '../models/employee-committee.types';
import { EmployeeCommitteeService } from '../services/employee-committee.service';

interface EmployeeCommitteeState {
  employeeCommittees: EmployeeCommittee[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeCommitteeState = {
  employeeCommittees: [],
  isLoading: false,
  error: null,
};

export const EmployeeCommitteeStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeCommitteeService = inject(EmployeeCommitteeService)) => ({
    loadAllEmployeeCommittees: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeCommitteeService.getAll().pipe(
            tapResponse({
              next: (employeeCommittees) => patchState(store, { employeeCommittees, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeCommittee: rxMethod<CreateEmployeeCommittee>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeCommitteeService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeCommittees: [...store.employeeCommittees(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeCommittee: rxMethod<{ id: number; dto: UpdateEmployeeCommittee }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeCommitteeService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeCommittees: store.employeeCommittees().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeCommittee: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeCommitteeService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeCommittees: store.employeeCommittees().filter((e) => (e as { id: number }).id !== id),
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
