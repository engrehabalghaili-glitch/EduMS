import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EducationalStage, CreateEducationalStageDto, UpdateEducationalStageDto } from '../models/educational-stage';
import { EducationalStageService } from '../services/educational-stage.service';

interface EducationalStageState {
  educationalStages: EducationalStage[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EducationalStageState = {
  educationalStages: [],
  isLoading: false,
  error: null,
};

export const EducationalStageStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, educationalStageService = inject(EducationalStageService)) => ({
    loadAllEducationalStages: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          educationalStageService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { educationalStages: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEducationalStage: rxMethod<CreateEducationalStageDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          educationalStageService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { educationalStages: [...store.educationalStages(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
