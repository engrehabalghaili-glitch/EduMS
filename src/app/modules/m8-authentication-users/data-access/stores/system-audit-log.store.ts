import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SystemAuditLog, CreateSystemAuditLog, UpdateSystemAuditLog } from '../models/system-audit-log.models';
import { SystemAuditLogService } from '../services/system-audit-log.service';

interface SystemAuditLogState {
  systemAuditLogs: SystemAuditLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SystemAuditLogState = {
  systemAuditLogs: [],
  isLoading: false,
  error: null,
};

export const SystemAuditLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, systemAuditLogService = inject(SystemAuditLogService)) => ({
    loadAllSystemAuditLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          systemAuditLogService.getAll().pipe(
            tapResponse({
              next: (systemAuditLogs) => patchState(store, { systemAuditLogs, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSystemAuditLog: rxMethod<CreateSystemAuditLog>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          systemAuditLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { systemAuditLogs: [...store.systemAuditLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSystemAuditLog: rxMethod<{ id: number; dto: UpdateSystemAuditLog }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          systemAuditLogService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                systemAuditLogs: store.systemAuditLogs().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSystemAuditLog: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          systemAuditLogService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                systemAuditLogs: store.systemAuditLogs().filter((e) => (e as { id: number }).id !== id),
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
