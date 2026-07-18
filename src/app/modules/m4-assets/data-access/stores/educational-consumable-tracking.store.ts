import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { EducationalConsumableTrackingService } from '../services/educational-consumable-tracking.service';
import type {
  EducationalConsumableTracking,
  CreateEducationalConsumableTrackingRequest,
  UpdateEducationalConsumableTrackingRequest,
} from '../models/educational-consumable-trackings';

interface EducationalConsumableTrackingState {
  educationalConsumableTrackings: EducationalConsumableTracking[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EducationalConsumableTrackingState = {
  educationalConsumableTrackings: [],
  isLoading: false,
  error: null,
};

export const EducationalConsumableTrackingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, educationalConsumableTrackingService = inject(EducationalConsumableTrackingService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            educationalConsumableTrackingService.getAll().pipe(
              tapResponse({
                next: (educationalConsumableTrackings: EducationalConsumableTracking[]) =>
                  patchState(store, { educationalConsumableTrackings, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            educationalConsumableTrackingService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (educationalConsumableTrackings: EducationalConsumableTracking[]) =>
                  patchState(store, { educationalConsumableTrackings, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewEducationalConsumableTracking: rxMethod<CreateEducationalConsumableTrackingRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            educationalConsumableTrackingService.create(dto).pipe(
              tapResponse({
                next: (entity: EducationalConsumableTracking) =>
                  patchState(store, {
                    educationalConsumableTrackings: [
                      ...store.educationalConsumableTrackings(),
                      entity,
                    ],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateEducationalConsumableTracking: rxMethod<{
        id: number;
        dto: UpdateEducationalConsumableTrackingRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            educationalConsumableTrackingService.update(id, dto).pipe(
              tapResponse({
                next: (updated: EducationalConsumableTracking) =>
                  patchState(store, {
                    educationalConsumableTrackings: store
                      .educationalConsumableTrackings()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeEducationalConsumableTracking: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            educationalConsumableTrackingService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    educationalConsumableTrackings: store
                      .educationalConsumableTrackings()
                      .filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
