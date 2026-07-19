import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeePerformanceReview, CreateEmployeePerformanceReview, UpdateEmployeePerformanceReview } from '../models/employee-performance-review.types';
import { EmployeePerformanceReviewService } from '../services/employee-performance-review.service';

interface EmployeePerformanceReviewState {
  employeePerformanceReviews: EmployeePerformanceReview[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeePerformanceReviewState = {
  employeePerformanceReviews: [],
  isLoading: false,
  error: null,
};

export const EmployeePerformanceReviewStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeePerformanceReviewService = inject(EmployeePerformanceReviewService)) => ({
    loadAllEmployeePerformanceReviews: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeePerformanceReviewService.getAll().pipe(
            tapResponse({
              next: (employeePerformanceReviews) => patchState(store, { employeePerformanceReviews, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeePerformanceReview: rxMethod<CreateEmployeePerformanceReview>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeePerformanceReviewService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeePerformanceReviews: [...store.employeePerformanceReviews(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeePerformanceReview: rxMethod<{ id: number; dto: UpdateEmployeePerformanceReview }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeePerformanceReviewService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeePerformanceReviews: store.employeePerformanceReviews().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeePerformanceReview: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeePerformanceReviewService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeePerformanceReviews: store.employeePerformanceReviews().filter((e) => (e as { id: number }).id !== id),
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
