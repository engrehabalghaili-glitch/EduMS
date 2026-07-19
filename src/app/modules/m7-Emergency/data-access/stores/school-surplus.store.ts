import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolSurplus, CreateSchoolSurplus, UpdateSchoolSurplus } from '../models/school-surplus.types';
import { SchoolSurplusService } from '../services/school-surplus.service';

interface SchoolSurplusState {
  schoolSurpluses: SchoolSurplus[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolSurplusState = {
  schoolSurpluses: [],
  isLoading: false,
  error: null,
};

export const SchoolSurplusStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolSurplusService = inject(SchoolSurplusService)) => ({
    loadAllSchoolSurpluses: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolSurplusService.getAll().pipe(
            tapResponse({
              next: (schoolSurpluses) => patchState(store, { schoolSurpluses, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolSurplus: rxMethod<CreateSchoolSurplus>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolSurplusService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolSurpluses: [...store.schoolSurpluses(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSchoolSurplus: rxMethod<{ id: number; dto: UpdateSchoolSurplus }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          schoolSurplusService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                schoolSurpluses: store.schoolSurpluses().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSchoolSurplus: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          schoolSurplusService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                schoolSurpluses: store.schoolSurpluses().filter((e) => (e as { id: number }).id !== id),
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
