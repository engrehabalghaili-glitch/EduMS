import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AssetDocumentService } from '../services/asset-document.service';
import type { AssetDocument, CreateAssetDocumentRequest, UpdateAssetDocumentRequest } from '../models/asset-documents';

interface AssetDocumentState {
  assetDocuments: AssetDocument[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AssetDocumentState = {
  assetDocuments: [],
  isLoading: false,
  error: null,
};

export const AssetDocumentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, assetDocumentService = inject(AssetDocumentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            assetDocumentService.getAll().pipe(
              tapResponse({
                next: (assetDocuments: AssetDocument[]) =>
                  patchState(store, { assetDocuments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByAssetId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((assetId) =>
            assetDocumentService.getByAssetId(assetId).pipe(
              tapResponse({
                next: (assetDocuments: AssetDocument[]) =>
                  patchState(store, { assetDocuments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAssetDocument: rxMethod<CreateAssetDocumentRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            assetDocumentService.create(dto).pipe(
              tapResponse({
                next: (entity: AssetDocument) =>
                  patchState(store, {
                    assetDocuments: [...store.assetDocuments(), entity],
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

      updateAssetDocument: rxMethod<{ id: number; dto: UpdateAssetDocumentRequest }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            assetDocumentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: AssetDocument) =>
                  patchState(store, {
                    assetDocuments: store
                      .assetDocuments()
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

      removeAssetDocument: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            assetDocumentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    assetDocuments: store.assetDocuments().filter((e) => e.id !== id),
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
