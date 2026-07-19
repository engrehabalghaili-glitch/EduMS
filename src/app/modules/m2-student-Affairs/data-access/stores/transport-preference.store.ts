import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { TransportPreferenceService } from '../services/transport-preference.service';
import type { StudentTransportPreference, CreateStudentTransportPreference, UpdateStudentTransportPreference } from '../models/transport-preference.interface';

interface TransportPreferenceState {
  studentTransportPreferences: StudentTransportPreference[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TransportPreferenceState = {
  studentTransportPreferences: [],
  isLoading: false,
  error: null,
};

export const TransportPreferenceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(TransportPreferenceService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentTransportPreferences: StudentTransportPreference[]) =>
                  patchState(store, { studentTransportPreferences, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadById: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.getById(id).pipe(
              tapResponse({
                next: (studentTransportPreference: StudentTransportPreference) =>
                  patchState(store, {
                    studentTransportPreferences: [...store.studentTransportPreferences(), studentTransportPreference],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByStudentId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((studentId) =>
            service.getByStudentId(studentId).pipe(
              tapResponse({
                next: (studentTransportPreferences: StudentTransportPreference[]) =>
                  patchState(store, { studentTransportPreferences, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewTransportPreference: rxMethod<CreateStudentTransportPreference>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentTransportPreference: StudentTransportPreference) =>
                  patchState(store, {
                    studentTransportPreferences: [...store.studentTransportPreferences(), studentTransportPreference],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateTransportPreference: rxMethod<{ id: number; dto: UpdateStudentTransportPreference }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentTransportPreference) =>
                  patchState(store, {
                    studentTransportPreferences: store
                      .studentTransportPreferences()
                      .map((t) => (t.id === id ? updated : t)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeTransportPreference: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentTransportPreferences: store
                      .studentTransportPreferences()
                      .filter((t) => t.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
