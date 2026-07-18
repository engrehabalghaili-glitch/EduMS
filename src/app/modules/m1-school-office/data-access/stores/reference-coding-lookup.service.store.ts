import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ReferenceCodingLookup, CreateReferenceCodingLookupDto, UpdateReferenceCodingLookupDto } from '../models/reference-coding-lookup';
import { ReferenceCodingLookupService } from '../services/reference-coding-lookup.service';

interface ReferenceCodingLookupState {
  referenceCodingLookups: ReferenceCodingLookup[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ReferenceCodingLookupState = {
  referenceCodingLookups: [],
  isLoading: false,
  error: null,
};

export const ReferenceCodingLookupStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, referenceCodingLookupService = inject(ReferenceCodingLookupService)) => ({
    loadAllReferenceCodingLookups: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          referenceCodingLookupService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { referenceCodingLookups: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewReferenceCodingLookup: rxMethod<CreateReferenceCodingLookupDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          referenceCodingLookupService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { referenceCodingLookups: [...store.referenceCodingLookups(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
