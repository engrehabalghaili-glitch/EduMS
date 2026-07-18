import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolCurriculumPlan, CreateSchoolCurriculumPlanDto, UpdateSchoolCurriculumPlanDto } from '../models/school-curriculum-plan';
import { SchoolCurriculumPlanService } from '../services/school-curriculum-plan.service';

interface SchoolCurriculumPlanState {
  schoolCurriculumPlans: SchoolCurriculumPlan[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolCurriculumPlanState = {
  schoolCurriculumPlans: [],
  isLoading: false,
  error: null,
};

export const SchoolCurriculumPlanStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolCurriculumPlanService = inject(SchoolCurriculumPlanService)) => ({
    loadAllSchoolCurriculumPlans: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolCurriculumPlanService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolCurriculumPlans: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolCurriculumPlan: rxMethod<CreateSchoolCurriculumPlanDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolCurriculumPlanService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolCurriculumPlans: [...store.schoolCurriculumPlans(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
