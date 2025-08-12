import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLoginByEmail } from '../Interfaces/user-login-by-email';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { UserAuthenticated } from '../Interfaces/user-authenticated';
import { Constants } from '../Constants';
import { UserLoginByName } from '../Interfaces/user-login-by-name';
import { UserLoginByPhone } from '../Interfaces/user-login-by-phone';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}
  loginByEmail(data:UserLoginByEmail):Observable<ApiResponse<UserAuthenticated>>{
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/email`, data);
  }
  loginByPhone(data:UserLoginByPhone):Observable<ApiResponse<UserAuthenticated>>{
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/phone`, data);
  }
  loginByUsername(data:UserLoginByName):Observable<ApiResponse<UserAuthenticated>>{
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/username`, data);
  }
}
