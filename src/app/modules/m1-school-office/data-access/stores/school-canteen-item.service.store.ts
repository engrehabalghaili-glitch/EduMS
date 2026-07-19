import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { SchoolCanteenItem, CreateSchoolCanteenItemDto, UpdateSchoolCanteenItemDto } from '../models/school-canteen-item';
import { SchoolCanteenItemService } from '../services/school-canteen-item.service';

interface SchoolCanteenItemState {
  schoolCanteenItems: SchoolCanteenItem[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SchoolCanteenItemState = {
  schoolCanteenItems: [],
  isLoading: false,
  error: null,
};

export const SchoolCanteenItemStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, schoolCanteenItemService = inject(SchoolCanteenItemService)) => ({
    loadAllSchoolCanteenItems: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          schoolCanteenItemService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { schoolCanteenItems: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewSchoolCanteenItem: rxMethod<CreateSchoolCanteenItemDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          schoolCanteenItemService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { schoolCanteenItems: [...store.schoolCanteenItems(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
