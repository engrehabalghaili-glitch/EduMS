import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StudentAccountService } from '../services/student-account.service';
import type { StudentAccount, CreateStudentAccountDto, UpdateStudentAccountDto } from '../models/student-account.interface';

interface StudentAccountState {
  studentAccounts: StudentAccount[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentAccountState = {
  studentAccounts: [],
  isLoading: false,
  error: null,
};

export const StudentAccountStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, studentAccountService = inject(StudentAccountService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            studentAccountService.getAll().pipe(
              tapResponse({
                next: (studentAccounts: StudentAccount[]) =>
                  patchState(store, { studentAccounts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStudentAccount: rxMethod<CreateStudentAccountDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            studentAccountService.create(dto).pipe(
              tapResponse({
                next: (entity: StudentAccount) =>
                  patchState(store, {
                    studentAccounts: [...store.studentAccounts(), entity],
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

      updateStudentAccount: rxMethod<{ id: number; dto: UpdateStudentAccountDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            studentAccountService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentAccount) =>
                  patchState(store, {
                    studentAccounts: store
                      .studentAccounts()
                      .map((e) => (e.id === id ? updated : e)),
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

      removeStudentAccount: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            studentAccountService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentAccounts: store.studentAccounts().filter((e) => e.id !== id),
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
