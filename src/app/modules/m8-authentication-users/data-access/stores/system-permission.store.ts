import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SystemPermission, CreateSystemPermission, UpdateSystemPermission } from '../models/system-permission.models';
import { SystemPermissionService } from '../services/system-permission.service';

interface SystemPermissionState {
  systemPermissions: SystemPermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SystemPermissionState = {
  systemPermissions: [],
  isLoading: false,
  error: null,
};

export const SystemPermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, systemPermissionService = inject(SystemPermissionService)) => ({
    loadAllSystemPermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          systemPermissionService.getAll().pipe(
            tapResponse({
              next: (systemPermissions) => patchState(store, { systemPermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSystemPermission: rxMethod<CreateSystemPermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          systemPermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { systemPermissions: [...store.systemPermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSystemPermission: rxMethod<{ id: number; dto: UpdateSystemPermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          systemPermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                systemPermissions: store.systemPermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSystemPermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          systemPermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                systemPermissions: store.systemPermissions().filter((e) => (e as { id: number }).id !== id),
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
