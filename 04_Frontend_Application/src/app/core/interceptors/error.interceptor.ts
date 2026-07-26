import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { ProblemDetails } from '../models/problem-details.model';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      let problemDetails: ProblemDetails = {
        status: error.status,
        title: 'Unexpected Error',
        detail: error.message
      };

      if (error.error && typeof error.error === 'object') {
        const backendError = error.error as ProblemDetails;
        if (backendError.status || backendError.title || backendError.errors) {
          problemDetails = backendError;
        }
      }

      console.error('API Error Intercepted:', problemDetails);
      return throwError(() => problemDetails);
    })
  );
};
