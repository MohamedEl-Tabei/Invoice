import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { catchError, throwError } from 'rxjs';
import { Constants } from '../Constants';

export const errorHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  const toastrService = inject(ToastrService);



  return next(req).pipe(
    catchError(
      (errorResponse: HttpErrorResponse) => {
        let message = 'An unexpected error occurred.';
        const status = errorResponse.status;
        if (status === 0)
          message = "Unable to connect to the server. Please check your internet connection.";
        else if (status >= 500)
          message = "A server error occurred. Please try again later.";
        else if (status === 401)
          message = "You are not authorized to perform this action.";
        else if (status === 403)
          message = "Access to this resource is forbidden.";
        else {
          for (let i = 0; i < errorResponse.error.errors.length; i++)
            toastrService.error(errorResponse.error.errors[i].message, '', {...Constants.toastrConfig,closeButton: true,disableTimeOut: true});
          return throwError(() => errorResponse);
        }
        toastrService.error(message, '', Constants.toastrConfig);
        return throwError(() => errorResponse);
      }
    )
  );
};
