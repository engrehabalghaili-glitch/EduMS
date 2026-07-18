import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { TrainingCourseOffering, CreateTrainingCourseOfferingDto, UpdateTrainingCourseOfferingDto } from '../models/training-course-offering';
import { TrainingCourseOfferingService } from '../services/training-course-offering.service';

interface TrainingCourseOfferingState {
  trainingCourseOfferings: TrainingCourseOffering[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TrainingCourseOfferingState = {
  trainingCourseOfferings: [],
  isLoading: false,
  error: null,
};

export const TrainingCourseOfferingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, trainingCourseOfferingService = inject(TrainingCourseOfferingService)) => ({
    loadAllTrainingCourseOfferings: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          trainingCourseOfferingService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { trainingCourseOfferings: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewTrainingCourseOffering: rxMethod<CreateTrainingCourseOfferingDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          trainingCourseOfferingService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { trainingCourseOfferings: [...store.trainingCourseOfferings(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
