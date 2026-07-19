import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SystemRole, CreateSystemRole, UpdateSystemRole } from '../models/system-role.models';
import { SystemRoleService } from '../services/system-role.service';

interface SystemRoleState {
  systemRoles: SystemRole[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SystemRoleState = {
  systemRoles: [],
  isLoading: false,
  error: null,
};

export const SystemRoleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, systemRoleService = inject(SystemRoleService)) => ({
    loadAllSystemRoles: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          systemRoleService.getAll().pipe(
            tapResponse({
              next: (systemRoles) => patchState(store, { systemRoles, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSystemRole: rxMethod<CreateSystemRole>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          systemRoleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { systemRoles: [...store.systemRoles(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSystemRole: rxMethod<{ id: number; dto: UpdateSystemRole }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          systemRoleService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                systemRoles: store.systemRoles().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSystemRole: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          systemRoleService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                systemRoles: store.systemRoles().filter((e) => (e as { id: number }).id !== id),
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
