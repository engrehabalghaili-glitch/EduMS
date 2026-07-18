import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolAccreditationLog, CreateSchoolAccreditationLogDto, UpdateSchoolAccreditationLogDto } from '../models/school-accreditation-log';
import { SchoolAccreditationLogService } from '../services/school-accreditation-log.service';

interface SchoolAccreditationLogState {
  schoolAccreditationLogs: SchoolAccreditationLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolAccreditationLogState = {
  schoolAccreditationLogs: [],
  isLoading: false,
  error: null,
};

export const SchoolAccreditationLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolAccreditationLogService = inject(SchoolAccreditationLogService)) => ({
    loadAllSchoolAccreditationLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolAccreditationLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolAccreditationLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolAccreditationLog: rxMethod<CreateSchoolAccreditationLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolAccreditationLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolAccreditationLogs: [...store.schoolAccreditationLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
