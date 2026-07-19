import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EducationalSupervisionVisit, CreateEducationalSupervisionVisitDto, UpdateEducationalSupervisionVisitDto } from '../models/educational-supervision-visit';
import { EducationalSupervisionVisitService } from '../services/educational-supervision-visit.service';

interface EducationalSupervisionVisitState {
  educationalSupervisionVisits: EducationalSupervisionVisit[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EducationalSupervisionVisitState = {
  educationalSupervisionVisits: [],
  isLoading: false,
  error: null,
};

export const EducationalSupervisionVisitStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, educationalSupervisionVisitService = inject(EducationalSupervisionVisitService)) => ({
    loadAllEducationalSupervisionVisits: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          educationalSupervisionVisitService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { educationalSupervisionVisits: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEducationalSupervisionVisit: rxMethod<CreateEducationalSupervisionVisitDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          educationalSupervisionVisitService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { educationalSupervisionVisits: [...store.educationalSupervisionVisits(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
