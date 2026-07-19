import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { GradeCapacity, CreateGradeCapacityDto, UpdateGradeCapacityDto } from '../models/grade-capacity';
import { GradeCapacityService } from '../services/grade-capacity.service';

interface GradeCapacityState {
  gradeCapacitys: GradeCapacity[];
  isLoading: boolean;
  error: string | null;
}

const initialState: GradeCapacityState = {
  gradeCapacitys: [],
  isLoading: false,
  error: null,
};

export const GradeCapacityStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, gradeCapacityService = inject(GradeCapacityService)) => ({
    loadAllGradeCapacitys: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          gradeCapacityService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { gradeCapacitys: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewGradeCapacity: rxMethod<CreateGradeCapacityDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          gradeCapacityService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { gradeCapacitys: [...store.gradeCapacitys(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
