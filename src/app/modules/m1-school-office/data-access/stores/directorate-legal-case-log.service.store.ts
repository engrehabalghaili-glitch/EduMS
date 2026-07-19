import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { DirectorateLegalCaseLog, CreateDirectorateLegalCaseLogDto, UpdateDirectorateLegalCaseLogDto } from '../models/directorate-legal-case-log';
import { DirectorateLegalCaseLogService } from '../services/directorate-legal-case-log.service';

interface DirectorateLegalCaseLogState {
  directorateLegalCaseLogs: DirectorateLegalCaseLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DirectorateLegalCaseLogState = {
  directorateLegalCaseLogs: [],
  isLoading: false,
  error: null,
};

export const DirectorateLegalCaseLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, directorateLegalCaseLogService = inject(DirectorateLegalCaseLogService)) => ({
    loadAllDirectorateLegalCaseLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          directorateLegalCaseLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { directorateLegalCaseLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewDirectorateLegalCaseLog: rxMethod<CreateDirectorateLegalCaseLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          directorateLegalCaseLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { directorateLegalCaseLogs: [...store.directorateLegalCaseLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
