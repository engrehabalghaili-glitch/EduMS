import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { MaintenanceSparePartService } from '../services/maintenance-spare-part.service';
import type { MaintenanceSparePart, CreateMaintenanceSparePartRequest, UpdateMaintenanceSparePartRequest } from '../models/maintenance-spare-parts';

interface MaintenanceSparePartState {
  maintenanceSpareParts: MaintenanceSparePart[];
  isLoading: boolean;
  error: string | null;
}

const initialState: MaintenanceSparePartState = {
  maintenanceSpareParts: [],
  isLoading: false,
  error: null,
};

export const MaintenanceSparePartStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, maintenanceSparePartService = inject(MaintenanceSparePartService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            maintenanceSparePartService.getAll().pipe(
              tapResponse({
                next: (maintenanceSpareParts: MaintenanceSparePart[]) =>
                  patchState(store, { maintenanceSpareParts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            maintenanceSparePartService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (maintenanceSpareParts: MaintenanceSparePart[]) =>
                  patchState(store, { maintenanceSpareParts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewMaintenanceSparePart: rxMethod<CreateMaintenanceSparePartRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            maintenanceSparePartService.create(dto).pipe(
              tapResponse({
                next: (entity: MaintenanceSparePart) =>
                  patchState(store, {
                    maintenanceSpareParts: [...store.maintenanceSpareParts(), entity],
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

      updateMaintenanceSparePart: rxMethod<{ id: number; dto: UpdateMaintenanceSparePartRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            maintenanceSparePartService.update(id, dto).pipe(
              tapResponse({
                next: (updated: MaintenanceSparePart) =>
                  patchState(store, {
                    maintenanceSpareParts: store
                      .maintenanceSpareParts()
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

      removeMaintenanceSparePart: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            maintenanceSparePartService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    maintenanceSpareParts: store.maintenanceSpareParts().filter((e) => e.id !== id),
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