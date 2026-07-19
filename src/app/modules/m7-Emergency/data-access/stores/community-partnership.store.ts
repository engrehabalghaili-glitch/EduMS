import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { CommunityPartnership, CreateCommunityPartnership, UpdateCommunityPartnership } from '../models/community-partnership.types';
import { CommunityPartnershipService } from '../services/community-partnership.service';

interface CommunityPartnershipState {
  communityPartnerships: CommunityPartnership[];
  isLoading: boolean;
  error: string | null;
}

const initialState: CommunityPartnershipState = {
  communityPartnerships: [],
  isLoading: false,
  error: null,
};

export const CommunityPartnershipStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, communityPartnershipService = inject(CommunityPartnershipService)) => ({
    loadAllCommunityPartnerships: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          communityPartnershipService.getAll().pipe(
            tapResponse({
              next: (communityPartnerships) => patchState(store, { communityPartnerships, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewCommunityPartnership: rxMethod<CreateCommunityPartnership>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          communityPartnershipService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { communityPartnerships: [...store.communityPartnerships(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateCommunityPartnership: rxMethod<{ id: number; dto: UpdateCommunityPartnership }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          communityPartnershipService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                communityPartnerships: store.communityPartnerships().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteCommunityPartnership: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          communityPartnershipService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                communityPartnerships: store.communityPartnerships().filter((e) => (e as { id: number }).id !== id),
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
