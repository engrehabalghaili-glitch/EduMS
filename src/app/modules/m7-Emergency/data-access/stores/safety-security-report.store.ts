import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SafetySecurityReport, CreateSafetySecurityReport, UpdateSafetySecurityReport } from '../models/safety-security-report.types';
import { SafetySecurityReportService } from '../services/safety-security-report.service';

interface SafetySecurityReportState {
  safetySecurityReports: SafetySecurityReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SafetySecurityReportState = {
  safetySecurityReports: [],
  isLoading: false,
  error: null,
};

export const SafetySecurityReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, safetySecurityReportService = inject(SafetySecurityReportService)) => ({
    loadAllSafetySecurityReports: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          safetySecurityReportService.getAll().pipe(
            tapResponse({
              next: (safetySecurityReports) => patchState(store, { safetySecurityReports, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSafetySecurityReport: rxMethod<CreateSafetySecurityReport>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          safetySecurityReportService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { safetySecurityReports: [...store.safetySecurityReports(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSafetySecurityReport: rxMethod<{ id: number; dto: UpdateSafetySecurityReport }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          safetySecurityReportService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                safetySecurityReports: store.safetySecurityReports().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSafetySecurityReport: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          safetySecurityReportService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                safetySecurityReports: store.safetySecurityReports().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
