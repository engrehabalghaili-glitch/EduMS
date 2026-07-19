import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { GovernanceRbacRule, CreateGovernanceRbacRule, UpdateGovernanceRbacRule } from '../models/governance-rbac-rule.models';
import { GovernanceRbacRuleService } from '../services/governance-rbac-rule.service';

interface GovernanceRbacRuleState {
  governanceRbacRules: GovernanceRbacRule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: GovernanceRbacRuleState = {
  governanceRbacRules: [],
  isLoading: false,
  error: null,
};

export const GovernanceRbacRuleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, governanceRbacRuleService = inject(GovernanceRbacRuleService)) => ({
    loadAllGovernanceRbacRules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          governanceRbacRuleService.getAll().pipe(
            tapResponse({
              next: (governanceRbacRules) => patchState(store, { governanceRbacRules, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewGovernanceRbacRule: rxMethod<CreateGovernanceRbacRule>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          governanceRbacRuleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { governanceRbacRules: [...store.governanceRbacRules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateGovernanceRbacRule: rxMethod<{ id: number; dto: UpdateGovernanceRbacRule }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          governanceRbacRuleService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                governanceRbacRules: store.governanceRbacRules().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteGovernanceRbacRule: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          governanceRbacRuleService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                governanceRbacRules: store.governanceRbacRules().filter((e) => (e as { id: number }).id !== id),
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