import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmergencyIncident, CreateEmergencyIncident, UpdateEmergencyIncident } from '../models/emergency-incident.types';
import { EmergencyIncidentService } from '../services/emergency-incident.service';

interface EmergencyIncidentState {
  emergencyIncidents: EmergencyIncident[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmergencyIncidentState = {
  emergencyIncidents: [],
  isLoading: false,
  error: null,
};

export const EmergencyIncidentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, emergencyIncidentService = inject(EmergencyIncidentService)) => ({
    loadAllEmergencyIncidents: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          emergencyIncidentService.getAll().pipe(
            tapResponse({
              next: (emergencyIncidents) => patchState(store, { emergencyIncidents, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmergencyIncident: rxMethod<CreateEmergencyIncident>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          emergencyIncidentService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { emergencyIncidents: [...store.emergencyIncidents(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmergencyIncident: rxMethod<{ id: number; dto: UpdateEmergencyIncident }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          emergencyIncidentService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                emergencyIncidents: store.emergencyIncidents().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmergencyIncident: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          emergencyIncidentService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                emergencyIncidents: store.emergencyIncidents().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
