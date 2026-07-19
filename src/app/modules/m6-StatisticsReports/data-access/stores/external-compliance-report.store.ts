import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ExternalComplianceReportService } from '../services/external-compliance-report.service';
import type { ExternalComplianceReport, CreateExternalComplianceReport, UpdateExternalComplianceReport } from '../models/external-compliance-report.dto';

interface ExternalComplianceReportState {
  externalComplianceReports: ExternalComplianceReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExternalComplianceReportState = {
  externalComplianceReports: [],
  isLoading: false,
  error: null,
};

export const ExternalComplianceReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, externalComplianceReportService = inject(ExternalComplianceReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            externalComplianceReportService.getAll().pipe(
              tapResponse({
                next: (externalComplianceReports: ExternalComplianceReport[]) =>
                  patchState(store, { externalComplianceReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewExternalComplianceReport: rxMethod<CreateExternalComplianceReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            externalComplianceReportService.create(dto).pipe(
              tapResponse({
                next: (entity: ExternalComplianceReport) =>
                  patchState(store, {
                    externalComplianceReports: [...store.externalComplianceReports(), entity],
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

      updateExternalComplianceReport: rxMethod<{ id: number; dto: UpdateExternalComplianceReport }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            externalComplianceReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: ExternalComplianceReport) =>
                  patchState(store, {
                    externalComplianceReports: store
                      .externalComplianceReports()
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

      removeExternalComplianceReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            externalComplianceReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    externalComplianceReports: store.externalComplianceReports().filter((e) => e.id !== id),
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
