import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ExamDistributionTimetable, CreateExamDistributionTimetableDto, UpdateExamDistributionTimetableDto } from '../models/exam-distribution-timetable';
import { ExamDistributionTimetableService } from '../services/exam-distribution-timetable.service';

interface ExamDistributionTimetableState {
  examDistributionTimetables: ExamDistributionTimetable[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExamDistributionTimetableState = {
  examDistributionTimetables: [],
  isLoading: false,
  error: null,
};

export const ExamDistributionTimetableStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, examDistributionTimetableService = inject(ExamDistributionTimetableService)) => ({
    loadAllExamDistributionTimetables: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          examDistributionTimetableService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { examDistributionTimetables: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewExamDistributionTimetable: rxMethod<CreateExamDistributionTimetableDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          examDistributionTimetableService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { examDistributionTimetables: [...store.examDistributionTimetables(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
