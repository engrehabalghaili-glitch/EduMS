import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { AcademicWarningPolicy, CreateAcademicWarningPolicyDto, UpdateAcademicWarningPolicyDto } from '../models/academic-warning-policy';
import { AcademicWarningPolicyService } from '../services/academic-warning-policy.service';

interface AcademicWarningPolicyState {
  academicWarningPolicys: AcademicWarningPolicy[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AcademicWarningPolicyState = {
  academicWarningPolicys: [],
  isLoading: false,
  error: null,
};

export const AcademicWarningPolicyStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, academicWarningPolicyService = inject(AcademicWarningPolicyService)) => ({
    loadAllAcademicWarningPolicys: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          academicWarningPolicyService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { academicWarningPolicys: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewAcademicWarningPolicy: rxMethod<CreateAcademicWarningPolicyDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          academicWarningPolicyService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { academicWarningPolicys: [...store.academicWarningPolicys(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
