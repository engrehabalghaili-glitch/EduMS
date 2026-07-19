import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PsychologicalCounselingService } from '../services/psychological-counseling.service';
import type { StudentPsychologicalCounselingLog, CreateStudentPsychologicalCounselingLog, UpdateStudentPsychologicalCounselingLog } from '../models/psychological-counseling.interface';

interface PsychologicalCounselingState {
  studentPsychologicalCounselingLogs: StudentPsychologicalCounselingLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PsychologicalCounselingState = {
  studentPsychologicalCounselingLogs: [],
  isLoading: false,
  error: null,
};

export const PsychologicalCounselingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(PsychologicalCounselingService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentPsychologicalCounselingLogs: StudentPsychologicalCounselingLog[]) =>
                  patchState(store, { studentPsychologicalCounselingLogs, isLoading: false }),
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
                next: (studentPsychologicalCounselingLog: StudentPsychologicalCounselingLog) =>
                  patchState(store, {
                    studentPsychologicalCounselingLogs: [...store.studentPsychologicalCounselingLogs(), studentPsychologicalCounselingLog],
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
                next: (studentPsychologicalCounselingLogs: StudentPsychologicalCounselingLog[]) =>
                  patchState(store, { studentPsychologicalCounselingLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPsychologicalCounselingLog: rxMethod<CreateStudentPsychologicalCounselingLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentPsychologicalCounselingLog: StudentPsychologicalCounselingLog) =>
                  patchState(store, {
                    studentPsychologicalCounselingLogs: [...store.studentPsychologicalCounselingLogs(), studentPsychologicalCounselingLog],
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

      updatePsychologicalCounselingLog: rxMethod<{ id: number; dto: UpdateStudentPsychologicalCounselingLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentPsychologicalCounselingLog) =>
                  patchState(store, {
                    studentPsychologicalCounselingLogs: store
                      .studentPsychologicalCounselingLogs()
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

      removePsychologicalCounselingLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentPsychologicalCounselingLogs: store
                      .studentPsychologicalCounselingLogs()
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
