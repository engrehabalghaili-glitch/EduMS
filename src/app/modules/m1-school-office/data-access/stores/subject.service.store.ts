import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { Subject, CreateSubjectDto, UpdateSubjectDto } from '../models/subject';
import { SubjectService } from '../services/subject.service';

interface SubjectState {
  subjects: Subject[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SubjectState = {
  subjects: [],
  isLoading: false,
  error: null,
};

export const SubjectStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, subjectService = inject(SubjectService)) => ({
    loadAllSubjects: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          subjectService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { subjects: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSubject: rxMethod<CreateSubjectDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          subjectService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { subjects: [...store.subjects(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
