import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { PrivilegeRule, CreatePrivilegeRule, UpdatePrivilegeRule } from '../models/privilege-rule.models';
import { PrivilegeRuleService } from '../services/privilege-rule.service';

interface PrivilegeRuleState {
  privilegeRules: PrivilegeRule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: PrivilegeRuleState = {
  privilegeRules: [],
  isLoading: false,
  error: null,
};

export const PrivilegeRuleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, privilegeRuleService = inject(PrivilegeRuleService)) => ({
    loadAllPrivilegeRules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          privilegeRuleService.getAll().pipe(
            tapResponse({
              next: (privilegeRules) => patchState(store, { privilegeRules, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewPrivilegeRule: rxMethod<CreatePrivilegeRule>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          privilegeRuleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { privilegeRules: [...store.privilegeRules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updatePrivilegeRule: rxMethod<{ id: number; dto: UpdatePrivilegeRule }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          privilegeRuleService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                privilegeRules: store.privilegeRules().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deletePrivilegeRule: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          privilegeRuleService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                privilegeRules: store.privilegeRules().filter((e) => (e as { id: number }).id !== id),
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
