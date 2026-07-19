import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { StudentBasePermission, CreateStudentBasePermission, UpdateStudentBasePermission } from '../models/student-base-permission.models';
import { StudentBasePermissionService } from '../services/student-base-permission.service';

interface StudentBasePermissionState {
  studentBasePermissions: StudentBasePermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentBasePermissionState = {
  studentBasePermissions: [],
  isLoading: false,
  error: null,
};

export const StudentBasePermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, studentBasePermissionService = inject(StudentBasePermissionService)) => ({
    loadAllStudentBasePermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          studentBasePermissionService.getAll().pipe(
            tapResponse({
              next: (studentBasePermissions) => patchState(store, { studentBasePermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewStudentBasePermission: rxMethod<CreateStudentBasePermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          studentBasePermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { studentBasePermissions: [...store.studentBasePermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateStudentBasePermission: rxMethod<{ id: number; dto: UpdateStudentBasePermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          studentBasePermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                studentBasePermissions: store.studentBasePermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteStudentBasePermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          studentBasePermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                studentBasePermissions: store.studentBasePermissions().filter((e) => (e as { id: number }).id !== id),
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
