import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolFacility, CreateSchoolFacilityDto, UpdateSchoolFacilityDto } from '../models/school-facility';
import { SchoolFacilityService } from '../services/school-facility.service';

interface SchoolFacilityState {
  schoolFacilitys: SchoolFacility[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolFacilityState = {
  schoolFacilitys: [],
  isLoading: false,
  error: null,
};

export const SchoolFacilityStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolFacilityService = inject(SchoolFacilityService)) => ({
    loadAllSchoolFacilitys: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolFacilityService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolFacilitys: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolFacility: rxMethod<CreateSchoolFacilityDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolFacilityService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolFacilitys: [...store.schoolFacilitys(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
