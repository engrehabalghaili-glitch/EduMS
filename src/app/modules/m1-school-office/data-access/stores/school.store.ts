import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { School, CreateSchoolDto } from '../models/school';
import { SchoolService } from '../services/school.service';

interface SchoolState {
  schools: School[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolState = {
  schools: [],
  isLoading: false,
  error: null,
};

export const SchoolStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolService = inject(SchoolService)) => ({
    loadAllSchools: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolService.getAll().pipe(
            tapResponse({
              next: (schools) => patchState(store, { schools, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    registerNewSchool: rxMethod<CreateSchoolDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolService.create(dto).pipe(
            tapResponse({
              next: (school) => patchState(store, { schools: [...store.schools(), school], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
