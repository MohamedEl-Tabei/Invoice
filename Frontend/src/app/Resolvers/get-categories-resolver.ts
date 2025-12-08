import { ResolveFn } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Interfaces/DTOs/api-response';
import { Category } from '../Interfaces/Models/category';
import { CategoryService } from '../Services/category-service';
import { inject } from '@angular/core';

export const getCategoriesResolver: ResolveFn<Observable<ApiResponse<Category[]>>> = (route, state) => {
  const categoryService = inject(CategoryService);
  return (()=>categoryService.getAll())()
};
