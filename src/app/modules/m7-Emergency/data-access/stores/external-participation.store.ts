import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ExternalParticipation, CreateExternalParticipation, UpdateExternalParticipation } from '../models/external-participation.types';
import { ExternalParticipationService } from '../services/external-participation.service';

interface ExternalParticipationState {
  externalParticipations: ExternalParticipation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExternalParticipationState = {
  externalParticipations: [],
  isLoading: false,
  error: null,
};

export const ExternalParticipationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, externalParticipationService = inject(ExternalParticipationService)) => ({
    loadAllExternalParticipations: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          externalParticipationService.getAll().pipe(
            tapResponse({
              next: (externalParticipations) => patchState(store, { externalParticipations, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewExternalParticipation: rxMethod<CreateExternalParticipation>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          externalParticipationService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { externalParticipations: [...store.externalParticipations(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateExternalParticipation: rxMethod<{ id: number; dto: UpdateExternalParticipation }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          externalParticipationService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                externalParticipations: store.externalParticipations().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteExternalParticipation: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          externalParticipationService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                externalParticipations: store.externalParticipations().filter((e) => (e as { id: number }).id !== id),
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
