import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssignmentSubmissionService } from '../services/assignment-submission.service';
import type { StudentAssignmentSubmission, CreateStudentAssignmentSubmission, UpdateStudentAssignmentSubmission } from '../models/assignment-submission.interface';

interface AssignmentSubmissionState {
  studentAssignmentSubmissions: StudentAssignmentSubmission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssignmentSubmissionState = {
  studentAssignmentSubmissions: [],
  isLoading: false,
  error: null,
};

export const AssignmentSubmissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(AssignmentSubmissionService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentAssignmentSubmissions: StudentAssignmentSubmission[]) =>
                  patchState(store, { studentAssignmentSubmissions, isLoading: false }),
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
                next: (studentAssignmentSubmission: StudentAssignmentSubmission) =>
                  patchState(store, {
                    studentAssignmentSubmissions: [...store.studentAssignmentSubmissions(), studentAssignmentSubmission],
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
                next: (studentAssignmentSubmissions: StudentAssignmentSubmission[]) =>
                  patchState(store, { studentAssignmentSubmissions, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssignmentSubmission: rxMethod<CreateStudentAssignmentSubmission>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentAssignmentSubmission: StudentAssignmentSubmission) =>
                  patchState(store, {
                    studentAssignmentSubmissions: [...store.studentAssignmentSubmissions(), studentAssignmentSubmission],
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

      updateAssignmentSubmission: rxMethod<{ id: number; dto: UpdateStudentAssignmentSubmission }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentAssignmentSubmission) =>
                  patchState(store, {
                    studentAssignmentSubmissions: store
                      .studentAssignmentSubmissions()
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

      removeAssignmentSubmission: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentAssignmentSubmissions: store
                      .studentAssignmentSubmissions()
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
