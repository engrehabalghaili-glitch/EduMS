import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PreviousAcademicHistoryService } from '../services/previous-academic-history.service';
import type { StudentPreviousAcademicHistory, CreateStudentPreviousAcademicHistory, UpdateStudentPreviousAcademicHistory } from '../models/previous-academic-history.interface';

interface PreviousAcademicHistoryState {
  studentPreviousAcademicHistories: StudentPreviousAcademicHistory[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PreviousAcademicHistoryState = {
  studentPreviousAcademicHistories: [],
  isLoading: false,
  error: null,
};

export const PreviousAcademicHistoryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(PreviousAcademicHistoryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentPreviousAcademicHistories: StudentPreviousAcademicHistory[]) =>
                  patchState(store, { studentPreviousAcademicHistories, isLoading: false }),
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
                next: (studentPreviousAcademicHistory: StudentPreviousAcademicHistory) =>
                  patchState(store, {
                    studentPreviousAcademicHistories: [...store.studentPreviousAcademicHistories(), studentPreviousAcademicHistory],
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
                next: (studentPreviousAcademicHistories: StudentPreviousAcademicHistory[]) =>
                  patchState(store, { studentPreviousAcademicHistories, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPreviousAcademicHistory: rxMethod<CreateStudentPreviousAcademicHistory>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentPreviousAcademicHistory: StudentPreviousAcademicHistory) =>
                  patchState(store, {
                    studentPreviousAcademicHistories: [...store.studentPreviousAcademicHistories(), studentPreviousAcademicHistory],
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

      updatePreviousAcademicHistory: rxMethod<{ id: number; dto: UpdateStudentPreviousAcademicHistory }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentPreviousAcademicHistory) =>
                  patchState(store, {
                    studentPreviousAcademicHistories: store
                      .studentPreviousAcademicHistories()
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

      removePreviousAcademicHistory: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentPreviousAcademicHistories: store
                      .studentPreviousAcademicHistories()
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
