import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolLibraryItem, CreateSchoolLibraryItemDto, UpdateSchoolLibraryItemDto } from '../models/school-library-item';
import { SchoolLibraryItemService } from '../services/school-library-item.service';

interface SchoolLibraryItemState {
  schoolLibraryItems: SchoolLibraryItem[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolLibraryItemState = {
  schoolLibraryItems: [],
  isLoading: false,
  error: null,
};

export const SchoolLibraryItemStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolLibraryItemService = inject(SchoolLibraryItemService)) => ({
    loadAllSchoolLibraryItems: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolLibraryItemService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolLibraryItems: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolLibraryItem: rxMethod<CreateSchoolLibraryItemDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolLibraryItemService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolLibraryItems: [...store.schoolLibraryItems(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
