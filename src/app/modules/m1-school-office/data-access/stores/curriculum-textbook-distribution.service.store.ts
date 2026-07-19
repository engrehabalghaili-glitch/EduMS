import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { CurriculumTextbookDistribution, CreateCurriculumTextbookDistributionDto, UpdateCurriculumTextbookDistributionDto } from '../models/curriculum-textbook-distribution';
import { CurriculumTextbookDistributionService } from '../services/curriculum-textbook-distribution.service';

interface CurriculumTextbookDistributionState {
  curriculumTextbookDistributions: CurriculumTextbookDistribution[];
  isLoading: boolean;
  error: string | null;
}

const initialState: CurriculumTextbookDistributionState = {
  curriculumTextbookDistributions: [],
  isLoading: false,
  error: null,
};

export const CurriculumTextbookDistributionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, curriculumTextbookDistributionService = inject(CurriculumTextbookDistributionService)) => ({
    loadAllCurriculumTextbookDistributions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          curriculumTextbookDistributionService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { curriculumTextbookDistributions: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewCurriculumTextbookDistribution: rxMethod<CreateCurriculumTextbookDistributionDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          curriculumTextbookDistributionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { curriculumTextbookDistributions: [...store.curriculumTextbookDistributions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
