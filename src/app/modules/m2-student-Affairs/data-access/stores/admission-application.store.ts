import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StudentAdmissionApplicationService } from '../services/student-admission-application.service';
import type { StudentAdmissionApplication, CreateStudentAdmissionApplication, UpdateStudentAdmissionApplication } from '../models/admission-application.interface';

interface AdmissionApplicationState {
  studentAdmissionApplications: StudentAdmissionApplication[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AdmissionApplicationState = {
  studentAdmissionApplications: [],
  isLoading: false,
  error: null,
};

export const AdmissionApplicationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(StudentAdmissionApplicationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentAdmissionApplications: StudentAdmissionApplication[]) =>
                  patchState(store, { studentAdmissionApplications, isLoading: false }),
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
                next: (studentAdmissionApplication: StudentAdmissionApplication) =>
                  patchState(store, {
                    studentAdmissionApplications: [...store.studentAdmissionApplications(), studentAdmissionApplication],
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

      addNewAdmissionApplication: rxMethod<CreateStudentAdmissionApplication>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentAdmissionApplication: StudentAdmissionApplication) =>
                  patchState(store, {
                    studentAdmissionApplications: [...store.studentAdmissionApplications(), studentAdmissionApplication],
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

      updateAdmissionApplication: rxMethod<{ id: number; dto: UpdateStudentAdmissionApplication }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentAdmissionApplication) =>
                  patchState(store, {
                    studentAdmissionApplications: store
                      .studentAdmissionApplications()
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

      removeAdmissionApplication: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentAdmissionApplications: store
                      .studentAdmissionApplications()
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
