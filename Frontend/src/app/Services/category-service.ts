import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../Constants';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { CategoryForAdmin } from '../Interfaces/category-for-admin';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private httpClient: HttpClient) { }
  getAllForAdmin(): Observable<ApiResponse<CategoryForAdmin[]>> {
    var token = localStorage.getItem(Constants.localStorageKey.token) || null
    if (!token) token = sessionStorage.getItem(Constants.localStorageKey.token)
    return this.httpClient.get<ApiResponse<CategoryForAdmin[]>>(`${Constants.API_URL}category/admin/getAll`, {
      headers: {
        authorization: `Bearer ${token}`
      }
    })
  }
}
