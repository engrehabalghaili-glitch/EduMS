import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { AcademicBranchConfigLog, CreateAcademicBranchConfigLogDto, UpdateAcademicBranchConfigLogDto } from '../models/academic-branch-config-log';
import { AcademicBranchConfigLogService } from '../services/academic-branch-config-log.service';

interface AcademicBranchConfigLogState {
  academicBranchConfigLogs: AcademicBranchConfigLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AcademicBranchConfigLogState = {
  academicBranchConfigLogs: [],
  isLoading: false,
  error: null,
};

export const AcademicBranchConfigLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, academicBranchConfigLogService = inject(AcademicBranchConfigLogService)) => ({
    loadAllAcademicBranchConfigLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          academicBranchConfigLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { academicBranchConfigLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewAcademicBranchConfigLog: rxMethod<CreateAcademicBranchConfigLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          academicBranchConfigLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { academicBranchConfigLogs: [...store.academicBranchConfigLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
