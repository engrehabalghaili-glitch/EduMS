import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { TransportationService, CreateTransportationService, UpdateTransportationService } from '../models/transportation-service.types';
import { TransportationServiceService } from '../services/transportation-service.service';

interface TransportationServiceState {
  transportationServices: TransportationService[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TransportationServiceState = {
  transportationServices: [],
  isLoading: false,
  error: null,
};

export const TransportationServiceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, transportationServiceService = inject(TransportationServiceService)) => ({
    loadAllTransportationServices: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          transportationServiceService.getAll().pipe(
            tapResponse({
              next: (transportationServices) => patchState(store, { transportationServices, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewTransportationService: rxMethod<CreateTransportationService>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          transportationServiceService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { transportationServices: [...store.transportationServices(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateTransportationService: rxMethod<{ id: number; dto: UpdateTransportationService }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          transportationServiceService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                transportationServices: store.transportationServices().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteTransportationService: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          transportationServiceService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                transportationServices: store.transportationServices().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
