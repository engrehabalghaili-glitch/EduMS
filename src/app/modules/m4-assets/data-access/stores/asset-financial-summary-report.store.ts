import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetFinancialSummaryReportService } from '../services/asset-financial-summary-report.service';
import type { AssetFinancialSummaryReport, CreateAssetFinancialSummaryReportRequest, UpdateAssetFinancialSummaryReportRequest } from '../models/asset-financial-summary-reports';

interface AssetFinancialSummaryReportState {
  assetFinancialSummaryReports: AssetFinancialSummaryReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetFinancialSummaryReportState = {
  assetFinancialSummaryReports: [],
  isLoading: false,
  error: null,
};

export const AssetFinancialSummaryReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetFinancialSummaryReportService = inject(AssetFinancialSummaryReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetFinancialSummaryReportService.getAll().pipe(
              tapResponse({
                next: (assetFinancialSummaryReports: AssetFinancialSummaryReport[]) =>
                  patchState(store, { assetFinancialSummaryReports, isLoading: false }),
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
            assetFinancialSummaryReportService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetFinancialSummaryReports: AssetFinancialSummaryReport[]) =>
                  patchState(store, { assetFinancialSummaryReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetFinancialSummaryReport: rxMethod<CreateAssetFinancialSummaryReportRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetFinancialSummaryReportService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetFinancialSummaryReport) =>
                  patchState(store, {
                    assetFinancialSummaryReports: [...store.assetFinancialSummaryReports(), entity],
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

      updateAssetFinancialSummaryReport: rxMethod<{ id: number; dto: UpdateAssetFinancialSummaryReportRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetFinancialSummaryReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetFinancialSummaryReport) =>
                  patchState(store, {
                    assetFinancialSummaryReports: store
                      .assetFinancialSummaryReports()
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

      removeAssetFinancialSummaryReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetFinancialSummaryReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetFinancialSummaryReports: store.assetFinancialSummaryReports().filter((e) => e.id !== id),
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
