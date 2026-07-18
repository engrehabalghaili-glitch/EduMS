import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { DirectorateExamCenterAssignment, CreateDirectorateExamCenterAssignmentDto, UpdateDirectorateExamCenterAssignmentDto } from '../models/directorate-exam-center-assignment';
import { DirectorateExamCenterAssignmentService } from '../services/directorate-exam-center-assignment.service';

interface DirectorateExamCenterAssignmentState {
  directorateExamCenterAssignments: DirectorateExamCenterAssignment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DirectorateExamCenterAssignmentState = {
  directorateExamCenterAssignments: [],
  isLoading: false,
  error: null,
};

export const DirectorateExamCenterAssignmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, directorateExamCenterAssignmentService = inject(DirectorateExamCenterAssignmentService)) => ({
    loadAllDirectorateExamCenterAssignments: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          directorateExamCenterAssignmentService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { directorateExamCenterAssignments: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewDirectorateExamCenterAssignment: rxMethod<CreateDirectorateExamCenterAssignmentDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          directorateExamCenterAssignmentService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { directorateExamCenterAssignments: [...store.directorateExamCenterAssignments(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
