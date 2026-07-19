import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetComplianceAuditService } from '../services/asset-compliance-audit.service';
import type { AssetComplianceAudit, CreateAssetComplianceAuditRequest, UpdateAssetComplianceAuditRequest } from '../models/asset-compliance-audits';

interface AssetComplianceAuditState {
  assetComplianceAudits: AssetComplianceAudit[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetComplianceAuditState = {
  assetComplianceAudits: [],
  isLoading: false,
  error: null,
};

export const AssetComplianceAuditStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetComplianceAuditService = inject(AssetComplianceAuditService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetComplianceAuditService.getAll().pipe(
              tapResponse({
                next: (assetComplianceAudits: AssetComplianceAudit[]) =>
                  patchState(store, { assetComplianceAudits, isLoading: false }),
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
            assetComplianceAuditService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (assetComplianceAudits: AssetComplianceAudit[]) =>
                  patchState(store, { assetComplianceAudits, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetComplianceAudit: rxMethod<CreateAssetComplianceAuditRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetComplianceAuditService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetComplianceAudit) =>
                  patchState(store, {
                    assetComplianceAudits: [...store.assetComplianceAudits(), entity],
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

      updateAssetComplianceAudit: rxMethod<{ id: number; dto: UpdateAssetComplianceAuditRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetComplianceAuditService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetComplianceAudit) =>
                  patchState(store, {
                    assetComplianceAudits: store
                      .assetComplianceAudits()
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

      removeAssetComplianceAudit: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetComplianceAuditService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetComplianceAudits: store.assetComplianceAudits().filter((e) => e.id !== id),
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
