import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { CommitteeMember, CreateCommitteeMember, UpdateCommitteeMember } from '../models/committee-member.types';
import { CommitteeMemberService } from '../services/committee-member.service';

interface CommitteeMemberState {
  committeeMembers: CommitteeMember[];
  isLoading: boolean;
  error: string | null;
}

const initialState: CommitteeMemberState = {
  committeeMembers: [],
  isLoading: false,
  error: null,
};

export const CommitteeMemberStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, committeeMemberService = inject(CommitteeMemberService)) => ({
    loadAllCommitteeMembers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          committeeMemberService.getAll().pipe(
            tapResponse({
              next: (committeeMembers) => patchState(store, { committeeMembers, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewCommitteeMember: rxMethod<CreateCommitteeMember>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          committeeMemberService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { committeeMembers: [...store.committeeMembers(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateCommitteeMember: rxMethod<{ id: number; dto: UpdateCommitteeMember }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          committeeMemberService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                committeeMembers: store.committeeMembers().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteCommitteeMember: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          committeeMemberService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                committeeMembers: store.committeeMembers().filter((e) => (e as { id: number }).id !== id),
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
