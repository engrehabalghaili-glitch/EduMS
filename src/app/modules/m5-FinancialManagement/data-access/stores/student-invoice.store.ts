import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { StudentInvoiceService } from '../services/student-invoice.service';
import type { StudentInvoice, CreateStudentInvoiceDto, UpdateStudentInvoiceDto } from '../models/student-invoice.interface';

interface StudentInvoiceState {
  studentInvoices: StudentInvoice[];
  isLoading: boolean;
  error: string | null;
}

const initialState: StudentInvoiceState = {
  studentInvoices: [],
  isLoading: false,
  error: null,
};

export const StudentInvoiceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, studentInvoiceService = inject(StudentInvoiceService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            studentInvoiceService.getAll().pipe(
              tapResponse({
                next: (studentInvoices: StudentInvoice[]) =>
                  patchState(store, { studentInvoices, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewStudentInvoice: rxMethod<CreateStudentInvoiceDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            studentInvoiceService.create(dto).pipe(
              tapResponse({
                next: (entity: StudentInvoice) =>
                  patchState(store, {
                    studentInvoices: [...store.studentInvoices(), entity],
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

      updateStudentInvoice: rxMethod<{ id: number; dto: UpdateStudentInvoiceDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            studentInvoiceService.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentInvoice) =>
                  patchState(store, {
                    studentInvoices: store
                      .studentInvoices()
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

      removeStudentInvoice: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            studentInvoiceService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentInvoices: store.studentInvoices().filter((e) => e.id !== id),
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
