import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { RoleMatrix, CreateRoleMatrix, UpdateRoleMatrix } from '../models/role-matrix.models';
import { RoleMatrixService } from '../services/role-matrix.service';

interface RoleMatrixState {
  roleMatrices: RoleMatrix[];
  isLoading: boolean;
  error: string | null;
}

const initialState: RoleMatrixState = {
  roleMatrices: [],
  isLoading: false,
  error: null,
};

export const RoleMatrixStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, roleMatrixService = inject(RoleMatrixService)) => ({
    loadAllRoleMatrices: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          roleMatrixService.getAll().pipe(
            tapResponse({
              next: (roleMatrices) => patchState(store, { roleMatrices, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewRoleMatrix: rxMethod<CreateRoleMatrix>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          roleMatrixService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { roleMatrices: [...store.roleMatrices(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateRoleMatrix: rxMethod<{ id: number; dto: UpdateRoleMatrix }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          roleMatrixService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                roleMatrices: store.roleMatrices().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteRoleMatrix: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          roleMatrixService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                roleMatrices: store.roleMatrices().filter((e) => (e as { id: number }).id !== id),
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
