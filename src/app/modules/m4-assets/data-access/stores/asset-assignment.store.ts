import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetAssignmentService } from '../services/asset-assignment.service';
import type { AssetAssignment, CreateAssetAssignmentRequest, UpdateAssetAssignmentRequest } from '../models/asset-assignments';

interface AssetAssignmentState {
  assetAssignments: AssetAssignment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetAssignmentState = {
  assetAssignments: [],
  isLoading: false,
  error: null,
};

export const AssetAssignmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetAssignmentService = inject(AssetAssignmentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetAssignmentService.getAll().pipe(
              tapResponse({
                next: (assetAssignments: AssetAssignment[]) =>
                  patchState(store, { assetAssignments, isLoading: false }),
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
            assetAssignmentService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetAssignments: AssetAssignment[]) =>
                  patchState(store, { assetAssignments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetAssignment: rxMethod<CreateAssetAssignmentRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetAssignmentService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetAssignment) =>
                  patchState(store, {
                    assetAssignments: [...store.assetAssignments(), entity],
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

      updateAssetAssignment: rxMethod<{ id: number; dto: UpdateAssetAssignmentRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetAssignmentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetAssignment) =>
                  patchState(store, {
                    assetAssignments: store
                      .assetAssignments()
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

      removeAssetAssignment: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetAssignmentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetAssignments: store.assetAssignments().filter((e) => e.id !== id),
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
