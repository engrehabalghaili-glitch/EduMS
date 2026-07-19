import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SelfServicePortalRequest, CreateSelfServicePortalRequest, UpdateSelfServicePortalRequest } from '../models/self-service-portal-request.types';
import { SelfServicePortalRequestService } from '../services/self-service-portal-request.service';

interface SelfServicePortalRequestState {
  selfServicePortalRequests: SelfServicePortalRequest[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SelfServicePortalRequestState = {
  selfServicePortalRequests: [],
  isLoading: false,
  error: null,
};

export const SelfServicePortalRequestStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, selfServicePortalRequestService = inject(SelfServicePortalRequestService)) => ({
    loadAllSelfServicePortalRequests: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          selfServicePortalRequestService.getAll().pipe(
            tapResponse({
              next: (selfServicePortalRequests) => patchState(store, { selfServicePortalRequests, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSelfServicePortalRequest: rxMethod<CreateSelfServicePortalRequest>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          selfServicePortalRequestService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { selfServicePortalRequests: [...store.selfServicePortalRequests(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSelfServicePortalRequest: rxMethod<{ id: number; dto: UpdateSelfServicePortalRequest }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          selfServicePortalRequestService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                selfServicePortalRequests: store.selfServicePortalRequests().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSelfServicePortalRequest: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          selfServicePortalRequestService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                selfServicePortalRequests: store.selfServicePortalRequests().filter((e) => (e as { id: number }).id !== id),
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
