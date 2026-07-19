import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetFinancialAuditArchiveService } from '../services/asset-financial-audit-archive.service';
import type { AssetFinancialAuditArchive, CreateAssetFinancialAuditArchiveRequest, UpdateAssetFinancialAuditArchiveRequest } from '../models/asset-financial-audit-archives';

interface AssetFinancialAuditArchiveState {
  assetFinancialAuditArchives: AssetFinancialAuditArchive[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetFinancialAuditArchiveState = {
  assetFinancialAuditArchives: [],
  isLoading: false,
  error: null,
};

export const AssetFinancialAuditArchiveStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetFinancialAuditArchiveService = inject(AssetFinancialAuditArchiveService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetFinancialAuditArchiveService.getAll().pipe(
              tapResponse({
                next: (assetFinancialAuditArchives: AssetFinancialAuditArchive[]) =>
                  patchState(store, { assetFinancialAuditArchives, isLoading: false }),
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
            assetFinancialAuditArchiveService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetFinancialAuditArchives: AssetFinancialAuditArchive[]) =>
                  patchState(store, { assetFinancialAuditArchives, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetFinancialAuditArchive: rxMethod<CreateAssetFinancialAuditArchiveRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetFinancialAuditArchiveService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetFinancialAuditArchive) =>
                  patchState(store, {
                    assetFinancialAuditArchives: [...store.assetFinancialAuditArchives(), entity],
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

      updateAssetFinancialAuditArchive: rxMethod<{ id: number; dto: UpdateAssetFinancialAuditArchiveRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetFinancialAuditArchiveService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetFinancialAuditArchive) =>
                  patchState(store, {
                    assetFinancialAuditArchives: store
                      .assetFinancialAuditArchives()
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

      removeAssetFinancialAuditArchive: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetFinancialAuditArchiveService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetFinancialAuditArchives: store.assetFinancialAuditArchives().filter((e) => e.id !== id),
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
