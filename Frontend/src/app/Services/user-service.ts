import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { UserLoginByEmail } from '../Interfaces/DTOs/user-login-by-email';
import { Observable, tap } from 'rxjs';
import { ApiResponse } from '../Interfaces/DTOs/api-response';
import { Constants } from '../Constants';
import { UserLoginByName } from '../Interfaces/DTOs/user-login-by-name';
import { UserLoginByPhone } from '../Interfaces/DTOs/user-login-by-phone';
import { User } from '../Interfaces/Models/user';
import { UserSignup } from '../Interfaces/DTOs/user-signup';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }
  public userSignal = signal<User>({
    userName: '',
    role: Constants.Roles.Customer,
    token: '',
    isAuthenticated: false
  })
  //#region sign up
  signUp(data: UserSignup): Observable<ApiResponse<User>> {
    return this.http.post<ApiResponse<User>>(`${Constants.API_URL}User/register`, data).pipe(
      tap(
        (response) => {
          this.userSignal.set({ ...response.data, isAuthenticated: true })
        }
      ))
  }
  //#endregion
  //#region login
  private afterLogin(response: ApiResponse<User>, rememberMe: boolean) {
    if (rememberMe) localStorage.setItem(Constants.localStorageKey.token, response.data.token)
    else sessionStorage.setItem(Constants.localStorageKey.token, response.data.token)
    this.userSignal.set({ ...response.data, isAuthenticated: true })
  }
  loginByEmail(data: UserLoginByEmail): Observable<ApiResponse<User>> {
    return this.http.post<ApiResponse<User>>(`${Constants.API_URL}User/login/email`, data).pipe(
      tap((response) => this.afterLogin(response, data.rememberMe)),
    );
  }
  loginByPhone(data: UserLoginByPhone): Observable<ApiResponse<User>> {
    return this.http.post<ApiResponse<User>>(`${Constants.API_URL}User/login/phone`, data).pipe(
      tap((response) => this.afterLogin(response, data.rememberMe)),
    );
  }
  loginByUsername(data: UserLoginByName): Observable<ApiResponse<User>> {
    return this.http.post<ApiResponse<User>>(`${Constants.API_URL}User/login/username`, data).pipe(
      tap((response) => this.afterLogin(response, data.rememberMe)),
    );
  }
  //#endregion
}
