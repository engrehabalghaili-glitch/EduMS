import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SystemUser, CreateSystemUser, UpdateSystemUser } from '../models/system-user.models';
import { SystemUserService } from '../services/system-user.service';

interface SystemUserState {
  systemUsers: SystemUser[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SystemUserState = {
  systemUsers: [],
  isLoading: false,
  error: null,
};

export const SystemUserStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, systemUserService = inject(SystemUserService)) => ({
    loadAllSystemUsers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          systemUserService.getAll().pipe(
            tapResponse({
              next: (systemUsers) => patchState(store, { systemUsers, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSystemUser: rxMethod<CreateSystemUser>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          systemUserService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { systemUsers: [...store.systemUsers(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSystemUser: rxMethod<{ id: number; dto: UpdateSystemUser }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          systemUserService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                systemUsers: store.systemUsers().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSystemUser: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          systemUserService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                systemUsers: store.systemUsers().filter((e) => (e as { id: number }).id !== id),
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
