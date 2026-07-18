import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolLevel, CreateSchoolLevelDto, UpdateSchoolLevelDto } from '../models/school-level';
import { SchoolLevelService } from '../services/school-level.service';

interface SchoolLevelState {
  schoolLevels: SchoolLevel[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolLevelState = {
  schoolLevels: [],
  isLoading: false,
  error: null,
};

export const SchoolLevelStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolLevelService = inject(SchoolLevelService)) => ({
    loadAllSchoolLevels: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolLevelService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolLevels: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolLevel: rxMethod<CreateSchoolLevelDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolLevelService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolLevels: [...store.schoolLevels(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
