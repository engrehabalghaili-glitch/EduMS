import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StatisticalReportSnapshotService } from '../services/statistical-report-snapshot.service';
import type {
  StatisticalReportSnapshot,
  CreateStatisticalReportSnapshot,
  UpdateStatisticalReportSnapshot,
} from '../models/statistical-report-snapshot.dto';

interface StatisticalReportSnapshotState {
  statisticalReportSnapshots: StatisticalReportSnapshot[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StatisticalReportSnapshotState = {
  statisticalReportSnapshots: [],
  isLoading: false,
  error: null,
};

export const StatisticalReportSnapshotStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, statisticalReportSnapshotService = inject(StatisticalReportSnapshotService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            statisticalReportSnapshotService.getAll().pipe(
              tapResponse({
                next: (statisticalReportSnapshots: StatisticalReportSnapshot[]) =>
                  patchState(store, { statisticalReportSnapshots, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStatisticalReportSnapshot: rxMethod<CreateStatisticalReportSnapshot>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            statisticalReportSnapshotService.create(dto).pipe(
              tapResponse({
                next: (entity: StatisticalReportSnapshot) =>
                  patchState(store, {
                    statisticalReportSnapshots: [...store.statisticalReportSnapshots(), entity],
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

      updateStatisticalReportSnapshot: rxMethod<{
        id: number;
        dto: UpdateStatisticalReportSnapshot;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            statisticalReportSnapshotService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StatisticalReportSnapshot) =>
                  patchState(store, {
                    statisticalReportSnapshots: store
                      .statisticalReportSnapshots()
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

      removeStatisticalReportSnapshot: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            statisticalReportSnapshotService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    statisticalReportSnapshots: store
                      .statisticalReportSnapshots()
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
