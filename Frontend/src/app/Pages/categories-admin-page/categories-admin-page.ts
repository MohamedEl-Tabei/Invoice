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
  isLoading$!:Observable<boolean>
  newCategoryName:string=""
  constructor(private categoryService: CategoryService,public loaderService:LoaderService) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAllForAdmin()
    this.isLoading$ =this.loaderService.isLoading$
  }
  add(event:Event){

  }
}
