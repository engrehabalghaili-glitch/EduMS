import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { GradingScaleBound, CreateGradingScaleBoundDto, UpdateGradingScaleBoundDto } from '../models/grading-scale-bound';
import { GradingScaleBoundService } from '../services/grading-scale-bound.service';

interface GradingScaleBoundState {
  gradingScaleBounds: GradingScaleBound[];
  isLoading: boolean;
  error: string | null;
}

const initialState: GradingScaleBoundState = {
  gradingScaleBounds: [],
  isLoading: false,
  error: null,
};

export const GradingScaleBoundStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, gradingScaleBoundService = inject(GradingScaleBoundService)) => ({
    loadAllGradingScaleBounds: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          gradingScaleBoundService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { gradingScaleBounds: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewGradingScaleBound: rxMethod<CreateGradingScaleBoundDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          gradingScaleBoundService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { gradingScaleBounds: [...store.gradingScaleBounds(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
