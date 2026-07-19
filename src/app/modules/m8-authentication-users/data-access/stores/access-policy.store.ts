import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { AccessPolicy, CreateAccessPolicy, UpdateAccessPolicy } from '../models/access-policy.models';
import { AccessPolicyService } from '../services/access-policy.service';

interface AccessPolicyState {
  accessPolicies: AccessPolicy[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AccessPolicyState = {
  accessPolicies: [],
  isLoading: false,
  error: null,
};

export const AccessPolicyStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, accessPolicyService = inject(AccessPolicyService)) => ({
    loadAllAccessPolicies: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          accessPolicyService.getAll().pipe(
            tapResponse({
              next: (accessPolicies) => patchState(store, { accessPolicies, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewAccessPolicy: rxMethod<CreateAccessPolicy>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          accessPolicyService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { accessPolicies: [...store.accessPolicies(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateAccessPolicy: rxMethod<{ id: number; dto: UpdateAccessPolicy }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          accessPolicyService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                accessPolicies: store.accessPolicies().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteAccessPolicy: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          accessPolicyService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                accessPolicies: store.accessPolicies().filter((e) => (e as { id: number }).id !== id),
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