import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SystemReportService } from '../services/system-report.service';
import type {
  SystemReport,
  CreateSystemReport,
  UpdateSystemReport,
} from '../models/system-report.dto';

interface SystemReportState {
  systemReports: SystemReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SystemReportState = {
  systemReports: [],
  isLoading: false,
  error: null,
};

export const SystemReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, systemReportService = inject(SystemReportService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            systemReportService.getAll().pipe(
              tapResponse({
                next: (systemReports: SystemReport[]) =>
                  patchState(store, { systemReports, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSystemReport: rxMethod<CreateSystemReport>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            systemReportService.create(dto).pipe(
              tapResponse({
                next: (entity: SystemReport) =>
                  patchState(store, {
                    systemReports: [...store.systemReports(), entity],
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

      updateSystemReport: rxMethod<{
        id: number;
        dto: UpdateSystemReport;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            systemReportService.update(id, dto).pipe(
              tapResponse({
                next: (updated: SystemReport) =>
                  patchState(store, {
                    systemReports: store
                      .systemReports()
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

      removeSystemReport: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            systemReportService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    systemReports: store
                      .systemReports()
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
