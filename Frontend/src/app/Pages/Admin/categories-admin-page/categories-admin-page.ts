import { Component } from '@angular/core';
import { CategoryService } from '../../../Services/category-service';
import { InputDirective } from '../../../Directives/input-directive';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { ApiResponse } from '../../../Interfaces/api-response';
import { FormsModule } from "@angular/forms";
import { LoaderService } from '../../../Services/loader-service';
import { LoaderComponent } from "../../../Components/loader-component/loader-component";
import { ToastrService } from "ngx-toastr"
import { Constants } from '../../../Constants';
import { Router } from '@angular/router';
import { Category } from '../../../Interfaces/category';
import { ButtonComponent } from "../../../Components/button-component/button-component";

@Component({
  selector: 'app-categories-admin-page',
  imports: [InputDirective, AsyncPipe, FormsModule, LoaderComponent, ButtonComponent],
  templateUrl: './categories-admin-page.html',
  styleUrl: './categories-admin-page.css'
})
export class CategoriesAdminPage {
  categories$!: Observable<ApiResponse<Category[]>>
  newCategoryName: string = ""
  disabled: boolean = true
  constructor(private categoryService: CategoryService, public router: Router, public loaderService: LoaderService, private toastrService: ToastrService) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAll()
  }
  create(event: Event) {
    let name = this.newCategoryName.trim();
    event.preventDefault();
    if (this.newCategoryName.trim().length != 0)
      this.categoryService.addNewCategory(this.newCategoryName).subscribe(
        {
          next: (res) => {
            this.categories$ = this.categoryService.getAll()
            this.toastrService.success(res.data, '', Constants.toastrConfig)
          },
        });
    this.newCategoryName = ""
    this.disabled = true

  }
  checkCategoryName() {
    if (this.newCategoryName.length && !/^[a-z A-Z]+$/.test(this.newCategoryName)) {
      this.toastrService.error("Category name can only contain letters and spaces", '', Constants.toastrConfig);
      this.disabled = true
    }
    else {
      this.disabled = false
    }
  }
  toCategoryDetails(category: Category) {
    this.router.navigate([`/admin/categories/details`], { queryParams: { id: category.id } })
  }
  
}
