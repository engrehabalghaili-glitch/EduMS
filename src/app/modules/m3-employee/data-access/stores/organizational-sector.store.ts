import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { OrganizationalSector, CreateOrganizationalSector, UpdateOrganizationalSector } from '../models/organizational-sector.types';
import { OrganizationalSectorService } from '../services/organizational-sector.service';

interface OrganizationalSectorState {
  organizationalSectors: OrganizationalSector[];
  isLoading: boolean;
  error: string | null;
}

const initialState: OrganizationalSectorState = {
  organizationalSectors: [],
  isLoading: false,
  error: null,
};

export const OrganizationalSectorStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, organizationalSectorService = inject(OrganizationalSectorService)) => ({
    loadAllOrganizationalSectors: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          organizationalSectorService.getAll().pipe(
            tapResponse({
              next: (organizationalSectors) => patchState(store, { organizationalSectors, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewOrganizationalSector: rxMethod<CreateOrganizationalSector>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          organizationalSectorService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { organizationalSectors: [...store.organizationalSectors(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateOrganizationalSector: rxMethod<{ id: number; dto: UpdateOrganizationalSector }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          organizationalSectorService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                organizationalSectors: store.organizationalSectors().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteOrganizationalSector: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          organizationalSectorService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                organizationalSectors: store.organizationalSectors().filter((e) => (e as { id: number }).id !== id),
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
