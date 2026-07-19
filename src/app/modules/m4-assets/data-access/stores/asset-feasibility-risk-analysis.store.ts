import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetFeasibilityRiskAnalysisService } from '../services/asset-feasibility-risk-analysis.service';
import type { AssetFeasibilityRiskAnalysis, CreateAssetFeasibilityRiskAnalysisRequest, UpdateAssetFeasibilityRiskAnalysisRequest } from '../models/asset-feasibility-risk-analyses';

interface AssetFeasibilityRiskAnalysisState {
  assetFeasibilityRiskAnalyses: AssetFeasibilityRiskAnalysis[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetFeasibilityRiskAnalysisState = {
  assetFeasibilityRiskAnalyses: [],
  isLoading: false,
  error: null,
};

export const AssetFeasibilityRiskAnalysisStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetFeasibilityRiskAnalysisService = inject(AssetFeasibilityRiskAnalysisService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetFeasibilityRiskAnalysisService.getAll().pipe(
              tapResponse({
                next: (assetFeasibilityRiskAnalyses: AssetFeasibilityRiskAnalysis[]) =>
                  patchState(store, { assetFeasibilityRiskAnalyses, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            assetFeasibilityRiskAnalysisService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetFeasibilityRiskAnalyses: AssetFeasibilityRiskAnalysis[]) =>
                  patchState(store, { assetFeasibilityRiskAnalyses, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetFeasibilityRiskAnalysis: rxMethod<CreateAssetFeasibilityRiskAnalysisRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetFeasibilityRiskAnalysisService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetFeasibilityRiskAnalysis) =>
                  patchState(store, {
                    assetFeasibilityRiskAnalyses: [...store.assetFeasibilityRiskAnalyses(), entity],
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

      updateAssetFeasibilityRiskAnalysis: rxMethod<{ id: number; dto: UpdateAssetFeasibilityRiskAnalysisRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetFeasibilityRiskAnalysisService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetFeasibilityRiskAnalysis) =>
                  patchState(store, {
                    assetFeasibilityRiskAnalyses: store
                      .assetFeasibilityRiskAnalyses()
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

      removeAssetFeasibilityRiskAnalysis: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetFeasibilityRiskAnalysisService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetFeasibilityRiskAnalyses: store.assetFeasibilityRiskAnalyses().filter((e) => e.id !== id),
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
