import { Component } from '@angular/core';
import { CategoryService } from '../../Services/category-service';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { InputDirective } from '../../Directives/input-directive';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { ApiResponse } from '../../Interfaces/api-response';
import { FormsModule } from "@angular/forms";
import { LoaderService } from '../../Services/loader-service';
import { LoaderComponent } from "../../Components/loader-component/loader-component";

@Component({
  selector: 'app-categories-admin-page',
  imports: [InputDirective, AsyncPipe, FormsModule, LoaderComponent],
  templateUrl: './categories-admin-page.html',
  styleUrl: './categories-admin-page.css'
})
export class CategoriesAdminPage {
  categories$!: Observable<ApiResponse<CategoryForAdmin[]>>
  isLoading$!: Observable<boolean>
  newCategoryName: string = ""
  serverMessage: string = ""
  alertClass: string = "alert"
  
  constructor(private categoryService: CategoryService, public loaderService: LoaderService) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAllForAdmin()
    this.isLoading$ = this.loaderService.isLoading$
  }
  create(event: Event) {
    event.preventDefault();
    if (this.newCategoryName.trim().length != 0)
      this.categoryService.addNewCategory(this.newCategoryName).subscribe(
        {
          next: (res) => {
            this.categories$ = this.categoryService.getAllForAdmin()
            this.serverMessage = res.data
            this.alertClass = "alert alert-success"
          },
          error: (err) => {
            this.serverMessage = err.error.errors[0].message;
            this.alertClass = "alert alert-danger"
          }
        });
    this.newCategoryName = ""
  }
  clearAlert() {
    this.alertClass = "alert"
    this.serverMessage = ""
    if (this.newCategoryName.length && !/^[a-z A-Z]+$/.test(this.newCategoryName)) {
      this.alertClass = "alert alert-danger"
      this.serverMessage = "Category name can only contain letters and spaces"
    }
  }

}
