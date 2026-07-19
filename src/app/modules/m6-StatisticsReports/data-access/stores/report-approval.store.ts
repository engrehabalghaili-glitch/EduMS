import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ReportApprovalService } from '../services/report-approval.service';
import type { ReportApproval, CreateReportApproval, UpdateReportApproval } from '../models/report-approval.dto';

interface ReportApprovalState {
  reportApprovals: ReportApproval[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ReportApprovalState = {
  reportApprovals: [],
  isLoading: false,
  error: null,
};

export const ReportApprovalStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, reportApprovalService = inject(ReportApprovalService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            reportApprovalService.getAll().pipe(
              tapResponse({
                next: (reportApprovals: ReportApproval[]) =>
                  patchState(store, { reportApprovals, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewReportApproval: rxMethod<CreateReportApproval>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            reportApprovalService.create(dto).pipe(
              tapResponse({
                next: (entity: ReportApproval) =>
                  patchState(store, {
                    reportApprovals: [...store.reportApprovals(), entity],
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

      updateReportApproval: rxMethod<{ id: number; dto: UpdateReportApproval }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            reportApprovalService.update(id, dto).pipe(
              tapResponse({
                next: (updated: ReportApproval) =>
                  patchState(store, {
                    reportApprovals: store
                      .reportApprovals()
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

      removeReportApproval: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            reportApprovalService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    reportApprovals: store.reportApprovals().filter((e) => e.id !== id),
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
