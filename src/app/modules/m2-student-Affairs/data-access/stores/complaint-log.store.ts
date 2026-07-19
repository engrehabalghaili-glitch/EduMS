import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ComplaintLogService } from '../services/complaint-log.service';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

interface ComplaintLogState {
  studentComplaintLogs: StudentComplaintLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ComplaintLogState = {
  studentComplaintLogs: [],
  isLoading: false,
  error: null,
};

export const ComplaintLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(ComplaintLogService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentComplaintLogs: StudentComplaintLog[]) =>
                  patchState(store, { studentComplaintLogs, isLoading: false }),
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
                next: (studentComplaintLog: StudentComplaintLog) =>
                  patchState(store, {
                    studentComplaintLogs: [...store.studentComplaintLogs(), studentComplaintLog],
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
                next: (studentComplaintLogs: StudentComplaintLog[]) =>
                  patchState(store, { studentComplaintLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewComplaintLog: rxMethod<CreateStudentComplaintLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentComplaintLog: StudentComplaintLog) =>
                  patchState(store, {
                    studentComplaintLogs: [...store.studentComplaintLogs(), studentComplaintLog],
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

      updateComplaintLog: rxMethod<{ id: number; dto: UpdateStudentComplaintLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentComplaintLog) =>
                  patchState(store, {
                    studentComplaintLogs: store
                      .studentComplaintLogs()
                      .map((c) => (c.id === id ? updated : c)),
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

      removeComplaintLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentComplaintLogs: store
                      .studentComplaintLogs()
                      .filter((c) => c.id !== id),
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
