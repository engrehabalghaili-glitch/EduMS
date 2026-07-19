import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolAward, CreateSchoolAward, UpdateSchoolAward } from '../models/school-award.types';
import { SchoolAwardService } from '../services/school-award.service';

interface SchoolAwardState {
  schoolAwards: SchoolAward[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAwardState = {
  schoolAwards: [],
  isLoading: false,
  error: null,
};

export const SchoolAwardStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolAwardService = inject(SchoolAwardService)) => ({
    loadAllSchoolAwards: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolAwardService.getAll().pipe(
            tapResponse({
              next: (schoolAwards) => patchState(store, { schoolAwards, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolAward: rxMethod<CreateSchoolAward>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolAwardService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolAwards: [...store.schoolAwards(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSchoolAward: rxMethod<{ id: number; dto: UpdateSchoolAward }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          schoolAwardService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                schoolAwards: store.schoolAwards().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSchoolAward: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          schoolAwardService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                schoolAwards: store.schoolAwards().filter((e) => (e as { id: number }).id !== id),
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
