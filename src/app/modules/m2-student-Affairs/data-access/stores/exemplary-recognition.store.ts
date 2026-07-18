import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { ExemplaryRecognitionService } from '../services/exemplary-recognition.service';
import type { StudentExemplaryRecognition, CreateStudentExemplaryRecognition, UpdateStudentExemplaryRecognition } from '../models/exemplary-recognition.interface';

interface ExemplaryRecognitionState {
  studentExemplaryRecognitions: StudentExemplaryRecognition[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ExemplaryRecognitionState = {
  studentExemplaryRecognitions: [],
  isLoading: false,
  error: null,
};

export const ExemplaryRecognitionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(ExemplaryRecognitionService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentExemplaryRecognitions: StudentExemplaryRecognition[]) =>
                  patchState(store, { studentExemplaryRecognitions, isLoading: false }),
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
                next: (studentExemplaryRecognition: StudentExemplaryRecognition) =>
                  patchState(store, {
                    studentExemplaryRecognitions: [...store.studentExemplaryRecognitions(), studentExemplaryRecognition],
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
                next: (studentExemplaryRecognitions: StudentExemplaryRecognition[]) =>
                  patchState(store, { studentExemplaryRecognitions, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewExemplaryRecognition: rxMethod<CreateStudentExemplaryRecognition>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentExemplaryRecognition: StudentExemplaryRecognition) =>
                  patchState(store, {
                    studentExemplaryRecognitions: [...store.studentExemplaryRecognitions(), studentExemplaryRecognition],
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

      updateExemplaryRecognition: rxMethod<{ id: number; dto: UpdateStudentExemplaryRecognition }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentExemplaryRecognition) =>
                  patchState(store, {
                    studentExemplaryRecognitions: store
                      .studentExemplaryRecognitions()
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

      removeExemplaryRecognition: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentExemplaryRecognitions: store
                      .studentExemplaryRecognitions()
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
