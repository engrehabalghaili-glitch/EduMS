import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StatisticsReportsArchiveService } from '../services/statistics-reports-archive.service';
import type {
  StatisticsReportsArchive,
  CreateStatisticsReportsArchive,
  UpdateStatisticsReportsArchive,
} from '../models/statistics-reports-archive.dto';

interface StatisticsReportsArchiveState {
  statisticsReportsArchives: StatisticsReportsArchive[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StatisticsReportsArchiveState = {
  statisticsReportsArchives: [],
  isLoading: false,
  error: null,
};

export const StatisticsReportsArchiveStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, statisticsReportsArchiveService = inject(StatisticsReportsArchiveService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            statisticsReportsArchiveService.getAll().pipe(
              tapResponse({
                next: (statisticsReportsArchives: StatisticsReportsArchive[]) =>
                  patchState(store, { statisticsReportsArchives, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStatisticsReportsArchive: rxMethod<CreateStatisticsReportsArchive>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            statisticsReportsArchiveService.create(dto).pipe(
              tapResponse({
                next: (entity: StatisticsReportsArchive) =>
                  patchState(store, {
                    statisticsReportsArchives: [...store.statisticsReportsArchives(), entity],
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

      updateStatisticsReportsArchive: rxMethod<{
        id: number;
        dto: UpdateStatisticsReportsArchive;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            statisticsReportsArchiveService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StatisticsReportsArchive) =>
                  patchState(store, {
                    statisticsReportsArchives: store
                      .statisticsReportsArchives()
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

      removeStatisticsReportsArchive: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            statisticsReportsArchiveService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    statisticsReportsArchives: store
                      .statisticsReportsArchives()
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
