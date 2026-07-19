import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StatisticsArchiveService } from '../services/statistics-archive.service';
import type {
  StatisticsArchive,
  CreateStatisticsArchive,
  UpdateStatisticsArchive,
} from '../models/statistics-archive.dto';

interface StatisticsArchiveState {
  statisticsArchives: StatisticsArchive[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StatisticsArchiveState = {
  statisticsArchives: [],
  isLoading: false,
  error: null,
};

export const StatisticsArchiveStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, statisticsArchiveService = inject(StatisticsArchiveService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            statisticsArchiveService.getAll().pipe(
              tapResponse({
                next: (statisticsArchives: StatisticsArchive[]) =>
                  patchState(store, { statisticsArchives, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStatisticsArchive: rxMethod<CreateStatisticsArchive>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            statisticsArchiveService.create(dto).pipe(
              tapResponse({
                next: (entity: StatisticsArchive) =>
                  patchState(store, {
                    statisticsArchives: [...store.statisticsArchives(), entity],
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

      updateStatisticsArchive: rxMethod<{
        id: number;
        dto: UpdateStatisticsArchive;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            statisticsArchiveService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StatisticsArchive) =>
                  patchState(store, {
                    statisticsArchives: store
                      .statisticsArchives()
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

      removeStatisticsArchive: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            statisticsArchiveService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    statisticsArchives: store
                      .statisticsArchives()
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
