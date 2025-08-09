import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../Constants';
import { Observable } from 'rxjs';
import { UserLoginByEmail } from '../Interfaces/user-login-by-email';
import { ApiResponse } from '../Interfaces/api-response';
import { UserAuthenticated } from '../Interfaces/user-authenticated';
@Injectable({
  providedIn: 'root'
})
export class User {
  constructor(private http: HttpClient) {}
  loginByEmail(data:UserLoginByEmail):Observable<ApiResponse<UserAuthenticated>>{
    return this.http.post<ApiResponse<UserAuthenticated>>(`${Constants.API_URL}User/login/email`, data);
  }
}
