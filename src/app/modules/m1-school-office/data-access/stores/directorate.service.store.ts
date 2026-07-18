import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { Directorate, CreateDirectorateDto, UpdateDirectorateDto } from '../models/directorate';
import { DirectorateService } from '../services/directorate.service';

interface DirectorateState {
  directorates: Directorate[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DirectorateState = {
  directorates: [],
  isLoading: false,
  error: null,
};

export const DirectorateStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, directorateService = inject(DirectorateService)) => ({
    loadAllDirectorates: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          directorateService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { directorates: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewDirectorate: rxMethod<CreateDirectorateDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          directorateService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { directorates: [...store.directorates(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
