import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { UserRoleAssignment, CreateUserRoleAssignment, UpdateUserRoleAssignment } from '../models/user-role-assignment.models';
import { UserRoleAssignmentService } from '../services/user-role-assignment.service';

interface UserRoleAssignmentState {
  userRoleAssignments: UserRoleAssignment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: UserRoleAssignmentState = {
  userRoleAssignments: [],
  isLoading: false,
  error: null,
};

export const UserRoleAssignmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, userRoleAssignmentService = inject(UserRoleAssignmentService)) => ({
    loadAllUserRoleAssignments: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          userRoleAssignmentService.getAll().pipe(
            tapResponse({
              next: (userRoleAssignments) => patchState(store, { userRoleAssignments, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewUserRoleAssignment: rxMethod<CreateUserRoleAssignment>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          userRoleAssignmentService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { userRoleAssignments: [...store.userRoleAssignments(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateUserRoleAssignment: rxMethod<{ id: number; dto: UpdateUserRoleAssignment }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          userRoleAssignmentService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                userRoleAssignments: store.userRoleAssignments().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteUserRoleAssignment: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          userRoleAssignmentService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                userRoleAssignments: store.userRoleAssignments().filter((e) => (e as { id: number }).id !== id),
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
