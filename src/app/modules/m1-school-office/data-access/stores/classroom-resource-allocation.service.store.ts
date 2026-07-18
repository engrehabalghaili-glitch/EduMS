import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ClassroomResourceAllocation, CreateClassroomResourceAllocationDto, UpdateClassroomResourceAllocationDto } from '../models/classroom-resource-allocation';
import { ClassroomResourceAllocationService } from '../services/classroom-resource-allocation.service';

interface ClassroomResourceAllocationState {
  classroomResourceAllocations: ClassroomResourceAllocation[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ClassroomResourceAllocationState = {
  classroomResourceAllocations: [],
  isLoading: false,
  error: null,
};

export const ClassroomResourceAllocationStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, classroomResourceAllocationService = inject(ClassroomResourceAllocationService)) => ({
    loadAllClassroomResourceAllocations: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          classroomResourceAllocationService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { classroomResourceAllocations: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewClassroomResourceAllocation: rxMethod<CreateClassroomResourceAllocationDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          classroomResourceAllocationService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { classroomResourceAllocations: [...store.classroomResourceAllocations(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
