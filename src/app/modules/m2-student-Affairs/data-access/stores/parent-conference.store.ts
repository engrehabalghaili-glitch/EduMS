import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ParentConferenceService } from '../services/parent-conference.service';
import type { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '../models/parent-conference.interface';

interface ParentConferenceState {
  studentParentConferenceReservations: StudentParentConferenceReservation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ParentConferenceState = {
  studentParentConferenceReservations: [],
  isLoading: false,
  error: null,
};

export const ParentConferenceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(ParentConferenceService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentParentConferenceReservations: StudentParentConferenceReservation[]) =>
                  patchState(store, { studentParentConferenceReservations, isLoading: false }),
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
                next: (studentParentConferenceReservation: StudentParentConferenceReservation) =>
                  patchState(store, {
                    studentParentConferenceReservations: [...store.studentParentConferenceReservations(), studentParentConferenceReservation],
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
                next: (studentParentConferenceReservations: StudentParentConferenceReservation[]) =>
                  patchState(store, { studentParentConferenceReservations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewParentConferenceReservation: rxMethod<CreateStudentParentConferenceReservation>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentParentConferenceReservation: StudentParentConferenceReservation) =>
                  patchState(store, {
                    studentParentConferenceReservations: [...store.studentParentConferenceReservations(), studentParentConferenceReservation],
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

      updateParentConferenceReservation: rxMethod<{ id: number; dto: UpdateStudentParentConferenceReservation }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentParentConferenceReservation) =>
                  patchState(store, {
                    studentParentConferenceReservations: store
                      .studentParentConferenceReservations()
                      .map((p) => (p.id === id ? updated : p)),
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

      removeParentConferenceReservation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentParentConferenceReservations: store
                      .studentParentConferenceReservations()
                      .filter((p) => p.id !== id),
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
