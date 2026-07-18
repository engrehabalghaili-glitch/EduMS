import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetWarrantyContractService } from '../services/asset-warranty-contract.service';
import type {
  AssetWarrantyContract,
  CreateAssetWarrantyContractRequest,
  UpdateAssetWarrantyContractRequest,
} from '../models/asset-warranty-contracts';

interface AssetWarrantyContractState {
  assetWarrantyContracts: AssetWarrantyContract[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetWarrantyContractState = {
  assetWarrantyContracts: [],
  isLoading: false,
  error: null,
};

export const AssetWarrantyContractStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetWarrantyContractService = inject(AssetWarrantyContractService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetWarrantyContractService.getAll().pipe(
              tapResponse({
                next: (assetWarrantyContracts: AssetWarrantyContract[]) =>
                  patchState(store, { assetWarrantyContracts, isLoading: false }),
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
            assetWarrantyContractService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetWarrantyContracts: AssetWarrantyContract[]) =>
                  patchState(store, { assetWarrantyContracts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetWarrantyContract: rxMethod<CreateAssetWarrantyContractRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetWarrantyContractService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetWarrantyContract) =>
                  patchState(store, {
                    assetWarrantyContracts: [...store.assetWarrantyContracts(), entity],
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

      updateAssetWarrantyContract: rxMethod<{
        id: number;
        dto: UpdateAssetWarrantyContractRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetWarrantyContractService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetWarrantyContract) =>
                  patchState(store, {
                    assetWarrantyContracts: store
                      .assetWarrantyContracts()
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

      removeAssetWarrantyContract: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetWarrantyContractService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetWarrantyContracts: store
                      .assetWarrantyContracts()
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
