import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StatisticsUpdateHistoryService } from '../services/statistics-update-history.service';
import type {
  StatisticsUpdateHistory,
  CreateStatisticsUpdateHistory,
  UpdateStatisticsUpdateHistory,
} from '../models/statistics-update-history.dto';

interface StatisticsUpdateHistoryState {
  statisticsUpdateHistories: StatisticsUpdateHistory[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StatisticsUpdateHistoryState = {
  statisticsUpdateHistories: [],
  isLoading: false,
  error: null,
};

export const StatisticsUpdateHistoryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, statisticsUpdateHistoryService = inject(StatisticsUpdateHistoryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            statisticsUpdateHistoryService.getAll().pipe(
              tapResponse({
                next: (statisticsUpdateHistories: StatisticsUpdateHistory[]) =>
                  patchState(store, { statisticsUpdateHistories, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStatisticsUpdateHistory: rxMethod<CreateStatisticsUpdateHistory>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            statisticsUpdateHistoryService.create(dto).pipe(
              tapResponse({
                next: (entity: StatisticsUpdateHistory) =>
                  patchState(store, {
                    statisticsUpdateHistories: [...store.statisticsUpdateHistories(), entity],
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

      updateStatisticsUpdateHistory: rxMethod<{
        id: number;
        dto: UpdateStatisticsUpdateHistory;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            statisticsUpdateHistoryService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StatisticsUpdateHistory) =>
                  patchState(store, {
                    statisticsUpdateHistories: store
                      .statisticsUpdateHistories()
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

      removeStatisticsUpdateHistory: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            statisticsUpdateHistoryService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    statisticsUpdateHistories: store
                      .statisticsUpdateHistories()
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
