import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetCategoryService } from '../services/asset-category.service';
import type { AssetCategory, CreateAssetCategoryRequest, UpdateAssetCategoryRequest } from '../models/asset-categories';

interface AssetCategoryState {
  assetCategories: AssetCategory[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetCategoryState = {
  assetCategories: [],
  isLoading: false,
  error: null,
};

export const AssetCategoryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetCategoryService = inject(AssetCategoryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetCategoryService.getAll().pipe(
              tapResponse({
                next: (assetCategories: AssetCategory[]) =>
                  patchState(store, { assetCategories, isLoading: false }),
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
            assetCategoryService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetCategories: AssetCategory[]) =>
                  patchState(store, { assetCategories, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetCategory: rxMethod<CreateAssetCategoryRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetCategoryService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetCategory) =>
                  patchState(store, {
                    assetCategories: [...store.assetCategories(), entity],
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

      updateAssetCategory: rxMethod<{ id: number; dto: UpdateAssetCategoryRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetCategoryService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetCategory) =>
                  patchState(store, {
                    assetCategories: store
                      .assetCategories()
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

      removeAssetCategory: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetCategoryService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetCategories: store.assetCategories().filter((e) => e.id !== id),
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
