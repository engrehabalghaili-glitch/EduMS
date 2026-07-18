import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { MedicalAllergyService } from '../services/medical-allergy.service';
import type { StudentMedicalAllergyLog, CreateStudentMedicalAllergyLog, UpdateStudentMedicalAllergyLog } from '../models/medical-allergy.interface';

interface MedicalAllergyState {
  studentMedicalAllergyLogs: StudentMedicalAllergyLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: MedicalAllergyState = {
  studentMedicalAllergyLogs: [],
  isLoading: false,
  error: null,
};

export const MedicalAllergyStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(MedicalAllergyService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentMedicalAllergyLogs: StudentMedicalAllergyLog[]) =>
                  patchState(store, { studentMedicalAllergyLogs, isLoading: false }),
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
                next: (studentMedicalAllergyLog: StudentMedicalAllergyLog) =>
                  patchState(store, {
                    studentMedicalAllergyLogs: [...store.studentMedicalAllergyLogs(), studentMedicalAllergyLog],
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
                next: (studentMedicalAllergyLogs: StudentMedicalAllergyLog[]) =>
                  patchState(store, { studentMedicalAllergyLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewMedicalAllergyLog: rxMethod<CreateStudentMedicalAllergyLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentMedicalAllergyLog: StudentMedicalAllergyLog) =>
                  patchState(store, {
                    studentMedicalAllergyLogs: [...store.studentMedicalAllergyLogs(), studentMedicalAllergyLog],
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

      updateMedicalAllergyLog: rxMethod<{ id: number; dto: UpdateStudentMedicalAllergyLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentMedicalAllergyLog) =>
                  patchState(store, {
                    studentMedicalAllergyLogs: store
                      .studentMedicalAllergyLogs()
                      .map((m) => (m.id === id ? updated : m)),
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

      removeMedicalAllergyLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentMedicalAllergyLogs: store
                      .studentMedicalAllergyLogs()
                      .filter((m) => m.id !== id),
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
