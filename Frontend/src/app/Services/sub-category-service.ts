import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants } from '../Constants';
import { Observable, shareReplay } from 'rxjs';
import { ApiResponse } from '../Interfaces/api-response';
import { SubCategory } from '../Interfaces/sub-category';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {
  path: string = Constants.API_URL + 'SubCategory/';
  constructor(private httpClient: HttpClient) { }
  getSubCategoriesByCategoryId(categoryId: string): Observable<ApiResponse<SubCategory[]>> {
    return this.httpClient.get<ApiResponse<SubCategory[]>>(this.path + `getByCategoryId/${categoryId}`).pipe(shareReplay(1));
  }
}
