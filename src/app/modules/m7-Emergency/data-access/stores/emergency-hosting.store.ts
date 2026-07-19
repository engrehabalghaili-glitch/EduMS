import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmergencyHosting, CreateEmergencyHosting, UpdateEmergencyHosting } from '../models/emergency-hosting.types';
import { EmergencyHostingService } from '../services/emergency-hosting.service';

interface EmergencyHostingState {
  emergencyHostings: EmergencyHosting[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmergencyHostingState = {
  emergencyHostings: [],
  isLoading: false,
  error: null,
};

export const EmergencyHostingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, emergencyHostingService = inject(EmergencyHostingService)) => ({
    loadAllEmergencyHostings: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          emergencyHostingService.getAll().pipe(
            tapResponse({
              next: (emergencyHostings) => patchState(store, { emergencyHostings, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmergencyHosting: rxMethod<CreateEmergencyHosting>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          emergencyHostingService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { emergencyHostings: [...store.emergencyHostings(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmergencyHosting: rxMethod<{ id: number; dto: UpdateEmergencyHosting }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          emergencyHostingService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                emergencyHostings: store.emergencyHostings().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmergencyHosting: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          emergencyHostingService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                emergencyHostings: store.emergencyHostings().filter((e) => (e as { id: number }).id !== id),
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
