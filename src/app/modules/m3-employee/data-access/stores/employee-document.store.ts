import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeDocument, CreateEmployeeDocument, UpdateEmployeeDocument } from '../models/employee-document.types';
import { EmployeeDocumentService } from '../services/employee-document.service';

interface EmployeeDocumentState {
  employeeDocuments: EmployeeDocument[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeDocumentState = {
  employeeDocuments: [],
  isLoading: false,
  error: null,
};

export const EmployeeDocumentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeDocumentService = inject(EmployeeDocumentService)) => ({
    loadAllEmployeeDocuments: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeDocumentService.getAll().pipe(
            tapResponse({
              next: (employeeDocuments) => patchState(store, { employeeDocuments, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeDocument: rxMethod<CreateEmployeeDocument>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeDocumentService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeDocuments: [...store.employeeDocuments(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeDocument: rxMethod<{ id: number; dto: UpdateEmployeeDocument }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeDocumentService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeDocuments: store.employeeDocuments().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeDocument: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeDocumentService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeDocuments: store.employeeDocuments().filter((e) => (e as { id: number }).id !== id),
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
