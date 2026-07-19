import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeeInternalTransfer, CreateEmployeeInternalTransfer, UpdateEmployeeInternalTransfer } from '../models/employee-internal-transfer.types';
import { EmployeeInternalTransferService } from '../services/employee-internal-transfer.service';

interface EmployeeInternalTransferState {
  employeeInternalTransfers: EmployeeInternalTransfer[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeeInternalTransferState = {
  employeeInternalTransfers: [],
  isLoading: false,
  error: null,
};

export const EmployeeInternalTransferStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeeInternalTransferService = inject(EmployeeInternalTransferService)) => ({
    loadAllEmployeeInternalTransfers: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeeInternalTransferService.getAll().pipe(
            tapResponse({
              next: (employeeInternalTransfers) => patchState(store, { employeeInternalTransfers, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeeInternalTransfer: rxMethod<CreateEmployeeInternalTransfer>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeeInternalTransferService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeeInternalTransfers: [...store.employeeInternalTransfers(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeeInternalTransfer: rxMethod<{ id: number; dto: UpdateEmployeeInternalTransfer }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeeInternalTransferService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeeInternalTransfers: store.employeeInternalTransfers().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeeInternalTransfer: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeeInternalTransferService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeeInternalTransfers: store.employeeInternalTransfers().filter((e) => (e as { id: number }).id !== id),
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
