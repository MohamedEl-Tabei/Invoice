import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { Constants } from '../Constants';
import { Observable, shareReplay } from 'rxjs';
import { ApiResponse } from '../Interfaces/DTOs/api-response';
import { CategoryUpdate } from '../Interfaces/DTOs/category-update';
import { CategoryDelete } from '../Interfaces/DTOs/category-delete';
import { Category } from '../Interfaces/Models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private httpClient: HttpClient) { }
  selectedCategoryId = signal<string>('');
  getAll(): Observable<ApiResponse<Category[]>> {
    return this.httpClient.get<ApiResponse<Category[]>>(`${Constants.API_URL}category/getAll`).pipe(shareReplay(1));
  }
  addNewCategory(name: string): Observable<ApiResponse<string>> {
    return this.httpClient.post<ApiResponse<string>>(`${Constants.API_URL}category/create`, { name })
  }
  getById(id: string): Observable<ApiResponse<Category>> {
    return this.httpClient.get<ApiResponse<Category>>(`${Constants.API_URL}category/get`, { params: { id } })
  }
  updateCategory(category: CategoryUpdate): Observable<ApiResponse<string>> {
    return this.httpClient.put<ApiResponse<string>>(`${Constants.API_URL}category/admin/update`, category)
  }
  deleteCategory(category: CategoryDelete): Observable<ApiResponse<string>> {
    return this.httpClient.delete<ApiResponse<string>>(`${Constants.API_URL}category/admin/delete`, { params: { ...category } }).pipe(shareReplay(1));
  }
}
