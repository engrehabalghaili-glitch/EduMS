import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetRevaluationImpairmentService } from '../services/asset-revaluation-impairment.service';
import type { AssetRevaluationImpairment, CreateAssetRevaluationImpairmentRequest, UpdateAssetRevaluationImpairmentRequest } from '../models/asset-revaluation-impairments';

interface AssetRevaluationImpairmentState {
  assetRevaluationImpairments: AssetRevaluationImpairment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetRevaluationImpairmentState = {
  assetRevaluationImpairments: [],
  isLoading: false,
  error: null,
};

export const AssetRevaluationImpairmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetRevaluationImpairmentService = inject(AssetRevaluationImpairmentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetRevaluationImpairmentService.getAll().pipe(
              tapResponse({
                next: (assetRevaluationImpairments: AssetRevaluationImpairment[]) =>
                  patchState(store, { assetRevaluationImpairments, isLoading: false }),
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
            assetRevaluationImpairmentService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetRevaluationImpairments: AssetRevaluationImpairment[]) =>
                  patchState(store, { assetRevaluationImpairments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetRevaluationImpairment: rxMethod<CreateAssetRevaluationImpairmentRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetRevaluationImpairmentService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetRevaluationImpairment) =>
                  patchState(store, {
                    assetRevaluationImpairments: [...store.assetRevaluationImpairments(), entity],
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

      updateAssetRevaluationImpairment: rxMethod<{ id: number; dto: UpdateAssetRevaluationImpairmentRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetRevaluationImpairmentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetRevaluationImpairment) =>
                  patchState(store, {
                    assetRevaluationImpairments: store
                      .assetRevaluationImpairments()
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

      removeAssetRevaluationImpairment: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetRevaluationImpairmentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetRevaluationImpairments: store.assetRevaluationImpairments().filter((e) => e.id !== id),
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
