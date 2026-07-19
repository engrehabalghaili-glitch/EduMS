import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolSemester, CreateSchoolSemesterDto, UpdateSchoolSemesterDto } from '../models/school-semester';
import { SchoolSemesterService } from '../services/school-semester.service';

interface SchoolSemesterState {
  schoolSemesters: SchoolSemester[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolSemesterState = {
  schoolSemesters: [],
  isLoading: false,
  error: null,
};

export const SchoolSemesterStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolSemesterService = inject(SchoolSemesterService)) => ({
    loadAllSchoolSemesters: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolSemesterService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolSemesters: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolSemester: rxMethod<CreateSchoolSemesterDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolSemesterService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolSemesters: [...store.schoolSemesters(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
