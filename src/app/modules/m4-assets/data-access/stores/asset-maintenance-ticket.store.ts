import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetMaintenanceTicketService } from '../services/asset-maintenance-ticket.service';
import type { AssetMaintenanceTicket, CreateAssetMaintenanceTicketRequest, UpdateAssetMaintenanceTicketRequest } from '../models/asset-maintenance-tickets';

interface AssetMaintenanceTicketState {
  assetMaintenanceTickets: AssetMaintenanceTicket[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetMaintenanceTicketState = {
  assetMaintenanceTickets: [],
  isLoading: false,
  error: null,
};

export const AssetMaintenanceTicketStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetMaintenanceTicketService = inject(AssetMaintenanceTicketService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetMaintenanceTicketService.getAll().pipe(
              tapResponse({
                next: (assetMaintenanceTickets: AssetMaintenanceTicket[]) =>
                  patchState(store, { assetMaintenanceTickets, isLoading: false }),
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
            assetMaintenanceTicketService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetMaintenanceTickets: AssetMaintenanceTicket[]) =>
                  patchState(store, { assetMaintenanceTickets, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetMaintenanceTicket: rxMethod<CreateAssetMaintenanceTicketRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetMaintenanceTicketService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetMaintenanceTicket) =>
                  patchState(store, {
                    assetMaintenanceTickets: [...store.assetMaintenanceTickets(), entity],
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

      updateAssetMaintenanceTicket: rxMethod<{ id: number; dto: UpdateAssetMaintenanceTicketRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetMaintenanceTicketService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetMaintenanceTicket) =>
                  patchState(store, {
                    assetMaintenanceTickets: store
                      .assetMaintenanceTickets()
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

      removeAssetMaintenanceTicket: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetMaintenanceTicketService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetMaintenanceTickets: store.assetMaintenanceTickets().filter((e) => e.id !== id),
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
