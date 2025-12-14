import { AsyncPipe } from '@angular/common';
import { Component } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ApiResponse } from '../../../Interfaces/DTOs/api-response';
import { SubCategory } from '../../../Interfaces/Models/sub-category';
import { LoaderComponent } from "../../../Components/loader-component/loader-component";
import { LoaderService } from '../../../Services/loader-service';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputDirective } from '../../../Directives/input-directive';
import { SubCategoryService } from '../../../Services/sub-category-service';
import { Category } from '../../../Interfaces/Models/category';
import { CategoryService } from '../../../Services/category-service';
import { Router } from '@angular/router';
import { Constants } from '../../../Constants';
import { SubcategoryForm } from '../../../Interfaces/Forms/subcategory-form';
import { SubcategoryCreate } from '../../../Interfaces/DTOs/subcategory-create';
import { ToastrService } from 'ngx-toastr';
import { AppValidators } from '../../../Validators';

@Component({
  selector: 'app-sub-categories-admin-page',
  imports: [AsyncPipe, LoaderComponent, ButtonComponent, FormsModule, InputDirective, ReactiveFormsModule],
  templateUrl: './sub-categories-admin-page.html',
  styleUrl: './sub-categories-admin-page.css'
})
export class SubCategoriesAdminPage {
  //#region subscriptions
  createSubCategorySubscription: Subscription | undefined;
  //#endregion
  //#region observables 
  subcategories$!: Observable<ApiResponse<SubCategory[]>>;
  categories$!: Observable<ApiResponse<Category[]>>;
  //#endregion
  //#region Form group
  subcategoryForm = new FormGroup<SubcategoryForm>({
    name: new FormControl<string>('', { nonNullable: true, validators: AppValidators.subcategoryName }),
    categoryId: new FormControl<string>('', { nonNullable: true })
  });
  //#endregion
  mounted: boolean = false;

  constructor(public loaderService: LoaderService, private toastrService: ToastrService, private subCategoryService: SubCategoryService, private categoryService: CategoryService, private router: Router) {

  }
  //#region  Lifecycle 
  ngOnInit() {
    this.mounted = true;
    this.categories$ = this.categoryService.getAll();
    let selectedCategoryId = this.categoryService.selectedCategoryId() || sessionStorage.getItem(Constants.localStorageKey.selectedCategoryId)?.toString() || '';;

    if (selectedCategoryId) {
      this.subcategoryForm.controls.categoryId.setValue(selectedCategoryId);
      this.subcategories$ = this.subCategoryService.getSubCategoriesByCategoryId(selectedCategoryId)
    }

  }
  ngOnDestroy() {
    this.createSubCategorySubscription?.unsubscribe();
  }
  //#endregion
  //#region navigation  
  toSubcategoryDetails(subcategory: SubCategory) {
    // Navigation logic to subcategory details page 
    this.router.navigate([Constants.Routes.admin.subcategoryDetails], { queryParams: { id: subcategory.id } });
  }
  //#endregion
  //#region on select category 
  selectCategory() {
    const selectedCategoryId = this.subcategoryForm.controls.categoryId.value;
    this.subcategories$ = this.subCategoryService.getSubCategoriesByCategoryId(selectedCategoryId);
    this.categoryService.selectedCategoryId.set(selectedCategoryId);
    sessionStorage.setItem(Constants.localStorageKey.selectedCategoryId, selectedCategoryId);

  }
  //#endregion
  //#region create subcategory
  create(event: Event) {
    event.preventDefault();
    if (this.subcategoryForm.valid) {
      const newSubCategory: SubcategoryCreate = {
        name: this.subcategoryForm.controls.name.value,
        categoryId: this.subcategoryForm.controls.categoryId.value
      };
      this.createSubCategorySubscription = this.subCategoryService.createSubCategory(newSubCategory).subscribe(
        {
          next: (response) => {
            this.subcategories$ = this.subCategoryService.getSubCategoriesByCategoryId(newSubCategory.categoryId);
            this.toastrService.success(`subcategory "${newSubCategory.name}" created`, '', Constants.toastrConfig)
            this.subcategoryForm.reset();
            this.subcategoryForm.controls.categoryId.setValue(newSubCategory.categoryId);
          }
        }
      )
    }
    else {
      this.toastrService.error("subcategory name can only contain letters and spaces", '', { ...Constants.toastrConfig, disableTimeOut: true, closeButton: true });
    }
  }
  //#endregion

}
