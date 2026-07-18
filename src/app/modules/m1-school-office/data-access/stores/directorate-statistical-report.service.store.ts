import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { DirectorateStatisticalReport, CreateDirectorateStatisticalReportDto, UpdateDirectorateStatisticalReportDto } from '../models/directorate-statistical-report';
import { DirectorateStatisticalReportService } from '../services/directorate-statistical-report.service';

interface DirectorateStatisticalReportState {
  directorateStatisticalReports: DirectorateStatisticalReport[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DirectorateStatisticalReportState = {
  directorateStatisticalReports: [],
  isLoading: false,
  error: null,
};

export const DirectorateStatisticalReportStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, directorateStatisticalReportService = inject(DirectorateStatisticalReportService)) => ({
    loadAllDirectorateStatisticalReports: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          directorateStatisticalReportService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { directorateStatisticalReports: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewDirectorateStatisticalReport: rxMethod<CreateDirectorateStatisticalReportDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          directorateStatisticalReportService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { directorateStatisticalReports: [...store.directorateStatisticalReports(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
