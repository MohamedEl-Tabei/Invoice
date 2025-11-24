import { AsyncPipe } from '@angular/common';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../Interfaces/DTOs/api-response';
import { SubCategory } from '../../../Interfaces/sub-category';
import { LoaderComponent } from "../../../Components/loader-component/loader-component";
import { LoaderService } from '../../../Services/loader-service';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { FormsModule } from '@angular/forms';
import { InputDirective } from '../../../Directives/input-directive';
import { SubCategoryService } from '../../../Services/sub-category-service';
import { Category } from '../../../Interfaces/Models/category';
import { CategoryService } from '../../../Services/category-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sub-categories-admin-page',
  imports: [AsyncPipe, LoaderComponent, ButtonComponent, FormsModule, InputDirective],
  templateUrl: './sub-categories-admin-page.html',
  styleUrl: './sub-categories-admin-page.css'
})
export class SubCategoriesAdminPage {
  subcategories$!: Observable<ApiResponse<SubCategory[]>>;
  categories$!: Observable<ApiResponse<Category[]>>;
  mounted: boolean = false;
  selectedCategoryId: string = "";
  newSubcategoryName: string = '';
  disabled: boolean = true;
  constructor(public loaderService: LoaderService, private subCategoryService: SubCategoryService, private categoryService: CategoryService, private router: Router) {

  }
  ngOnInit() {
    this.mounted = true;
    this.categories$ = this.categoryService.getAll();
    if (this.categoryService.selectedCategoryId()) {
      this.selectedCategoryId = this.categoryService.selectedCategoryId();
      this.subcategories$ = this.subCategoryService.getSubCategoriesByCategoryId(this.selectedCategoryId)
    }
  }

  toSubcategoryDetails(subcategory: SubCategory) {
    // Navigation logic to subcategory details page 
    this.router.navigate([`/admin/subcategories/details`], { queryParams: { id: subcategory.id } });
  }
  selectCategory() {
    this.subcategories$ = this.subCategoryService.getSubCategoriesByCategoryId(this.selectedCategoryId)
    this.categoryService.selectedCategoryId.set(this.selectedCategoryId);

  }
  create(event: Event) { }
  checkSubcategoryName() { }
}
