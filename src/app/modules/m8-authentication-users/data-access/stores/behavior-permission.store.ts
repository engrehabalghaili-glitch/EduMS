import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { BehaviorPermission, CreateBehaviorPermission, UpdateBehaviorPermission } from '../models/behavior-permission.models';
import { BehaviorPermissionService } from '../services/behavior-permission.service';

interface BehaviorPermissionState {
  behaviorPermissions: BehaviorPermission[];
  isLoading: boolean;
  error: string | null;
}

const initialState: BehaviorPermissionState = {
  behaviorPermissions: [],
  isLoading: false,
  error: null,
};

export const BehaviorPermissionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, behaviorPermissionService = inject(BehaviorPermissionService)) => ({
    loadAllBehaviorPermissions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          behaviorPermissionService.getAll().pipe(
            tapResponse({
              next: (behaviorPermissions) => patchState(store, { behaviorPermissions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewBehaviorPermission: rxMethod<CreateBehaviorPermission>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          behaviorPermissionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { behaviorPermissions: [...store.behaviorPermissions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateBehaviorPermission: rxMethod<{ id: number; dto: UpdateBehaviorPermission }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          behaviorPermissionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                behaviorPermissions: store.behaviorPermissions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteBehaviorPermission: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          behaviorPermissionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                behaviorPermissions: store.behaviorPermissions().filter((e) => (e as { id: number }).id !== id),
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