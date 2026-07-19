import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeMentor, CreateEmployeeMentor, UpdateEmployeeMentor } from '../models/employee-mentor.types';
import { EmployeeMentorService } from '../services/employee-mentor.service';

interface EmployeeMentorState {
  employeeMentors: EmployeeMentor[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeMentorState = {
  employeeMentors: [],
  isLoading: false,
  error: null,
};

export const EmployeeMentorStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeMentorService = inject(EmployeeMentorService)) => ({
    loadAllEmployeeMentors: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeMentorService.getAll().pipe(
            tapResponse({
              next: (employeeMentors) => patchState(store, { employeeMentors, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeMentor: rxMethod<CreateEmployeeMentor>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeMentorService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeMentors: [...store.employeeMentors(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeMentor: rxMethod<{ id: number; dto: UpdateEmployeeMentor }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeMentorService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeMentors: store.employeeMentors().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeMentor: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeMentorService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeMentors: store.employeeMentors().filter((e) => (e as { id: number }).id !== id),
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
