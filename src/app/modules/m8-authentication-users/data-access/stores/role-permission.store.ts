import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { RolePermission, CreateRolePermission, UpdateRolePermission } from '../models/role-permission.models';
import { RolePermissionService } from '../services/role-permission.service';

interface RolePermissionState {
  rolePermissions: RolePermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: RolePermissionState = {
  rolePermissions: [],
  isLoading: false,
  error: null,
};

export const RolePermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, rolePermissionService = inject(RolePermissionService)) => ({
    loadAllRolePermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          rolePermissionService.getAll().pipe(
            tapResponse({
              next: (rolePermissions) => patchState(store, { rolePermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewRolePermission: rxMethod<CreateRolePermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          rolePermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { rolePermissions: [...store.rolePermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateRolePermission: rxMethod<{ id: number; dto: UpdateRolePermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          rolePermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                rolePermissions: store.rolePermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteRolePermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          rolePermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                rolePermissions: store.rolePermissions().filter((e) => (e as { id: number }).id !== id),
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
