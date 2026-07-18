import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StudentActivityParticipationService } from '../services/student-activity-participation.service';
import type { StudentActivityParticipation, CreateStudentActivityParticipation, UpdateStudentActivityParticipation } from '../models/activity-participation.interface';

interface ActivityParticipationState {
  studentActivityParticipations: StudentActivityParticipation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ActivityParticipationState = {
  studentActivityParticipations: [],
  isLoading: false,
  error: null,
};

export const ActivityParticipationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(StudentActivityParticipationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentActivityParticipations: StudentActivityParticipation[]) =>
                  patchState(store, { studentActivityParticipations, isLoading: false }),
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
                next: (studentActivityParticipation: StudentActivityParticipation) =>
                  patchState(store, {
                    studentActivityParticipations: [...store.studentActivityParticipations(), studentActivityParticipation],
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

      addNewActivityParticipation: rxMethod<CreateStudentActivityParticipation>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentActivityParticipation: StudentActivityParticipation) =>
                  patchState(store, {
                    studentActivityParticipations: [...store.studentActivityParticipations(), studentActivityParticipation],
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

      updateActivityParticipation: rxMethod<{ id: number; dto: UpdateStudentActivityParticipation }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentActivityParticipation) =>
                  patchState(store, {
                    studentActivityParticipations: store
                      .studentActivityParticipations()
                      .map((a) => (a.id === id ? updated : a)),
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

      removeActivityParticipation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentActivityParticipations: store
                      .studentActivityParticipations()
                      .filter((a) => a.id !== id),
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
