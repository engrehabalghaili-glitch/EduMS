import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { GuardianRelationshipService } from '../services/guardian-relationship.service';
import type { StudentGuardianRelationship, CreateStudentGuardianRelationship, UpdateStudentGuardianRelationship } from '../models/guardian-relationship.interface';

interface GuardianRelationshipState {
  studentGuardianRelationships: StudentGuardianRelationship[];
  isLoading: boolean;
  error: string | null;
}

const initialState: GuardianRelationshipState = {
  studentGuardianRelationships: [],
  isLoading: false,
  error: null,
};

export const GuardianRelationshipStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(GuardianRelationshipService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentGuardianRelationships: StudentGuardianRelationship[]) =>
                  patchState(store, { studentGuardianRelationships, isLoading: false }),
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
                next: (studentGuardianRelationship: StudentGuardianRelationship) =>
                  patchState(store, {
                    studentGuardianRelationships: [...store.studentGuardianRelationships(), studentGuardianRelationship],
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
                next: (studentGuardianRelationships: StudentGuardianRelationship[]) =>
                  patchState(store, { studentGuardianRelationships, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewGuardianRelationship: rxMethod<CreateStudentGuardianRelationship>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentGuardianRelationship: StudentGuardianRelationship) =>
                  patchState(store, {
                    studentGuardianRelationships: [...store.studentGuardianRelationships(), studentGuardianRelationship],
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

      updateGuardianRelationship: rxMethod<{ id: number; dto: UpdateStudentGuardianRelationship }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentGuardianRelationship) =>
                  patchState(store, {
                    studentGuardianRelationships: store
                      .studentGuardianRelationships()
                      .map((g) => (g.id === id ? updated : g)),
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

      removeGuardianRelationship: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentGuardianRelationships: store
                      .studentGuardianRelationships()
                      .filter((g) => g.id !== id),
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
