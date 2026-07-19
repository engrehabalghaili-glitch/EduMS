import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { StudentFinancePermission, CreateStudentFinancePermission, UpdateStudentFinancePermission } from '../models/student-finance-permission.models';
import { StudentFinancePermissionService } from '../services/student-finance-permission.service';

interface StudentFinancePermissionState {
  studentFinancePermissions: StudentFinancePermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentFinancePermissionState = {
  studentFinancePermissions: [],
  isLoading: false,
  error: null,
};

export const StudentFinancePermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, studentFinancePermissionService = inject(StudentFinancePermissionService)) => ({
    loadAllStudentFinancePermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          studentFinancePermissionService.getAll().pipe(
            tapResponse({
              next: (studentFinancePermissions) => patchState(store, { studentFinancePermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewStudentFinancePermission: rxMethod<CreateStudentFinancePermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          studentFinancePermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { studentFinancePermissions: [...store.studentFinancePermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateStudentFinancePermission: rxMethod<{ id: number; dto: UpdateStudentFinancePermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          studentFinancePermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                studentFinancePermissions: store.studentFinancePermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteStudentFinancePermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          studentFinancePermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                studentFinancePermissions: store.studentFinancePermissions().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
