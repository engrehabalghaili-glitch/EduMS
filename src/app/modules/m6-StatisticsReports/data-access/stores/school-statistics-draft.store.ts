import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SchoolStatisticsDraftService } from '../services/school-statistics-draft.service';
import type {
  SchoolStatisticsDraft,
  CreateSchoolStatisticsDraft,
  UpdateSchoolStatisticsDraft,
} from '../models/school-statistics-draft.dto';

interface SchoolStatisticsDraftState {
  schoolStatisticsDrafts: SchoolStatisticsDraft[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolStatisticsDraftState = {
  schoolStatisticsDrafts: [],
  isLoading: false,
  error: null,
};

export const SchoolStatisticsDraftStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, schoolStatisticsDraftService = inject(SchoolStatisticsDraftService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            schoolStatisticsDraftService.getAll().pipe(
              tapResponse({
                next: (schoolStatisticsDrafts: SchoolStatisticsDraft[]) =>
                  patchState(store, { schoolStatisticsDrafts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSchoolStatisticsDraft: rxMethod<CreateSchoolStatisticsDraft>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            schoolStatisticsDraftService.create(dto).pipe(
              tapResponse({
                next: (entity: SchoolStatisticsDraft) =>
                  patchState(store, {
                    schoolStatisticsDrafts: [...store.schoolStatisticsDrafts(), entity],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateSchoolStatisticsDraft: rxMethod<{
        id: number;
        dto: UpdateSchoolStatisticsDraft;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            schoolStatisticsDraftService.update(id, dto).pipe(
              tapResponse({
                next: (updated: SchoolStatisticsDraft) =>
                  patchState(store, {
                    schoolStatisticsDrafts: store
                      .schoolStatisticsDrafts()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeSchoolStatisticsDraft: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            schoolStatisticsDraftService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    schoolStatisticsDrafts: store
                      .schoolStatisticsDrafts()
                      .filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
