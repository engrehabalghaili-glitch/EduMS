import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SubmittedStatisticsService } from '../services/submitted-statistics.service';
import type {
  SubmittedStatistics,
  CreateSubmittedStatistics,
  UpdateSubmittedStatistics,
} from '../models/submitted-statistics.dto';

interface SubmittedStatisticsState {
  submittedStatistics: SubmittedStatistics[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SubmittedStatisticsState = {
  submittedStatistics: [],
  isLoading: false,
  error: null,
};

export const SubmittedStatisticsStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, submittedStatisticsService = inject(SubmittedStatisticsService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            submittedStatisticsService.getAll().pipe(
              tapResponse({
                next: (submittedStatistics: SubmittedStatistics[]) =>
                  patchState(store, { submittedStatistics, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSubmittedStatistics: rxMethod<CreateSubmittedStatistics>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            submittedStatisticsService.create(dto).pipe(
              tapResponse({
                next: (entity: SubmittedStatistics) =>
                  patchState(store, {
                    submittedStatistics: [...store.submittedStatistics(), entity],
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

      updateSubmittedStatistics: rxMethod<{
        id: number;
        dto: UpdateSubmittedStatistics;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            submittedStatisticsService.update(id, dto).pipe(
              tapResponse({
                next: (updated: SubmittedStatistics) =>
                  patchState(store, {
                    submittedStatistics: store
                      .submittedStatistics()
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

      removeSubmittedStatistics: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            submittedStatisticsService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    submittedStatistics: store
                      .submittedStatistics()
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
