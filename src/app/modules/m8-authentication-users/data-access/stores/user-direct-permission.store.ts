import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { UserDirectPermission, CreateUserDirectPermission, UpdateUserDirectPermission } from '../models/user-direct-permission.models';
import { UserDirectPermissionService } from '../services/user-direct-permission.service';

interface UserDirectPermissionState {
  userDirectPermissions: UserDirectPermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: UserDirectPermissionState = {
  userDirectPermissions: [],
  isLoading: false,
  error: null,
};

export const UserDirectPermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, userDirectPermissionService = inject(UserDirectPermissionService)) => ({
    loadAllUserDirectPermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          userDirectPermissionService.getAll().pipe(
            tapResponse({
              next: (userDirectPermissions) => patchState(store, { userDirectPermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewUserDirectPermission: rxMethod<CreateUserDirectPermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          userDirectPermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { userDirectPermissions: [...store.userDirectPermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateUserDirectPermission: rxMethod<{ id: number; dto: UpdateUserDirectPermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          userDirectPermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                userDirectPermissions: store.userDirectPermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteUserDirectPermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          userDirectPermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                userDirectPermissions: store.userDirectPermissions().filter((e) => (e as { id: number }).id !== id),
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
