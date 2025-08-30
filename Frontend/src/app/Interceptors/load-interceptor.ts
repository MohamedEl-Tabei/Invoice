import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoaderService } from '../Services/loader-service';
import { finalize } from 'rxjs';

export const loadInterceptor: HttpInterceptorFn = (req, next) => {
  const loaderService = inject(LoaderService)
  loaderService.isLoading$.next(true)
  return next(req).pipe(
    finalize(() => loaderService.isLoading$.next(false))
  );
};
