import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../Constants';
import { Observable, shareReplay } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { CategoryForAdmin } from '../Interfaces/category-for-admin';
import { CategoryUpdate } from '../Interfaces/category-update';
import { CategoryDelete } from '../Interfaces/category-delete';
import { Category } from '../Interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private httpClient: HttpClient) { }
  getAllForAdmin(): Observable<ApiResponse<CategoryForAdmin[]>> {
    return this.httpClient.get<ApiResponse<CategoryForAdmin[]>>(`${Constants.API_URL}category/admin/getAll`)
  }
  getAll(): Observable<ApiResponse<Category[]>> {
    return this.httpClient.get<ApiResponse<Category[]>>(`${Constants.API_URL}category/getAll`)
  }
  addNewCategory(name: string): Observable<ApiResponse<string>> {
    return this.httpClient.post<ApiResponse<string>>(`${Constants.API_URL}category/create`, { name })
  }
  getById(id: string): Observable<ApiResponse<CategoryForAdmin>> {
    return this.httpClient.get<ApiResponse<CategoryForAdmin>>(`${Constants.API_URL}category/admin/get`, { params: { id } }).pipe(shareReplay(1))
  }
  updateCategory(category: CategoryUpdate): Observable<ApiResponse<string>> {
    return this.httpClient.put<ApiResponse<string>>(`${Constants.API_URL}category/admin/update`, category)
  }
  deleteCategory(category:CategoryDelete):Observable<ApiResponse<string>>{
    return this.httpClient.delete<ApiResponse<string>>(`${Constants.API_URL}category/admin/delete`,{params:{...category}})
  }
}
