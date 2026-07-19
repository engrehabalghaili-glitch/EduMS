import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SchoolFinancialSummaryReportService } from '../services/school-financial-summary-report.service';
import type { SchoolFinancialSummaryReport, CreateSchoolFinancialSummaryReport, UpdateSchoolFinancialSummaryReport } from '../models/school-financial-summary-report.dto';

interface SchoolFinancialSummaryReportState {
  schoolFinancialSummaryReports: SchoolFinancialSummaryReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolFinancialSummaryReportState = {
  schoolFinancialSummaryReports: [],
  isLoading: false,
  error: null,
};

export const SchoolFinancialSummaryReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, schoolFinancialSummaryReportService = inject(SchoolFinancialSummaryReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            schoolFinancialSummaryReportService.getAll().pipe(
              tapResponse({
                next: (schoolFinancialSummaryReports: SchoolFinancialSummaryReport[]) =>
                  patchState(store, { schoolFinancialSummaryReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSchoolFinancialSummaryReport: rxMethod<CreateSchoolFinancialSummaryReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            schoolFinancialSummaryReportService.create(dto).pipe(
              tapResponse({
                next: (entity: SchoolFinancialSummaryReport) =>
                  patchState(store, {
                    schoolFinancialSummaryReports: [...store.schoolFinancialSummaryReports(), entity],
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

      updateSchoolFinancialSummaryReport: rxMethod<{ id: number; dto: UpdateSchoolFinancialSummaryReport }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            schoolFinancialSummaryReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: SchoolFinancialSummaryReport) =>
                  patchState(store, {
                    schoolFinancialSummaryReports: store
                      .schoolFinancialSummaryReports()
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

      removeSchoolFinancialSummaryReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            schoolFinancialSummaryReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    schoolFinancialSummaryReports: store.schoolFinancialSummaryReports().filter((e) => e.id !== id),
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
