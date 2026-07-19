import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { DisciplinaryHistoryService } from '../services/disciplinary-history.service';
import type { StudentDisciplinaryHistory, CreateStudentDisciplinaryHistory, UpdateStudentDisciplinaryHistory } from '../models/disciplinary-history.interface';

interface DisciplinaryHistoryState {
  studentDisciplinaryHistories: StudentDisciplinaryHistory[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DisciplinaryHistoryState = {
  studentDisciplinaryHistories: [],
  isLoading: false,
  error: null,
};

export const DisciplinaryHistoryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(DisciplinaryHistoryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentDisciplinaryHistories: StudentDisciplinaryHistory[]) =>
                  patchState(store, { studentDisciplinaryHistories, isLoading: false }),
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
                next: (studentDisciplinaryHistory: StudentDisciplinaryHistory) =>
                  patchState(store, {
                    studentDisciplinaryHistories: [...store.studentDisciplinaryHistories(), studentDisciplinaryHistory],
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
                next: (studentDisciplinaryHistories: StudentDisciplinaryHistory[]) =>
                  patchState(store, { studentDisciplinaryHistories, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewDisciplinaryHistory: rxMethod<CreateStudentDisciplinaryHistory>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentDisciplinaryHistory: StudentDisciplinaryHistory) =>
                  patchState(store, {
                    studentDisciplinaryHistories: [...store.studentDisciplinaryHistories(), studentDisciplinaryHistory],
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

      updateDisciplinaryHistory: rxMethod<{ id: number; dto: UpdateStudentDisciplinaryHistory }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentDisciplinaryHistory) =>
                  patchState(store, {
                    studentDisciplinaryHistories: store
                      .studentDisciplinaryHistories()
                      .map((d) => (d.id === id ? updated : d)),
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

      removeDisciplinaryHistory: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentDisciplinaryHistories: store
                      .studentDisciplinaryHistories()
                      .filter((d) => d.id !== id),
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
