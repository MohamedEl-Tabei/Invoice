import { Component } from '@angular/core';
import { CategoryService } from '../../Services/category-service';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { InputDirective } from '../../Directives/input-directive';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { ApiResponse } from '../../Interfaces/api-response';

@Component({
  selector: 'app-categories-admin-page',
  imports: [InputDirective,AsyncPipe],
  templateUrl: './categories-admin-page.html',
  styleUrl: './categories-admin-page.css'
})
export class CategoriesAdminPage {
  categories$!: Observable<ApiResponse<CategoryForAdmin[]>>
  constructor(private categoryService: CategoryService) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAllForAdmin()
  }
  
}
