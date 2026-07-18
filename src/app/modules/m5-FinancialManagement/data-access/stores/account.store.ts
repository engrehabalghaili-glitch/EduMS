import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AccountService } from '../services/account.service';
import type { Account, CreateAccountDto, UpdateAccountDto } from '../models/account.interface';

interface AccountState {
  accounts: Account[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AccountState = {
  accounts: [],
  isLoading: false,
  error: null,
};

export const AccountStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, accountService = inject(AccountService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            accountService.getAll().pipe(
              tapResponse({
                next: (accounts: Account[]) =>
                  patchState(store, { accounts, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAccount: rxMethod<CreateAccountDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            accountService.create(dto).pipe(
              tapResponse({
                next: (entity: Account) =>
                  patchState(store, {
                    accounts: [...store.accounts(), entity],
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

      updateAccount: rxMethod<{ id: number; dto: UpdateAccountDto }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            accountService.update(id, dto).pipe(
              tapResponse({
                next: (updated: Account) =>
                  patchState(store, {
                    accounts: store
                      .accounts()
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

      removeAccount: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            accountService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    accounts: store.accounts().filter((e) => e.id !== id),
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
