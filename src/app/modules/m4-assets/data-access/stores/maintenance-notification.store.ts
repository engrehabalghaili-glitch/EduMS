import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { MaintenanceNotificationService } from '../services/maintenance-notification.service';
import type { MaintenanceNotification, CreateMaintenanceNotificationRequest, UpdateMaintenanceNotificationRequest } from '../models/maintenance-notifications';

interface MaintenanceNotificationState {
  maintenanceNotifications: MaintenanceNotification[];
  isLoading: boolean;
  error: string | null;
}

const initialState: MaintenanceNotificationState = {
  maintenanceNotifications: [],
  isLoading: false,
  error: null,
};

export const MaintenanceNotificationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, maintenanceNotificationService = inject(MaintenanceNotificationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            maintenanceNotificationService.getAll().pipe(
              tapResponse({
                next: (maintenanceNotifications: MaintenanceNotification[]) =>
                  patchState(store, { maintenanceNotifications, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByRecipientUserId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((recipientUserId) =>
            maintenanceNotificationService.getByRecipientUserId(recipientUserId).pipe(
              tapResponse({
                next: (maintenanceNotifications: MaintenanceNotification[]) =>
                  patchState(store, { maintenanceNotifications, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewMaintenanceNotification: rxMethod<CreateMaintenanceNotificationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            maintenanceNotificationService.create(dto).pipe(
              tapResponse({
                next: (entity: MaintenanceNotification) =>
                  patchState(store, {
                    maintenanceNotifications: [...store.maintenanceNotifications(), entity],
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

      updateMaintenanceNotification: rxMethod<{ id: number; dto: UpdateMaintenanceNotificationRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            maintenanceNotificationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: MaintenanceNotification) =>
                  patchState(store, {
                    maintenanceNotifications: store
                      .maintenanceNotifications()
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

      removeMaintenanceNotification: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            maintenanceNotificationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    maintenanceNotifications: store.maintenanceNotifications().filter((e) => e.id !== id),
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