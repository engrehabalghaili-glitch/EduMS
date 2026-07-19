import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { RemediationPlan, CreateRemediationPlan, UpdateRemediationPlan } from '../models/remediation-plan.types';
import { RemediationPlanService } from '../services/remediation-plan.service';

interface RemediationPlanState {
  remediationPlans: RemediationPlan[];
  isLoading: boolean;
  error: string | null;
}

const initialState: RemediationPlanState = {
  remediationPlans: [],
  isLoading: false,
  error: null,
};

export const RemediationPlanStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, remediationPlanService = inject(RemediationPlanService)) => ({
    loadAllRemediationPlans: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          remediationPlanService.getAll().pipe(
            tapResponse({
              next: (remediationPlans) => patchState(store, { remediationPlans, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewRemediationPlan: rxMethod<CreateRemediationPlan>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          remediationPlanService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { remediationPlans: [...store.remediationPlans(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateRemediationPlan: rxMethod<{ id: number; dto: UpdateRemediationPlan }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          remediationPlanService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                remediationPlans: store.remediationPlans().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteRemediationPlan: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          remediationPlanService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                remediationPlans: store.remediationPlans().filter((e) => (e as { id: number }).id !== id),
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
