import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SchoolAssetService } from '../services/school-asset.service';
import type { SchoolAsset, CreateSchoolAssetRequest, UpdateSchoolAssetRequest } from '../models/school-assets';

interface SchoolAssetState {
  schoolAssets: SchoolAsset[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAssetState = {
  schoolAssets: [],
  isLoading: false,
  error: null,
};

export const SchoolAssetStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, schoolAssetService = inject(SchoolAssetService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            schoolAssetService.getAll().pipe(
              tapResponse({
                next: (schoolAssets: SchoolAsset[]) =>
                  patchState(store, { schoolAssets, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            schoolAssetService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (schoolAssets: SchoolAsset[]) =>
                  patchState(store, { schoolAssets, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSchoolAsset: rxMethod<CreateSchoolAssetRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            schoolAssetService.create(dto).pipe(
              tapResponse({
                next: (entity: SchoolAsset) =>
                  patchState(store, {
                    schoolAssets: [...store.schoolAssets(), entity],
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

      updateSchoolAsset: rxMethod<{ id: number; dto: UpdateSchoolAssetRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            schoolAssetService.update(id, dto).pipe(
              tapResponse({
                next: (updated: SchoolAsset) =>
                  patchState(store, {
                    schoolAssets: store
                      .schoolAssets()
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

      removeSchoolAsset: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            schoolAssetService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    schoolAssets: store.schoolAssets().filter((e) => e.id !== id),
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
