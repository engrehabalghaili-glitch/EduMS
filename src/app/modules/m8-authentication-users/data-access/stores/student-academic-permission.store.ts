import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { StudentAcademicPermission, CreateStudentAcademicPermission, UpdateStudentAcademicPermission } from '../models/student-academic-permission.models';
import { StudentAcademicPermissionService } from '../services/student-academic-permission.service';

interface StudentAcademicPermissionState {
  studentAcademicPermissions: StudentAcademicPermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentAcademicPermissionState = {
  studentAcademicPermissions: [],
  isLoading: false,
  error: null,
};

export const StudentAcademicPermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, studentAcademicPermissionService = inject(StudentAcademicPermissionService)) => ({
    loadAllStudentAcademicPermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          studentAcademicPermissionService.getAll().pipe(
            tapResponse({
              next: (studentAcademicPermissions) => patchState(store, { studentAcademicPermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewStudentAcademicPermission: rxMethod<CreateStudentAcademicPermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          studentAcademicPermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { studentAcademicPermissions: [...store.studentAcademicPermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateStudentAcademicPermission: rxMethod<{ id: number; dto: UpdateStudentAcademicPermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          studentAcademicPermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                studentAcademicPermissions: store.studentAcademicPermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteStudentAcademicPermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          studentAcademicPermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                studentAcademicPermissions: store.studentAcademicPermissions().filter((e) => (e as { id: number }).id !== id),
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
