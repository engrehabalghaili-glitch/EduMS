import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolAuditLog, CreateSchoolAuditLogDto, UpdateSchoolAuditLogDto } from '../models/school-audit-log';
import { SchoolAuditLogService } from '../services/school-audit-log.service';

interface SchoolAuditLogState {
  schoolAuditLogs: SchoolAuditLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAuditLogState = {
  schoolAuditLogs: [],
  isLoading: false,
  error: null,
};

export const SchoolAuditLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolAuditLogService = inject(SchoolAuditLogService)) => ({
    loadAllSchoolAuditLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolAuditLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolAuditLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolAuditLog: rxMethod<CreateSchoolAuditLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolAuditLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolAuditLogs: [...store.schoolAuditLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
