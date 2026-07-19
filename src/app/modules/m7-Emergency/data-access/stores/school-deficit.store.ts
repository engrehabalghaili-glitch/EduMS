import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolDeficit, CreateSchoolDeficit, UpdateSchoolDeficit } from '../models/school-deficit.types';
import { SchoolDeficitService } from '../services/school-deficit.service';

interface SchoolDeficitState {
  schoolDeficits: SchoolDeficit[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolDeficitState = {
  schoolDeficits: [],
  isLoading: false,
  error: null,
};

export const SchoolDeficitStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolDeficitService = inject(SchoolDeficitService)) => ({
    loadAllSchoolDeficits: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolDeficitService.getAll().pipe(
            tapResponse({
              next: (schoolDeficits) => patchState(store, { schoolDeficits, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolDeficit: rxMethod<CreateSchoolDeficit>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolDeficitService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolDeficits: [...store.schoolDeficits(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSchoolDeficit: rxMethod<{ id: number; dto: UpdateSchoolDeficit }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          schoolDeficitService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                schoolDeficits: store.schoolDeficits().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSchoolDeficit: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          schoolDeficitService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                schoolDeficits: store.schoolDeficits().filter((e) => (e as { id: number }).id !== id),
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
