import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { UsageViolationService } from '../services/usage-violation.service';
import type { UsageViolation, CreateUsageViolationRequest, UpdateUsageViolationRequest } from '../models/usage-violations';

interface UsageViolationState {
  usageViolations: UsageViolation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: UsageViolationState = {
  usageViolations: [],
  isLoading: false,
  error: null,
};

export const UsageViolationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, usageViolationService = inject(UsageViolationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            usageViolationService.getAll().pipe(
              tapResponse({
                next: (usageViolations: UsageViolation[]) =>
                  patchState(store, { usageViolations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByAssetId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((assetId) =>
            usageViolationService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (usageViolations: UsageViolation[]) =>
                  patchState(store, { usageViolations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewUsageViolation: rxMethod<CreateUsageViolationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            usageViolationService.create(dto).pipe(
              tapResponse({
                next: (entity: UsageViolation) =>
                  patchState(store, {
                    usageViolations: [...store.usageViolations(), entity],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateUsageViolation: rxMethod<{ id: number; dto: UpdateUsageViolationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            usageViolationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: UsageViolation) =>
                  patchState(store, {
                    usageViolations: store
                      .usageViolations()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeUsageViolation: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            usageViolationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    usageViolations: store.usageViolations().filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
