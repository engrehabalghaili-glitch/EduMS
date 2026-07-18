import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { Department, CreateDepartmentDto, UpdateDepartmentDto } from '../models/department';
import { DepartmentService } from '../services/department.service';

interface DepartmentState {
  departments: Department[];
  isLoading: boolean;
  error: string | null;
}

const initialState: DepartmentState = {
  departments: [],
  isLoading: false,
  error: null,
};

export const DepartmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, departmentService = inject(DepartmentService)) => ({
    loadAllDepartments: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          departmentService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { departments: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewDepartment: rxMethod<CreateDepartmentDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          departmentService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { departments: [...store.departments(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
