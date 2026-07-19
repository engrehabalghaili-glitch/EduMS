import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { JournalEntryService } from '../services/journal-entry.service';
import type { JournalEntry, CreateJournalEntryDto, UpdateJournalEntryDto } from '../models/journal-entry.interface';

interface JournalEntryState {
  journalEntries: JournalEntry[];
  isLoading: boolean;
  error: string | null;
}

const initialState: JournalEntryState = {
  journalEntries: [],
  isLoading: false,
  error: null,
};

export const JournalEntryStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, journalEntryService = inject(JournalEntryService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            journalEntryService.getAll().pipe(
              tapResponse({
                next: (journalEntries: JournalEntry[]) =>
                  patchState(store, { journalEntries, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewJournalEntry: rxMethod<CreateJournalEntryDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            journalEntryService.create(dto).pipe(
              tapResponse({
                next: (entity: JournalEntry) =>
                  patchState(store, {
                    journalEntries: [...store.journalEntries(), entity],
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

      updateJournalEntry: rxMethod<{ id: number; dto: UpdateJournalEntryDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            journalEntryService.update(id, dto).pipe(
              tapResponse({
                next: (updated: JournalEntry) =>
                  patchState(store, {
                    journalEntries: store
                      .journalEntries()
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

      removeJournalEntry: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            journalEntryService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    journalEntries: store.journalEntries().filter((e) => e.id !== id),
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
