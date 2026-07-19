import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { BehaviorPermissionMatrix, CreateBehaviorPermissionMatrix, UpdateBehaviorPermissionMatrix } from '../models/behavior-permission-matrix.models';
import { BehaviorPermissionMatrixService } from '../services/behavior-permission-matrix.service';

interface BehaviorPermissionMatrixState {
  behaviorPermissionMatrices: BehaviorPermissionMatrix[];
  isLoading: boolean;
  error: string | null;
}

const initialState: BehaviorPermissionMatrixState = {
  behaviorPermissionMatrices: [],
  isLoading: false,
  error: null,
};

export const BehaviorPermissionMatrixStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, behaviorPermissionMatrixService = inject(BehaviorPermissionMatrixService)) => ({
    loadAllBehaviorPermissionMatrices: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          behaviorPermissionMatrixService.getAll().pipe(
            tapResponse({
              next: (behaviorPermissionMatrices) => patchState(store, { behaviorPermissionMatrices, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewBehaviorPermissionMatrix: rxMethod<CreateBehaviorPermissionMatrix>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          behaviorPermissionMatrixService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { behaviorPermissionMatrices: [...store.behaviorPermissionMatrices(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateBehaviorPermissionMatrix: rxMethod<{ id: number; dto: UpdateBehaviorPermissionMatrix }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          behaviorPermissionMatrixService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                behaviorPermissionMatrices: store.behaviorPermissionMatrices().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteBehaviorPermissionMatrix: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          behaviorPermissionMatrixService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                behaviorPermissionMatrices: store.behaviorPermissionMatrices().filter((e) => (e as { id: number }).id !== id),
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