import { HttpInterceptorFn } from '@angular/common/http';
import { Constants } from '../Constants';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  let token = localStorage.getItem(Constants.localStorageKey.token)
  if (!token) token = sessionStorage.getItem(Constants.localStorageKey.token)
  if (token) {
    const newRequest = req.clone(
      {
        setHeaders: {
          authorization: `Bearer ${token}`
        }
      }
    )
    return next(newRequest)
  }
  return next(req);
};
