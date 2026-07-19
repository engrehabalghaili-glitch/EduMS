import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { LibraryBorrowingService } from '../services/library-borrowing.service';
import type { StudentLibraryBorrowingLog, CreateStudentLibraryBorrowingLog, UpdateStudentLibraryBorrowingLog } from '../models/library-borrowing.interface';

interface LibraryBorrowingState {
  studentLibraryBorrowingLogs: StudentLibraryBorrowingLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: LibraryBorrowingState = {
  studentLibraryBorrowingLogs: [],
  isLoading: false,
  error: null,
};

export const LibraryBorrowingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(LibraryBorrowingService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentLibraryBorrowingLogs: StudentLibraryBorrowingLog[]) =>
                  patchState(store, { studentLibraryBorrowingLogs, isLoading: false }),
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
                next: (studentLibraryBorrowingLog: StudentLibraryBorrowingLog) =>
                  patchState(store, {
                    studentLibraryBorrowingLogs: [...store.studentLibraryBorrowingLogs(), studentLibraryBorrowingLog],
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
                next: (studentLibraryBorrowingLogs: StudentLibraryBorrowingLog[]) =>
                  patchState(store, { studentLibraryBorrowingLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewLibraryBorrowing: rxMethod<CreateStudentLibraryBorrowingLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentLibraryBorrowingLog: StudentLibraryBorrowingLog) =>
                  patchState(store, {
                    studentLibraryBorrowingLogs: [...store.studentLibraryBorrowingLogs(), studentLibraryBorrowingLog],
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

      updateLibraryBorrowing: rxMethod<{ id: number; dto: UpdateStudentLibraryBorrowingLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentLibraryBorrowingLog) =>
                  patchState(store, {
                    studentLibraryBorrowingLogs: store
                      .studentLibraryBorrowingLogs()
                      .map((l) => (l.id === id ? updated : l)),
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

      removeLibraryBorrowing: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentLibraryBorrowingLogs: store
                      .studentLibraryBorrowingLogs()
                      .filter((l) => l.id !== id),
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
