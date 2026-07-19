import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeMeeting, CreateEmployeeMeeting, UpdateEmployeeMeeting } from '../models/employee-meeting.types';
import { EmployeeMeetingService } from '../services/employee-meeting.service';

interface EmployeeMeetingState {
  employeeMeetings: EmployeeMeeting[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeMeetingState = {
  employeeMeetings: [],
  isLoading: false,
  error: null,
};

export const EmployeeMeetingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeMeetingService = inject(EmployeeMeetingService)) => ({
    loadAllEmployeeMeetings: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeMeetingService.getAll().pipe(
            tapResponse({
              next: (employeeMeetings) => patchState(store, { employeeMeetings, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeMeeting: rxMethod<CreateEmployeeMeeting>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeMeetingService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeMeetings: [...store.employeeMeetings(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeMeeting: rxMethod<{ id: number; dto: UpdateEmployeeMeeting }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeMeetingService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeMeetings: store.employeeMeetings().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeMeeting: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeMeetingService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeMeetings: store.employeeMeetings().filter((e) => (e as { id: number }).id !== id),
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
