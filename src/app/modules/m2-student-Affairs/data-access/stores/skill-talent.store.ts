import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { SkillTalentService } from '../services/skill-talent.service';
import type { StudentSkillAndTalentRecord, CreateStudentSkillAndTalentRecord, UpdateStudentSkillAndTalentRecord } from '../models/skill-talent.interface';

interface SkillTalentState {
  studentSkillAndTalentRecords: StudentSkillAndTalentRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: SkillTalentState = {
  studentSkillAndTalentRecords: [],
  isLoading: false,
  error: null,
};

export const SkillTalentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(SkillTalentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentSkillAndTalentRecords: StudentSkillAndTalentRecord[]) =>
                  patchState(store, { studentSkillAndTalentRecords, isLoading: false }),
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
                next: (studentSkillAndTalentRecord: StudentSkillAndTalentRecord) =>
                  patchState(store, {
                    studentSkillAndTalentRecords: [...store.studentSkillAndTalentRecords(), studentSkillAndTalentRecord],
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
                next: (studentSkillAndTalentRecords: StudentSkillAndTalentRecord[]) =>
                  patchState(store, { studentSkillAndTalentRecords, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewSkillAndTalentRecord: rxMethod<CreateStudentSkillAndTalentRecord>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentSkillAndTalentRecord: StudentSkillAndTalentRecord) =>
                  patchState(store, {
                    studentSkillAndTalentRecords: [...store.studentSkillAndTalentRecords(), studentSkillAndTalentRecord],
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

      updateSkillAndTalentRecord: rxMethod<{ id: number; dto: UpdateStudentSkillAndTalentRecord }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentSkillAndTalentRecord) =>
                  patchState(store, {
                    studentSkillAndTalentRecords: store
                      .studentSkillAndTalentRecords()
                      .map((s) => (s.id === id ? updated : s)),
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

      removeSkillAndTalentRecord: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentSkillAndTalentRecords: store
                      .studentSkillAndTalentRecords()
                      .filter((s) => s.id !== id),
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
