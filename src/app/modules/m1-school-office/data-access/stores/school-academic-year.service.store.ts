import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolAcademicYear, CreateSchoolAcademicYearDto, UpdateSchoolAcademicYearDto } from '../models/school-academic-year';
import { SchoolAcademicYearService } from '../services/school-academic-year.service';

interface SchoolAcademicYearState {
  schoolAcademicYears: SchoolAcademicYear[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAcademicYearState = {
  schoolAcademicYears: [],
  isLoading: false,
  error: null,
};

export const SchoolAcademicYearStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolAcademicYearService = inject(SchoolAcademicYearService)) => ({
    loadAllSchoolAcademicYears: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolAcademicYearService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolAcademicYears: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolAcademicYear: rxMethod<CreateSchoolAcademicYearDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolAcademicYearService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolAcademicYears: [...store.schoolAcademicYears(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
