import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetLoanTrackingAlertService } from '../services/asset-loan-tracking-alert.service';
import type { AssetLoanTrackingAlert, CreateAssetLoanTrackingAlertRequest, UpdateAssetLoanTrackingAlertRequest } from '../models/asset-loan-tracking-alerts';

interface AssetLoanTrackingAlertState {
  assetLoanTrackingAlerts: AssetLoanTrackingAlert[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetLoanTrackingAlertState = {
  assetLoanTrackingAlerts: [],
  isLoading: false,
  error: null,
};

export const AssetLoanTrackingAlertStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetLoanTrackingAlertService = inject(AssetLoanTrackingAlertService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetLoanTrackingAlertService.getAll().pipe(
              tapResponse({
                next: (assetLoanTrackingAlerts: AssetLoanTrackingAlert[]) =>
                  patchState(store, { assetLoanTrackingAlerts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByLoanId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((loanId) =>
            assetLoanTrackingAlertService.getByLoanId(loanId).pipe(
              tapResponse({
                next: (assetLoanTrackingAlerts: AssetLoanTrackingAlert[]) =>
                  patchState(store, { assetLoanTrackingAlerts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetLoanTrackingAlert: rxMethod<CreateAssetLoanTrackingAlertRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetLoanTrackingAlertService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetLoanTrackingAlert) =>
                  patchState(store, {
                    assetLoanTrackingAlerts: [...store.assetLoanTrackingAlerts(), entity],
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

      updateAssetLoanTrackingAlert: rxMethod<{ id: number; dto: UpdateAssetLoanTrackingAlertRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetLoanTrackingAlertService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetLoanTrackingAlert) =>
                  patchState(store, {
                    assetLoanTrackingAlerts: store
                      .assetLoanTrackingAlerts()
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

      removeAssetLoanTrackingAlert: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetLoanTrackingAlertService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetLoanTrackingAlerts: store.assetLoanTrackingAlerts().filter((e) => e.id !== id),
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
