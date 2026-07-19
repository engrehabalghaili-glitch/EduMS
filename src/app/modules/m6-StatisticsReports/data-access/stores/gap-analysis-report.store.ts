import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { GapAnalysisReportService } from '../services/gap-analysis-report.service';
import type { GapAnalysisReport, CreateGapAnalysisReport, UpdateGapAnalysisReport } from '../models/gap-analysis-report.dto';

interface GapAnalysisReportState {
  gapAnalysisReports: GapAnalysisReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: GapAnalysisReportState = {
  gapAnalysisReports: [],
  isLoading: false,
  error: null,
};

export const GapAnalysisReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, gapAnalysisReportService = inject(GapAnalysisReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            gapAnalysisReportService.getAll().pipe(
              tapResponse({
                next: (gapAnalysisReports: GapAnalysisReport[]) =>
                  patchState(store, { gapAnalysisReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewGapAnalysisReport: rxMethod<CreateGapAnalysisReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            gapAnalysisReportService.create(dto).pipe(
              tapResponse({
                next: (entity: GapAnalysisReport) =>
                  patchState(store, {
                    gapAnalysisReports: [...store.gapAnalysisReports(), entity],
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

      updateGapAnalysisReport: rxMethod<{ id: number; dto: UpdateGapAnalysisReport }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            gapAnalysisReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: GapAnalysisReport) =>
                  patchState(store, {
                    gapAnalysisReports: store
                      .gapAnalysisReports()
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

      removeGapAnalysisReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            gapAnalysisReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    gapAnalysisReports: store.gapAnalysisReports().filter((e) => e.id !== id),
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
