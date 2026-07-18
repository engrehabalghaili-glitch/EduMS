import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { JournalEntryLineService } from '../services/journal-entry-line.service';
import type { JournalEntryLine, CreateJournalEntryLineDto, UpdateJournalEntryLineDto } from '../models/journal-entry-line.interface';

interface JournalEntryLineState {
  journalEntryLines: JournalEntryLine[];
  isLoading: boolean;
  error: string | null;
}

const initialState: JournalEntryLineState = {
  journalEntryLines: [],
  isLoading: false,
  error: null,
};

export const JournalEntryLineStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, journalEntryLineService = inject(JournalEntryLineService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            journalEntryLineService.getAll().pipe(
              tapResponse({
                next: (journalEntryLines: JournalEntryLine[]) =>
                  patchState(store, { journalEntryLines, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewJournalEntryLine: rxMethod<CreateJournalEntryLineDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            journalEntryLineService.create(dto).pipe(
              tapResponse({
                next: (entity: JournalEntryLine) =>
                  patchState(store, {
                    journalEntryLines: [...store.journalEntryLines(), entity],
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

      updateJournalEntryLine: rxMethod<{ id: number; dto: UpdateJournalEntryLineDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            journalEntryLineService.update(id, dto).pipe(
              tapResponse({
                next: (updated: JournalEntryLine) =>
                  patchState(store, {
                    journalEntryLines: store
                      .journalEntryLines()
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

      removeJournalEntryLine: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            journalEntryLineService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    journalEntryLines: store.journalEntryLines().filter((e) => e.id !== id),
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
