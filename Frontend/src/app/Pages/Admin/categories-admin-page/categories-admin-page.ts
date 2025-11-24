import { Component } from '@angular/core';
import { CategoryService } from '../../../Services/category-service';
import { InputDirective } from '../../../Directives/input-directive';
import { Observable, Subscription } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { ApiResponse } from '../../../Interfaces/DTOs/api-response';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { LoaderService } from '../../../Services/loader-service';
import { LoaderComponent } from "../../../Components/loader-component/loader-component";
import { ToastrService } from "ngx-toastr"
import { Constants } from '../../../Constants';
import { Router } from '@angular/router';
import { Category } from '../../../Interfaces/Models/category';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { CategoryForm } from '../../../Interfaces/Forms/category-form';
import { AppValidators } from '../../../Validators';

@Component({
  selector: 'app-categories-admin-page',
  imports: [InputDirective, AsyncPipe, FormsModule, LoaderComponent, ButtonComponent, ReactiveFormsModule],
  templateUrl: './categories-admin-page.html',
  styleUrl: './categories-admin-page.css'
})
export class CategoriesAdminPage {
  categories$!: Observable<ApiResponse<Category[]>>
  createSubsription: Subscription | null = null;
  createForm = new FormGroup<CategoryForm>({
    name: new FormControl<string>('', { nonNullable: true, validators: AppValidators.categoryName })
  })
  constructor(private categoryService: CategoryService, public router: Router, public loaderService: LoaderService, private toastrService: ToastrService) { }
  //#region Lifecycle
  ngOnInit() {
    this.categories$ = this.categoryService.getAll()
  }
  ngOnDestroy() {
    this.createSubsription?.unsubscribe();
  }
  //#endregion
  //#region Create Category
  create(event: Event) {
    event.preventDefault();
    if (this.createForm.valid) {
      let data = this.createForm.getRawValue();
      this.createSubsription = this.categoryService.addNewCategory(data.name.trim()).subscribe(
        {
          next: (res) => {
            this.categories$ = this.categoryService.getAll()
            this.toastrService.success(res.data, '', Constants.toastrConfig)
            this.createForm.reset();
          },
        });
    }
    else
      this.toastrService.error("Category name can only contain letters and spaces", '', { ...Constants.toastrConfig, disableTimeOut: true, closeButton: true });
  }
  //#endregion
  //#region navigation
  toCategoryDetails(category: Category) {
    this.router.navigate([`/admin/categories/details`], { queryParams: { id: category.id } })
  }
  //#endregion

}
