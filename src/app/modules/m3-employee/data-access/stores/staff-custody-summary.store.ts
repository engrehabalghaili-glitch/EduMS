import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { StaffCustodySummary, CreateStaffCustodySummary, UpdateStaffCustodySummary } from '../models/staff-custody-summary.types';
import { StaffCustodySummaryService } from '../services/staff-custody-summary.service';

interface StaffCustodySummaryState {
  staffCustodySummaries: StaffCustodySummary[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StaffCustodySummaryState = {
  staffCustodySummaries: [],
  isLoading: false,
  error: null,
};

export const StaffCustodySummaryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, staffCustodySummaryService = inject(StaffCustodySummaryService)) => ({
    loadAllStaffCustodySummaries: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          staffCustodySummaryService.getAll().pipe(
            tapResponse({
              next: (staffCustodySummaries) => patchState(store, { staffCustodySummaries, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewStaffCustodySummary: rxMethod<CreateStaffCustodySummary>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          staffCustodySummaryService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { staffCustodySummaries: [...store.staffCustodySummaries(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateStaffCustodySummary: rxMethod<{ id: number; dto: UpdateStaffCustodySummary }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          staffCustodySummaryService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                staffCustodySummaries: store.staffCustodySummaries().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteStaffCustodySummary: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          staffCustodySummaryService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                staffCustodySummaries: store.staffCustodySummaries().filter((e) => (e as { id: number }).id !== id),
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
