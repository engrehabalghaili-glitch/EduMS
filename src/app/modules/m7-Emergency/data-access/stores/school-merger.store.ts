import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolMerger, CreateSchoolMerger, UpdateSchoolMerger } from '../models/school-merger.types';
import { SchoolMergerService } from '../services/school-merger.service';

interface SchoolMergerState {
  schoolMergers: SchoolMerger[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolMergerState = {
  schoolMergers: [],
  isLoading: false,
  error: null,
};

export const SchoolMergerStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolMergerService = inject(SchoolMergerService)) => ({
    loadAllSchoolMergers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolMergerService.getAll().pipe(
            tapResponse({
              next: (schoolMergers) => patchState(store, { schoolMergers, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolMerger: rxMethod<CreateSchoolMerger>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolMergerService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolMergers: [...store.schoolMergers(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateSchoolMerger: rxMethod<{ id: number; dto: UpdateSchoolMerger }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          schoolMergerService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                schoolMergers: store.schoolMergers().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteSchoolMerger: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          schoolMergerService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                schoolMergers: store.schoolMergers().filter((e) => (e as { id: number }).id !== id),
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
