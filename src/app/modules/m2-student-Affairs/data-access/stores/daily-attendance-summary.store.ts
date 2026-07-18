import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { DailyAttendanceSummaryService } from '../services/daily-attendance-summary.service';
import type { StudentDailyAttendanceSummary, CreateStudentDailyAttendanceSummary, UpdateStudentDailyAttendanceSummary } from '../models/daily-attendance-summary.interface';

interface DailyAttendanceSummaryState {
  studentDailyAttendanceSummaries: StudentDailyAttendanceSummary[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DailyAttendanceSummaryState = {
  studentDailyAttendanceSummaries: [],
  isLoading: false,
  error: null,
};

export const DailyAttendanceSummaryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(DailyAttendanceSummaryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentDailyAttendanceSummaries: StudentDailyAttendanceSummary[]) =>
                  patchState(store, { studentDailyAttendanceSummaries, isLoading: false }),
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
                next: (studentDailyAttendanceSummary: StudentDailyAttendanceSummary) =>
                  patchState(store, {
                    studentDailyAttendanceSummaries: [...store.studentDailyAttendanceSummaries(), studentDailyAttendanceSummary],
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
                next: (studentDailyAttendanceSummaries: StudentDailyAttendanceSummary[]) =>
                  patchState(store, { studentDailyAttendanceSummaries, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewDailyAttendanceSummary: rxMethod<CreateStudentDailyAttendanceSummary>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentDailyAttendanceSummary: StudentDailyAttendanceSummary) =>
                  patchState(store, {
                    studentDailyAttendanceSummaries: [...store.studentDailyAttendanceSummaries(), studentDailyAttendanceSummary],
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

      updateDailyAttendanceSummary: rxMethod<{ id: number; dto: UpdateStudentDailyAttendanceSummary }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentDailyAttendanceSummary) =>
                  patchState(store, {
                    studentDailyAttendanceSummaries: store
                      .studentDailyAttendanceSummaries()
                      .map((s) => (s.id === id ? updated : s)),
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

      removeDailyAttendanceSummary: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentDailyAttendanceSummaries: store
                      .studentDailyAttendanceSummaries()
                      .filter((s) => s.id !== id),
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
