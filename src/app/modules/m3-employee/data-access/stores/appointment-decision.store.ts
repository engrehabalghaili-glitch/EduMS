import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { AppointmentDecision, CreateAppointmentDecision, UpdateAppointmentDecision } from '../models/appointment-decision.types';
import { AppointmentDecisionService } from '../services/appointment-decision.service';

interface AppointmentDecisionState {
  appointmentDecisions: AppointmentDecision[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AppointmentDecisionState = {
  appointmentDecisions: [],
  isLoading: false,
  error: null,
};

export const AppointmentDecisionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, appointmentDecisionService = inject(AppointmentDecisionService)) => ({
    loadAllAppointmentDecisions: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          appointmentDecisionService.getAll().pipe(
            tapResponse({
              next: (appointmentDecisions) => patchState(store, { appointmentDecisions, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewAppointmentDecision: rxMethod<CreateAppointmentDecision>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          appointmentDecisionService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { appointmentDecisions: [...store.appointmentDecisions(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateAppointmentDecision: rxMethod<{ id: number; dto: UpdateAppointmentDecision }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          appointmentDecisionService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                appointmentDecisions: store.appointmentDecisions().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteAppointmentDecision: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          appointmentDecisionService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                appointmentDecisions: store.appointmentDecisions().filter((e) => (e as { id: number }).id !== id),
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
