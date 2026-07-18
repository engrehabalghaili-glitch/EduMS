import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolOperationalBudgetLog, CreateSchoolOperationalBudgetLogDto, UpdateSchoolOperationalBudgetLogDto } from '../models/school-operational-budget-log';
import { SchoolOperationalBudgetLogService } from '../services/school-operational-budget-log.service';

interface SchoolOperationalBudgetLogState {
  schoolOperationalBudgetLogs: SchoolOperationalBudgetLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolOperationalBudgetLogState = {
  schoolOperationalBudgetLogs: [],
  isLoading: false,
  error: null,
};

export const SchoolOperationalBudgetLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolOperationalBudgetLogService = inject(SchoolOperationalBudgetLogService)) => ({
    loadAllSchoolOperationalBudgetLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolOperationalBudgetLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolOperationalBudgetLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolOperationalBudgetLog: rxMethod<CreateSchoolOperationalBudgetLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolOperationalBudgetLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolOperationalBudgetLogs: [...store.schoolOperationalBudgetLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
