import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ExtracurricularAchievementService } from '../services/extracurricular-achievement.service';
import type { StudentExtracurricularAchievement, CreateStudentExtracurricularAchievement, UpdateStudentExtracurricularAchievement } from '../models/extracurricular-achievement.interface';

interface ExtracurricularAchievementState {
  studentExtracurricularAchievements: StudentExtracurricularAchievement[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExtracurricularAchievementState = {
  studentExtracurricularAchievements: [],
  isLoading: false,
  error: null,
};

export const ExtracurricularAchievementStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(ExtracurricularAchievementService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentExtracurricularAchievements: StudentExtracurricularAchievement[]) =>
                  patchState(store, { studentExtracurricularAchievements, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadById: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.getById(id).pipe(
              tapResponse({
                next: (studentExtracurricularAchievement: StudentExtracurricularAchievement) =>
                  patchState(store, {
                    studentExtracurricularAchievements: [...store.studentExtracurricularAchievements(), studentExtracurricularAchievement],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByStudentId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((studentId) =>
            service.getByStudentId(studentId).pipe(
              tapResponse({
                next: (studentExtracurricularAchievements: StudentExtracurricularAchievement[]) =>
                  patchState(store, { studentExtracurricularAchievements, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewExtracurricularAchievement: rxMethod<CreateStudentExtracurricularAchievement>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentExtracurricularAchievement: StudentExtracurricularAchievement) =>
                  patchState(store, {
                    studentExtracurricularAchievements: [...store.studentExtracurricularAchievements(), studentExtracurricularAchievement],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateExtracurricularAchievement: rxMethod<{ id: number; dto: UpdateStudentExtracurricularAchievement }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentExtracurricularAchievement) =>
                  patchState(store, {
                    studentExtracurricularAchievements: store
                      .studentExtracurricularAchievements()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeExtracurricularAchievement: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentExtracurricularAchievements: store
                      .studentExtracurricularAchievements()
                      .filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
