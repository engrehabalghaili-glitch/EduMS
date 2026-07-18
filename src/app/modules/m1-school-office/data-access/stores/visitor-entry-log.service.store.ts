import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { VisitorEntryLog, CreateVisitorEntryLogDto, UpdateVisitorEntryLogDto } from '../models/visitor-entry-log';
import { VisitorEntryLogService } from '../services/visitor-entry-log.service';

interface VisitorEntryLogState {
  visitorEntryLogs: VisitorEntryLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: VisitorEntryLogState = {
  visitorEntryLogs: [],
  isLoading: false,
  error: null,
};

export const VisitorEntryLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, visitorEntryLogService = inject(VisitorEntryLogService)) => ({
    loadAllVisitorEntryLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          visitorEntryLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { visitorEntryLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewVisitorEntryLog: rxMethod<CreateVisitorEntryLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          visitorEntryLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { visitorEntryLogs: [...store.visitorEntryLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
