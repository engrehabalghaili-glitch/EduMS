import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { JobApplicant, CreateJobApplicant, UpdateJobApplicant } from '../models/job-applicant.types';
import { JobApplicantService } from '../services/job-applicant.service';

interface JobApplicantState {
  jobApplicants: JobApplicant[];
  isLoading: boolean;
  error: string | null;
}

const initialState: JobApplicantState = {
  jobApplicants: [],
  isLoading: false,
  error: null,
};

export const JobApplicantStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, jobApplicantService = inject(JobApplicantService)) => ({
    loadAllJobApplicants: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          jobApplicantService.getAll().pipe(
            tapResponse({
              next: (jobApplicants) => patchState(store, { jobApplicants, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewJobApplicant: rxMethod<CreateJobApplicant>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          jobApplicantService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { jobApplicants: [...store.jobApplicants(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateJobApplicant: rxMethod<{ id: number; dto: UpdateJobApplicant }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          jobApplicantService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                jobApplicants: store.jobApplicants().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteJobApplicant: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          jobApplicantService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                jobApplicants: store.jobApplicants().filter((e) => (e as { id: number }).id !== id),
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
