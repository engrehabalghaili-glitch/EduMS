import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ExceptionalStatisticsReportService } from '../services/exceptional-statistics-report.service';
import type { ExceptionalStatisticsReport, CreateExceptionalStatisticsReport, UpdateExceptionalStatisticsReport } from '../models/exceptional-statistics-report.dto';

interface ExceptionalStatisticsReportState {
  exceptionalStatisticsReports: ExceptionalStatisticsReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExceptionalStatisticsReportState = {
  exceptionalStatisticsReports: [],
  isLoading: false,
  error: null,
};

export const ExceptionalStatisticsReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, exceptionalStatisticsReportService = inject(ExceptionalStatisticsReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            exceptionalStatisticsReportService.getAll().pipe(
              tapResponse({
                next: (exceptionalStatisticsReports: ExceptionalStatisticsReport[]) =>
                  patchState(store, { exceptionalStatisticsReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewExceptionalStatisticsReport: rxMethod<CreateExceptionalStatisticsReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            exceptionalStatisticsReportService.create(dto).pipe(
              tapResponse({
                next: (entity: ExceptionalStatisticsReport) =>
                  patchState(store, {
                    exceptionalStatisticsReports: [...store.exceptionalStatisticsReports(), entity],
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

      updateExceptionalStatisticsReport: rxMethod<{ id: number; dto: UpdateExceptionalStatisticsReport }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            exceptionalStatisticsReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: ExceptionalStatisticsReport) =>
                  patchState(store, {
                    exceptionalStatisticsReports: store
                      .exceptionalStatisticsReports()
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

      removeExceptionalStatisticsReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            exceptionalStatisticsReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    exceptionalStatisticsReports: store.exceptionalStatisticsReports().filter((e) => e.id !== id),
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
