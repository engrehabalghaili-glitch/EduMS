import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { PermissionType, CreatePermissionType, UpdatePermissionType } from '../models/permission-type.models';
import { PermissionTypeService } from '../services/permission-type.service';

interface PermissionTypeState {
  permissionTypes: PermissionType[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PermissionTypeState = {
  permissionTypes: [],
  isLoading: false,
  error: null,
};

export const PermissionTypeStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, permissionTypeService = inject(PermissionTypeService)) => ({
    loadAllPermissionTypes: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          permissionTypeService.getAll().pipe(
            tapResponse({
              next: (permissionTypes) => patchState(store, { permissionTypes, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewPermissionType: rxMethod<CreatePermissionType>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          permissionTypeService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { permissionTypes: [...store.permissionTypes(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updatePermissionType: rxMethod<{ id: number; dto: UpdatePermissionType }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          permissionTypeService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                permissionTypes: store.permissionTypes().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deletePermissionType: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          permissionTypeService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                permissionTypes: store.permissionTypes().filter((e) => (e as { id: number }).id !== id),
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