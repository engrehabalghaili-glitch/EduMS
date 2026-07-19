import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ClassroomOperationalRule, CreateClassroomOperationalRuleDto, UpdateClassroomOperationalRuleDto } from '../models/classroom-operational-rule';
import { ClassroomOperationalRuleService } from '../services/classroom-operational-rule.service';

interface ClassroomOperationalRuleState {
  classroomOperationalRules: ClassroomOperationalRule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ClassroomOperationalRuleState = {
  classroomOperationalRules: [],
  isLoading: false,
  error: null,
};

export const ClassroomOperationalRuleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, classroomOperationalRuleService = inject(ClassroomOperationalRuleService)) => ({
    loadAllClassroomOperationalRules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          classroomOperationalRuleService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { classroomOperationalRules: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewClassroomOperationalRule: rxMethod<CreateClassroomOperationalRuleDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          classroomOperationalRuleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { classroomOperationalRules: [...store.classroomOperationalRules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
