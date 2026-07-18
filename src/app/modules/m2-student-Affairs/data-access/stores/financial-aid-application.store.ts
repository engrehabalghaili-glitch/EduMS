import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FinancialAidApplicationService } from '../services/financial-aid-application.service';
import type { StudentFinancialAidApplication, CreateStudentFinancialAidApplication, UpdateStudentFinancialAidApplication } from '../models/financial-aid-application.interface';

interface FinancialAidApplicationState {
  studentFinancialAidApplications: StudentFinancialAidApplication[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FinancialAidApplicationState = {
  studentFinancialAidApplications: [],
  isLoading: false,
  error: null,
};

export const FinancialAidApplicationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(FinancialAidApplicationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentFinancialAidApplications: StudentFinancialAidApplication[]) =>
                  patchState(store, { studentFinancialAidApplications, isLoading: false }),
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
                next: (studentFinancialAidApplication: StudentFinancialAidApplication) =>
                  patchState(store, {
                    studentFinancialAidApplications: [...store.studentFinancialAidApplications(), studentFinancialAidApplication],
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
                next: (studentFinancialAidApplications: StudentFinancialAidApplication[]) =>
                  patchState(store, { studentFinancialAidApplications, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFinancialAidApplication: rxMethod<CreateStudentFinancialAidApplication>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentFinancialAidApplication: StudentFinancialAidApplication) =>
                  patchState(store, {
                    studentFinancialAidApplications: [...store.studentFinancialAidApplications(), studentFinancialAidApplication],
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

      updateFinancialAidApplication: rxMethod<{ id: number; dto: UpdateStudentFinancialAidApplication }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentFinancialAidApplication) =>
                  patchState(store, {
                    studentFinancialAidApplications: store
                      .studentFinancialAidApplications()
                      .map((f) => (f.id === id ? updated : f)),
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

      removeFinancialAidApplication: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentFinancialAidApplications: store
                      .studentFinancialAidApplications()
                      .filter((f) => f.id !== id),
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
