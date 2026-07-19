import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { OfficePermission, CreateOfficePermission, UpdateOfficePermission } from '../models/office-permission.models';
import { OfficePermissionService } from '../services/office-permission.service';

interface OfficePermissionState {
  officePermissions: OfficePermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: OfficePermissionState = {
  officePermissions: [],
  isLoading: false,
  error: null,
};

export const OfficePermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, officePermissionService = inject(OfficePermissionService)) => ({
    loadAllOfficePermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          officePermissionService.getAll().pipe(
            tapResponse({
              next: (officePermissions) => patchState(store, { officePermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewOfficePermission: rxMethod<CreateOfficePermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          officePermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { officePermissions: [...store.officePermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateOfficePermission: rxMethod<{ id: number; dto: UpdateOfficePermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          officePermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                officePermissions: store.officePermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteOfficePermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          officePermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                officePermissions: store.officePermissions().filter((e) => (e as { id: number }).id !== id),
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