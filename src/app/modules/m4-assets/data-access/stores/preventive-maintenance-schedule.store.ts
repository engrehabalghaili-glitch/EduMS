import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { PreventiveMaintenanceScheduleService } from '../services/preventive-maintenance-schedule.service';
import type { PreventiveMaintenanceSchedule, CreatePreventiveMaintenanceScheduleRequest, UpdatePreventiveMaintenanceScheduleRequest } from '../models/preventive-maintenance-schedules';

interface PreventiveMaintenanceScheduleState {
  preventiveMaintenanceSchedules: PreventiveMaintenanceSchedule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PreventiveMaintenanceScheduleState = {
  preventiveMaintenanceSchedules: [],
  isLoading: false,
  error: null,
};

export const PreventiveMaintenanceScheduleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, preventiveMaintenanceScheduleService = inject(PreventiveMaintenanceScheduleService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            preventiveMaintenanceScheduleService.getAll().pipe(
              tapResponse({
                next: (preventiveMaintenanceSchedules: PreventiveMaintenanceSchedule[]) =>
                  patchState(store, { preventiveMaintenanceSchedules, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByAssetId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((assetId) =>
            preventiveMaintenanceScheduleService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (preventiveMaintenanceSchedules: PreventiveMaintenanceSchedule[]) =>
                  patchState(store, { preventiveMaintenanceSchedules, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewPreventiveMaintenanceSchedule: rxMethod<CreatePreventiveMaintenanceScheduleRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            preventiveMaintenanceScheduleService.create(dto).pipe(
              tapResponse({
                next: (entity: PreventiveMaintenanceSchedule) =>
                  patchState(store, {
                    preventiveMaintenanceSchedules: [...store.preventiveMaintenanceSchedules(), entity],
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

      updatePreventiveMaintenanceSchedule: rxMethod<{ id: number; dto: UpdatePreventiveMaintenanceScheduleRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            preventiveMaintenanceScheduleService.update(id, dto).pipe(
              tapResponse({
                next: (updated: PreventiveMaintenanceSchedule) =>
                  patchState(store, {
                    preventiveMaintenanceSchedules: store
                      .preventiveMaintenanceSchedules()
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

      removePreventiveMaintenanceSchedule: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            preventiveMaintenanceScheduleService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    preventiveMaintenanceSchedules: store.preventiveMaintenanceSchedules().filter((e) => e.id !== id),
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