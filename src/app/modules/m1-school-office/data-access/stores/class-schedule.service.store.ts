import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { ClassSchedule, CreateClassScheduleDto, UpdateClassScheduleDto } from '../models/class-schedule';
import { ClassScheduleService } from '../services/class-schedule.service';

interface ClassScheduleState {
  classSchedules: ClassSchedule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ClassScheduleState = {
  classSchedules: [],
  isLoading: false,
  error: null,
};

export const ClassScheduleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, classScheduleService = inject(ClassScheduleService)) => ({
    loadAllClassSchedules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          classScheduleService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { classSchedules: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewClassSchedule: rxMethod<CreateClassScheduleDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          classScheduleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { classSchedules: [...store.classSchedules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
