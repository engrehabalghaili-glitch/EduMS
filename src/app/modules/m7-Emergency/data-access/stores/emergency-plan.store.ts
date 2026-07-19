import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmergencyPlan, CreateEmergencyPlan, UpdateEmergencyPlan } from '../models/emergency-plan.types';
import { EmergencyPlanService } from '../services/emergency-plan.service';

interface EmergencyPlanState {
  emergencyPlans: EmergencyPlan[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmergencyPlanState = {
  emergencyPlans: [],
  isLoading: false,
  error: null,
};

export const EmergencyPlanStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, emergencyPlanService = inject(EmergencyPlanService)) => ({
    loadAllEmergencyPlans: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          emergencyPlanService.getAll().pipe(
            tapResponse({
              next: (emergencyPlans) => patchState(store, { emergencyPlans, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmergencyPlan: rxMethod<CreateEmergencyPlan>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          emergencyPlanService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { emergencyPlans: [...store.emergencyPlans(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmergencyPlan: rxMethod<{ id: number; dto: UpdateEmergencyPlan }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          emergencyPlanService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                emergencyPlans: store.emergencyPlans().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmergencyPlan: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          emergencyPlanService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                emergencyPlans: store.emergencyPlans().filter((e) => (e as { id: number }).id !== id),
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
