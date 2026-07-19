import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AbsenceExcusalService } from '../services/absence-excusal.service';
import type { StudentAbsenceExcusal, CreateStudentAbsenceExcusal, UpdateStudentAbsenceExcusal } from '../models/absence-excusal.interface';

interface AbsenceExcusalState {
  studentAbsenceExcusals: StudentAbsenceExcusal[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AbsenceExcusalState = {
  studentAbsenceExcusals: [],
  isLoading: false,
  error: null,
};

export const AbsenceExcusalStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(AbsenceExcusalService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentAbsenceExcusals: StudentAbsenceExcusal[]) =>
                  patchState(store, { studentAbsenceExcusals, isLoading: false }),
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
                next: (studentAbsenceExcusal: StudentAbsenceExcusal) =>
                  patchState(store, {
                    studentAbsenceExcusals: [...store.studentAbsenceExcusals(), studentAbsenceExcusal],
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
                next: (studentAbsenceExcusals: StudentAbsenceExcusal[]) =>
                  patchState(store, { studentAbsenceExcusals, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAbsenceExcusal: rxMethod<CreateStudentAbsenceExcusal>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentAbsenceExcusal: StudentAbsenceExcusal) =>
                  patchState(store, {
                    studentAbsenceExcusals: [...store.studentAbsenceExcusals(), studentAbsenceExcusal],
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

      updateAbsenceExcusal: rxMethod<{ id: number; dto: UpdateStudentAbsenceExcusal }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentAbsenceExcusal) =>
                  patchState(store, {
                    studentAbsenceExcusals: store
                      .studentAbsenceExcusals()
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

      removeAbsenceExcusal: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentAbsenceExcusals: store
                      .studentAbsenceExcusals()
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
