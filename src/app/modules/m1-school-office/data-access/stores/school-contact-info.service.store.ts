import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolContactInfo, CreateSchoolContactInfoDto, UpdateSchoolContactInfoDto } from '../models/school-contact-info';
import { SchoolContactInfoService } from '../services/school-contact-info.service';

interface SchoolContactInfoState {
  schoolContactInfos: SchoolContactInfo[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolContactInfoState = {
  schoolContactInfos: [],
  isLoading: false,
  error: null,
};

export const SchoolContactInfoStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolContactInfoService = inject(SchoolContactInfoService)) => ({
    loadAllSchoolContactInfos: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolContactInfoService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolContactInfos: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolContactInfo: rxMethod<CreateSchoolContactInfoDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolContactInfoService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolContactInfos: [...store.schoolContactInfos(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
