import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { DashboardKpiConfigurationService } from '../services/dashboard-kpi-configuration.service';
import type { DashboardKpiConfiguration, CreateDashboardKpiConfiguration, UpdateDashboardKpiConfiguration } from '../models/dashboard-kpi-configuration.dto';

interface DashboardKpiConfigurationState {
  dashboardKpiConfigurations: DashboardKpiConfiguration[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DashboardKpiConfigurationState = {
  dashboardKpiConfigurations: [],
  isLoading: false,
  error: null,
};

export const DashboardKpiConfigurationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, dashboardKpiConfigurationService = inject(DashboardKpiConfigurationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            dashboardKpiConfigurationService.getAll().pipe(
              tapResponse({
                next: (dashboardKpiConfigurations: DashboardKpiConfiguration[]) =>
                  patchState(store, { dashboardKpiConfigurations, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewDashboardKpiConfiguration: rxMethod<CreateDashboardKpiConfiguration>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            dashboardKpiConfigurationService.create(dto).pipe(
              tapResponse({
                next: (entity: DashboardKpiConfiguration) =>
                  patchState(store, {
                    dashboardKpiConfigurations: [...store.dashboardKpiConfigurations(), entity],
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

      updateDashboardKpiConfiguration: rxMethod<{ id: number; dto: UpdateDashboardKpiConfiguration }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            dashboardKpiConfigurationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: DashboardKpiConfiguration) =>
                  patchState(store, {
                    dashboardKpiConfigurations: store
                      .dashboardKpiConfigurations()
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

      removeDashboardKpiConfiguration: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            dashboardKpiConfigurationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    dashboardKpiConfigurations: store.dashboardKpiConfigurations().filter((e) => e.id !== id),
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
