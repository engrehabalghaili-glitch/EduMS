import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { EmployeePayrollFinancialContract, CreateEmployeePayrollFinancialContract, UpdateEmployeePayrollFinancialContract } from '../models/employee-payroll-financial-contract.types';
import { EmployeePayrollFinancialContractService } from '../services/employee-payroll-financial-contract.service';

interface EmployeePayrollFinancialContractState {
  employeePayrollFinancialContracts: EmployeePayrollFinancialContract[];
  isLoading: boolean;
  error: string | null;
}

const initialState: EmployeePayrollFinancialContractState = {
  employeePayrollFinancialContracts: [],
  isLoading: false,
  error: null,
};

export const EmployeePayrollFinancialContractStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, employeePayrollFinancialContractService = inject(EmployeePayrollFinancialContractService)) => ({
    loadAllEmployeePayrollFinancialContracts: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          employeePayrollFinancialContractService.getAll().pipe(
            tapResponse({
              next: (employeePayrollFinancialContracts) => patchState(store, { employeePayrollFinancialContracts, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewEmployeePayrollFinancialContract: rxMethod<CreateEmployeePayrollFinancialContract>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          employeePayrollFinancialContractService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { employeePayrollFinancialContracts: [...store.employeePayrollFinancialContracts(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateEmployeePayrollFinancialContract: rxMethod<{ id: number; dto: UpdateEmployeePayrollFinancialContract }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          employeePayrollFinancialContractService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                employeePayrollFinancialContracts: store.employeePayrollFinancialContracts().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteEmployeePayrollFinancialContract: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          employeePayrollFinancialContractService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                employeePayrollFinancialContracts: store.employeePayrollFinancialContracts().filter((e) => (e as { id: number }).id !== id),
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
