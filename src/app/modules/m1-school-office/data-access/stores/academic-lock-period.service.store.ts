import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { AcademicLockPeriod, CreateAcademicLockPeriodDto, UpdateAcademicLockPeriodDto } from '../models/academic-lock-period';
import { AcademicLockPeriodService } from '../services/academic-lock-period.service';

interface AcademicLockPeriodState {
  academicLockPeriods: AcademicLockPeriod[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AcademicLockPeriodState = {
  academicLockPeriods: [],
  isLoading: false,
  error: null,
};

export const AcademicLockPeriodStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, academicLockPeriodService = inject(AcademicLockPeriodService)) => ({
    loadAllAcademicLockPeriods: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          academicLockPeriodService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { academicLockPeriods: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewAcademicLockPeriod: rxMethod<CreateAcademicLockPeriodDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          academicLockPeriodService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { academicLockPeriods: [...store.academicLockPeriods(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
