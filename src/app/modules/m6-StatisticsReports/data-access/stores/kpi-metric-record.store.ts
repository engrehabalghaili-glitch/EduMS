import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { KpiMetricRecordService } from '../services/kpi-metric-record.service';
import type { KpiMetricRecord, CreateKpiMetricRecord, UpdateKpiMetricRecord } from '../models/kpi-metric-record.dto';

interface KpiMetricRecordState {
  kpiMetricRecords: KpiMetricRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: KpiMetricRecordState = {
  kpiMetricRecords: [],
  isLoading: false,
  error: null,
};

export const KpiMetricRecordStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, kpiMetricRecordService = inject(KpiMetricRecordService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            kpiMetricRecordService.getAll().pipe(
              tapResponse({
                next: (kpiMetricRecords: KpiMetricRecord[]) =>
                  patchState(store, { kpiMetricRecords, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewKpiMetricRecord: rxMethod<CreateKpiMetricRecord>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            kpiMetricRecordService.create(dto).pipe(
              tapResponse({
                next: (entity: KpiMetricRecord) =>
                  patchState(store, {
                    kpiMetricRecords: [...store.kpiMetricRecords(), entity],
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

      updateKpiMetricRecord: rxMethod<{ id: number; dto: UpdateKpiMetricRecord }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            kpiMetricRecordService.update(id, dto).pipe(
              tapResponse({
                next: (updated: KpiMetricRecord) =>
                  patchState(store, {
                    kpiMetricRecords: store
                      .kpiMetricRecords()
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

      removeKpiMetricRecord: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            kpiMetricRecordService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    kpiMetricRecords: store.kpiMetricRecords().filter((e) => e.id !== id),
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
