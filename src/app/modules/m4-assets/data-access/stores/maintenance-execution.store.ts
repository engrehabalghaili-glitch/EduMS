import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { MaintenanceExecutionService } from '../services/maintenance-execution.service';
import type { MaintenanceExecution, CreateMaintenanceExecutionRequest, UpdateMaintenanceExecutionRequest } from '../models/maintenance-executions';

interface MaintenanceExecutionState {
  maintenanceExecutions: MaintenanceExecution[];
  isLoading: boolean;
  error: string | null;
}

const initialState: MaintenanceExecutionState = {
  maintenanceExecutions: [],
  isLoading: false,
  error: null,
};

export const MaintenanceExecutionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, maintenanceExecutionService = inject(MaintenanceExecutionService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            maintenanceExecutionService.getAll().pipe(
              tapResponse({
                next: (maintenanceExecutions: MaintenanceExecution[]) =>
                  patchState(store, { maintenanceExecutions, isLoading: false }),
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
            maintenanceExecutionService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (maintenanceExecutions: MaintenanceExecution[]) =>
                  patchState(store, { maintenanceExecutions, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewMaintenanceExecution: rxMethod<CreateMaintenanceExecutionRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            maintenanceExecutionService.create(dto).pipe(
              tapResponse({
                next: (entity: MaintenanceExecution) =>
                  patchState(store, {
                    maintenanceExecutions: [...store.maintenanceExecutions(), entity],
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

      updateMaintenanceExecution: rxMethod<{ id: number; dto: UpdateMaintenanceExecutionRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            maintenanceExecutionService.update(id, dto).pipe(
              tapResponse({
                next: (updated: MaintenanceExecution) =>
                  patchState(store, {
                    maintenanceExecutions: store
                      .maintenanceExecutions()
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

      removeMaintenanceExecution: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            maintenanceExecutionService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    maintenanceExecutions: store.maintenanceExecutions().filter((e) => e.id !== id),
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