import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { VacantPosition, CreateVacantPosition, UpdateVacantPosition } from '../models/vacant-position.types';
import { VacantPositionService } from '../services/vacant-position.service';

interface VacantPositionState {
  vacantPositions: VacantPosition[];
  isLoading: boolean;
  error: string | null;
}

const initialState: VacantPositionState = {
  vacantPositions: [],
  isLoading: false,
  error: null,
};

export const VacantPositionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, vacantPositionService = inject(VacantPositionService)) => ({
    loadAllVacantPositions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          vacantPositionService.getAll().pipe(
            tapResponse({
              next: (vacantPositions) => patchState(store, { vacantPositions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewVacantPosition: rxMethod<CreateVacantPosition>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          vacantPositionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { vacantPositions: [...store.vacantPositions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateVacantPosition: rxMethod<{ id: number; dto: UpdateVacantPosition }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          vacantPositionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                vacantPositions: store.vacantPositions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteVacantPosition: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          vacantPositionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                vacantPositions: store.vacantPositions().filter((e) => (e as { id: number }).id !== id),
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
