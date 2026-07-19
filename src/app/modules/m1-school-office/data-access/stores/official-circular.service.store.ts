import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { OfficialCircular, CreateOfficialCircularDto, UpdateOfficialCircularDto } from '../models/official-circular';
import { OfficialCircularService } from '../services/official-circular.service';

interface OfficialCircularState {
  officialCirculars: OfficialCircular[];
  isLoading: boolean;
  error: string | null;
}

const initialState: OfficialCircularState = {
  officialCirculars: [],
  isLoading: false,
  error: null,
};

export const OfficialCircularStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, officialCircularService = inject(OfficialCircularService)) => ({
    loadAllOfficialCirculars: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          officialCircularService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { officialCirculars: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewOfficialCircular: rxMethod<CreateOfficialCircularDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          officialCircularService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { officialCirculars: [...store.officialCirculars(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
