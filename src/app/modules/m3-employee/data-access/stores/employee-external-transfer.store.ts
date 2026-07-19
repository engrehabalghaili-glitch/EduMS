import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeExternalTransfer, CreateEmployeeExternalTransfer, UpdateEmployeeExternalTransfer } from '../models/employee-external-transfer.types';
import { EmployeeExternalTransferService } from '../services/employee-external-transfer.service';

interface EmployeeExternalTransferState {
  employeeExternalTransfers: EmployeeExternalTransfer[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeExternalTransferState = {
  employeeExternalTransfers: [],
  isLoading: false,
  error: null,
};

export const EmployeeExternalTransferStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeExternalTransferService = inject(EmployeeExternalTransferService)) => ({
    loadAllEmployeeExternalTransfers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeExternalTransferService.getAll().pipe(
            tapResponse({
              next: (employeeExternalTransfers) => patchState(store, { employeeExternalTransfers, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeExternalTransfer: rxMethod<CreateEmployeeExternalTransfer>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeExternalTransferService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeExternalTransfers: [...store.employeeExternalTransfers(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeExternalTransfer: rxMethod<{ id: number; dto: UpdateEmployeeExternalTransfer }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeExternalTransferService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeExternalTransfers: store.employeeExternalTransfers().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeExternalTransfer: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeExternalTransferService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeExternalTransfers: store.employeeExternalTransfers().filter((e) => (e as { id: number }).id !== id),
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
