import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmergencyClosure, CreateEmergencyClosure, UpdateEmergencyClosure } from '../models/emergency-closure.types';
import { EmergencyClosureService } from '../services/emergency-closure.service';

interface EmergencyClosureState {
  emergencyClosures: EmergencyClosure[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmergencyClosureState = {
  emergencyClosures: [],
  isLoading: false,
  error: null,
};

export const EmergencyClosureStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, emergencyClosureService = inject(EmergencyClosureService)) => ({
    loadAllEmergencyClosures: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          emergencyClosureService.getAll().pipe(
            tapResponse({
              next: (emergencyClosures) => patchState(store, { emergencyClosures, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmergencyClosure: rxMethod<CreateEmergencyClosure>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          emergencyClosureService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { emergencyClosures: [...store.emergencyClosures(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmergencyClosure: rxMethod<{ id: number; dto: UpdateEmergencyClosure }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          emergencyClosureService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                emergencyClosures: store.emergencyClosures().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmergencyClosure: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          emergencyClosureService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                emergencyClosures: store.emergencyClosures().filter((e) => (e as { id: number }).id !== id),
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
