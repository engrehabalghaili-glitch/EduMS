import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { StudentPermissionAuditLog, CreateStudentPermissionAuditLog, UpdateStudentPermissionAuditLog } from '../models/student-permission-audit-log.models';
import { StudentPermissionAuditLogService } from '../services/student-permission-audit-log.service';

interface StudentPermissionAuditLogState {
  studentPermissionAuditLogs: StudentPermissionAuditLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentPermissionAuditLogState = {
  studentPermissionAuditLogs: [],
  isLoading: false,
  error: null,
};

export const StudentPermissionAuditLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, studentPermissionAuditLogService = inject(StudentPermissionAuditLogService)) => ({
    loadAllStudentPermissionAuditLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          studentPermissionAuditLogService.getAll().pipe(
            tapResponse({
              next: (studentPermissionAuditLogs) => patchState(store, { studentPermissionAuditLogs, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewStudentPermissionAuditLog: rxMethod<CreateStudentPermissionAuditLog>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          studentPermissionAuditLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { studentPermissionAuditLogs: [...store.studentPermissionAuditLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateStudentPermissionAuditLog: rxMethod<{ id: number; dto: UpdateStudentPermissionAuditLog }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          studentPermissionAuditLogService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                studentPermissionAuditLogs: store.studentPermissionAuditLogs().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteStudentPermissionAuditLog: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          studentPermissionAuditLogService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                studentPermissionAuditLogs: store.studentPermissionAuditLogs().filter((e) => (e as { id: number }).id !== id),
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
