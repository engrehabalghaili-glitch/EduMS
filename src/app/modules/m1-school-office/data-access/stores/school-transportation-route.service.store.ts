import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolTransportationRoute, CreateSchoolTransportationRouteDto, UpdateSchoolTransportationRouteDto } from '../models/school-transportation-route';
import { SchoolTransportationRouteService } from '../services/school-transportation-route.service';

interface SchoolTransportationRouteState {
  schoolTransportationRoutes: SchoolTransportationRoute[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolTransportationRouteState = {
  schoolTransportationRoutes: [],
  isLoading: false,
  error: null,
};

export const SchoolTransportationRouteStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolTransportationRouteService = inject(SchoolTransportationRouteService)) => ({
    loadAllSchoolTransportationRoutes: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolTransportationRouteService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolTransportationRoutes: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolTransportationRoute: rxMethod<CreateSchoolTransportationRouteDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolTransportationRouteService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolTransportationRoutes: [...store.schoolTransportationRoutes(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
