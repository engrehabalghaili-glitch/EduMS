import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { TrendAnalysisResultService } from '../services/trend-analysis-result.service';
import type {
  TrendAnalysisResult,
  CreateTrendAnalysisResult,
  UpdateTrendAnalysisResult,
} from '../models/trend-analysis-result.dto';

interface TrendAnalysisResultState {
  trendAnalysisResults: TrendAnalysisResult[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TrendAnalysisResultState = {
  trendAnalysisResults: [],
  isLoading: false,
  error: null,
};

export const TrendAnalysisResultStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, trendAnalysisResultService = inject(TrendAnalysisResultService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            trendAnalysisResultService.getAll().pipe(
              tapResponse({
                next: (trendAnalysisResults: TrendAnalysisResult[]) =>
                  patchState(store, { trendAnalysisResults, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewTrendAnalysisResult: rxMethod<CreateTrendAnalysisResult>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            trendAnalysisResultService.create(dto).pipe(
              tapResponse({
                next: (entity: TrendAnalysisResult) =>
                  patchState(store, {
                    trendAnalysisResults: [...store.trendAnalysisResults(), entity],
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

      updateTrendAnalysisResult: rxMethod<{
        id: number;
        dto: UpdateTrendAnalysisResult;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            trendAnalysisResultService.update(id, dto).pipe(
              tapResponse({
                next: (updated: TrendAnalysisResult) =>
                  patchState(store, {
                    trendAnalysisResults: store
                      .trendAnalysisResults()
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

      removeTrendAnalysisResult: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            trendAnalysisResultService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    trendAnalysisResults: store
                      .trendAnalysisResults()
                      .filter((e) => e.id !== id),
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
