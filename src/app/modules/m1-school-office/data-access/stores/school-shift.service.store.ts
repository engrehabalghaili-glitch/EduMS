import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolShift, CreateSchoolShiftDto, UpdateSchoolShiftDto } from '../models/school-shift';
import { SchoolShiftService } from '../services/school-shift.service';

interface SchoolShiftState {
  schoolShifts: SchoolShift[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolShiftState = {
  schoolShifts: [],
  isLoading: false,
  error: null,
};

export const SchoolShiftStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolShiftService = inject(SchoolShiftService)) => ({
    loadAllSchoolShifts: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolShiftService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolShifts: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolShift: rxMethod<CreateSchoolShiftDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolShiftService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolShifts: [...store.schoolShifts(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
