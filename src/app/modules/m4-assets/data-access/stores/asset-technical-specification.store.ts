import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetTechnicalSpecificationService } from '../services/asset-technical-specification.service';
import type {
  AssetTechnicalSpecification,
  CreateAssetTechnicalSpecificationRequest,
  UpdateAssetTechnicalSpecificationRequest,
} from '../models/asset-technical-specifications';

interface AssetTechnicalSpecificationState {
  assetTechnicalSpecifications: AssetTechnicalSpecification[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetTechnicalSpecificationState = {
  assetTechnicalSpecifications: [],
  isLoading: false,
  error: null,
};

export const AssetTechnicalSpecificationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetTechnicalSpecificationService = inject(AssetTechnicalSpecificationService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetTechnicalSpecificationService.getAll().pipe(
              tapResponse({
                next: (assetTechnicalSpecifications: AssetTechnicalSpecification[]) =>
                  patchState(store, { assetTechnicalSpecifications, isLoading: false }),
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
            assetTechnicalSpecificationService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetTechnicalSpecifications: AssetTechnicalSpecification[]) =>
                  patchState(store, { assetTechnicalSpecifications, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetTechnicalSpecification: rxMethod<CreateAssetTechnicalSpecificationRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetTechnicalSpecificationService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetTechnicalSpecification) =>
                  patchState(store, {
                    assetTechnicalSpecifications: [...store.assetTechnicalSpecifications(), entity],
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

      updateAssetTechnicalSpecification: rxMethod<{
        id: number;
        dto: UpdateAssetTechnicalSpecificationRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetTechnicalSpecificationService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetTechnicalSpecification) =>
                  patchState(store, {
                    assetTechnicalSpecifications: store
                      .assetTechnicalSpecifications()
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

      removeAssetTechnicalSpecification: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetTechnicalSpecificationService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetTechnicalSpecifications: store
                      .assetTechnicalSpecifications()
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
