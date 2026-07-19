import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolEventCalendar, CreateSchoolEventCalendarDto, UpdateSchoolEventCalendarDto } from '../models/school-event-calendar';
import { SchoolEventCalendarService } from '../services/school-event-calendar.service';

interface SchoolEventCalendarState {
  schoolEventCalendars: SchoolEventCalendar[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolEventCalendarState = {
  schoolEventCalendars: [],
  isLoading: false,
  error: null,
};

export const SchoolEventCalendarStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolEventCalendarService = inject(SchoolEventCalendarService)) => ({
    loadAllSchoolEventCalendars: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolEventCalendarService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolEventCalendars: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolEventCalendar: rxMethod<CreateSchoolEventCalendarDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolEventCalendarService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolEventCalendars: [...store.schoolEventCalendars(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
