import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolFacilityMaintenanceLog, CreateSchoolFacilityMaintenanceLogDto, UpdateSchoolFacilityMaintenanceLogDto } from '../models/school-facility-maintenance-log';
import { SchoolFacilityMaintenanceLogService } from '../services/school-facility-maintenance-log.service';

interface SchoolFacilityMaintenanceLogState {
  schoolFacilityMaintenanceLogs: SchoolFacilityMaintenanceLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolFacilityMaintenanceLogState = {
  schoolFacilityMaintenanceLogs: [],
  isLoading: false,
  error: null,
};

export const SchoolFacilityMaintenanceLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolFacilityMaintenanceLogService = inject(SchoolFacilityMaintenanceLogService)) => ({
    loadAllSchoolFacilityMaintenanceLogs: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolFacilityMaintenanceLogService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolFacilityMaintenanceLogs: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolFacilityMaintenanceLog: rxMethod<CreateSchoolFacilityMaintenanceLogDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolFacilityMaintenanceLogService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolFacilityMaintenanceLogs: [...store.schoolFacilityMaintenanceLogs(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
