import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ComparativeReportService } from '../services/comparative-report.service';
import type { ComparativeReport, CreateComparativeReport, UpdateComparativeReport } from '../models/comparative-report.dto';

interface ComparativeReportState {
  comparativeReports: ComparativeReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ComparativeReportState = {
  comparativeReports: [],
  isLoading: false,
  error: null,
};

export const ComparativeReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, comparativeReportService = inject(ComparativeReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            comparativeReportService.getAll().pipe(
              tapResponse({
                next: (comparativeReports: ComparativeReport[]) =>
                  patchState(store, { comparativeReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewComparativeReport: rxMethod<CreateComparativeReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            comparativeReportService.create(dto).pipe(
              tapResponse({
                next: (entity: ComparativeReport) =>
                  patchState(store, {
                    comparativeReports: [...store.comparativeReports(), entity],
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

      updateComparativeReport: rxMethod<{ id: number; dto: UpdateComparativeReport }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            comparativeReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: ComparativeReport) =>
                  patchState(store, {
                    comparativeReports: store
                      .comparativeReports()
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

      removeComparativeReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            comparativeReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    comparativeReports: store.comparativeReports().filter((e) => e.id !== id),
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
