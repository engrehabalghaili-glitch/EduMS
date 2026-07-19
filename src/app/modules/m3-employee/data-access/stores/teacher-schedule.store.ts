import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { TeacherSchedule, CreateTeacherSchedule, UpdateTeacherSchedule } from '../models/teacher-schedule.types';
import { TeacherScheduleService } from '../services/teacher-schedule.service';

interface TeacherScheduleState {
  teacherSchedules: TeacherSchedule[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TeacherScheduleState = {
  teacherSchedules: [],
  isLoading: false,
  error: null,
};

export const TeacherScheduleStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, teacherScheduleService = inject(TeacherScheduleService)) => ({
    loadAllTeacherSchedules: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          teacherScheduleService.getAll().pipe(
            tapResponse({
              next: (teacherSchedules) => patchState(store, { teacherSchedules, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewTeacherSchedule: rxMethod<CreateTeacherSchedule>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          teacherScheduleService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { teacherSchedules: [...store.teacherSchedules(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateTeacherSchedule: rxMethod<{ id: number; dto: UpdateTeacherSchedule }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          teacherScheduleService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                teacherSchedules: store.teacherSchedules().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteTeacherSchedule: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          teacherScheduleService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                teacherSchedules: store.teacherSchedules().filter((e) => (e as { id: number }).id !== id),
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
