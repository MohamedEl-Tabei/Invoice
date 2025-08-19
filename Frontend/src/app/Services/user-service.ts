import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLoginByEmail } from '../Interfaces/user-login-by-email';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { UserAuthenticated } from '../Interfaces/user-authenticated';
import { Constants } from '../Constants';
import { UserLoginByName } from '../Interfaces/user-login-by-name';
import { UserLoginByPhone } from '../Interfaces/user-login-by-phone';
import { UserSignup } from '../Interfaces/user-signup';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }
  public athenticatedUser$: BehaviorSubject<UserAuthenticated | false> = new BehaviorSubject<UserAuthenticated | false>(false)

  //#region sign up
  signUp(data: UserSignup): Observable<ApiResponse<UserAuthenticated>> {
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/register`, data).pipe(
      tap((response) => {
        this.athenticatedUser$.next(response.data)
      })
    )
  }
  //#endregion
  //#region login
  private afterLoginTap(response: ApiResponse<UserAuthenticated>, rememberMe: boolean) {
    if (rememberMe) localStorage.setItem(Constants.localStorageKey.token, response.data.token)
    else sessionStorage.setItem(Constants.localStorageKey.token, response.data.token)
    this.athenticatedUser$.next(response.data)
  }
  loginByEmail(data: UserLoginByEmail): Observable<ApiResponse<UserAuthenticated>> {
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/email`, data).pipe(
      tap((response) => this.afterLoginTap(response, data.rememberMe)),
    );
  }
  loginByPhone(data: UserLoginByPhone): Observable<ApiResponse<UserAuthenticated>> {
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/phone`, data).pipe(
      tap((response) => this.afterLoginTap(response, data.rememberMe)),
    );
  }
  loginByUsername(data: UserLoginByName): Observable<ApiResponse<UserAuthenticated>> {
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/username`, data).pipe(
      tap((response) => this.afterLoginTap(response, data.rememberMe)),
    );
  }
  //#endregion
}
