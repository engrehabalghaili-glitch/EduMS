import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { IdentityDocumentService } from '../services/identity-document.service';
import type { StudentIdentityDocument, CreateStudentIdentityDocument, UpdateStudentIdentityDocument } from '../models/identity-document.interface';

interface IdentityDocumentState {
  studentIdentityDocuments: StudentIdentityDocument[];
  isLoading: boolean;
  error: string | null;
}

const initialState: IdentityDocumentState = {
  studentIdentityDocuments: [],
  isLoading: false,
  error: null,
};

export const IdentityDocumentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(IdentityDocumentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentIdentityDocuments: StudentIdentityDocument[]) =>
                  patchState(store, { studentIdentityDocuments, isLoading: false }),
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
                next: (studentIdentityDocument: StudentIdentityDocument) =>
                  patchState(store, {
                    studentIdentityDocuments: [...store.studentIdentityDocuments(), studentIdentityDocument],
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
                next: (studentIdentityDocuments: StudentIdentityDocument[]) =>
                  patchState(store, { studentIdentityDocuments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewIdentityDocument: rxMethod<CreateStudentIdentityDocument>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentIdentityDocument: StudentIdentityDocument) =>
                  patchState(store, {
                    studentIdentityDocuments: [...store.studentIdentityDocuments(), studentIdentityDocument],
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

      updateIdentityDocument: rxMethod<{ id: number; dto: UpdateStudentIdentityDocument }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentIdentityDocument) =>
                  patchState(store, {
                    studentIdentityDocuments: store
                      .studentIdentityDocuments()
                      .map((i) => (i.id === id ? updated : i)),
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

      removeIdentityDocument: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentIdentityDocuments: store
                      .studentIdentityDocuments()
                      .filter((i) => i.id !== id),
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
