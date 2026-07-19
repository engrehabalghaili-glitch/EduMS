import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolAnnouncementLog, CreateSchoolAnnouncementLogDto, UpdateSchoolAnnouncementLogDto } from '../models/school-announcement-log';
import { SchoolAnnouncementLogService } from '../services/school-announcement-log.service';

interface SchoolAnnouncementLogState {
  schoolAnnouncementLogs: SchoolAnnouncementLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAnnouncementLogState = {
  schoolAnnouncementLogs: [],
  isLoading: false,
  error: null,
};

export const SchoolAnnouncementLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolAnnouncementLogService = inject(SchoolAnnouncementLogService)) => ({
    loadAllSchoolAnnouncementLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolAnnouncementLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolAnnouncementLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolAnnouncementLog: rxMethod<CreateSchoolAnnouncementLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolAnnouncementLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolAnnouncementLogs: [...store.schoolAnnouncementLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
