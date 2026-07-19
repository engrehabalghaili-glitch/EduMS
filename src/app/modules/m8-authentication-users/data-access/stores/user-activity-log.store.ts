import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { UserActivityLog, CreateUserActivityLog, UpdateUserActivityLog } from '../models/user-activity-log.models';
import { UserActivityLogService } from '../services/user-activity-log.service';

interface UserActivityLogState {
  userActivityLogs: UserActivityLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: UserActivityLogState = {
  userActivityLogs: [],
  isLoading: false,
  error: null,
};

export const UserActivityLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, userActivityLogService = inject(UserActivityLogService)) => ({
    loadAllUserActivityLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          userActivityLogService.getAll().pipe(
            tapResponse({
              next: (userActivityLogs) => patchState(store, { userActivityLogs, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewUserActivityLog: rxMethod<CreateUserActivityLog>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          userActivityLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { userActivityLogs: [...store.userActivityLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateUserActivityLog: rxMethod<{ id: number; dto: UpdateUserActivityLog }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          userActivityLogService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                userActivityLogs: store.userActivityLogs().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteUserActivityLog: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          userActivityLogService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                userActivityLogs: store.userActivityLogs().filter((e) => (e as { id: number }).id !== id),
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
