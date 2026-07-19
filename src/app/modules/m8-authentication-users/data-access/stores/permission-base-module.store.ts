import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { PermissionBaseModule, CreatePermissionBaseModule, UpdatePermissionBaseModule } from '../models/permission-base-module.models';
import { PermissionBaseModuleService } from '../services/permission-base-module.service';

interface PermissionBaseModuleState {
  permissionBaseModules: PermissionBaseModule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PermissionBaseModuleState = {
  permissionBaseModules: [],
  isLoading: false,
  error: null,
};

export const PermissionBaseModuleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, permissionBaseModuleService = inject(PermissionBaseModuleService)) => ({
    loadAllPermissionBaseModules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          permissionBaseModuleService.getAll().pipe(
            tapResponse({
              next: (permissionBaseModules) => patchState(store, { permissionBaseModules, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewPermissionBaseModule: rxMethod<CreatePermissionBaseModule>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          permissionBaseModuleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { permissionBaseModules: [...store.permissionBaseModules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updatePermissionBaseModule: rxMethod<{ id: number; dto: UpdatePermissionBaseModule }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          permissionBaseModuleService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                permissionBaseModules: store.permissionBaseModules().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deletePermissionBaseModule: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          permissionBaseModuleService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                permissionBaseModules: store.permissionBaseModules().filter((e) => (e as { id: number }).id !== id),
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