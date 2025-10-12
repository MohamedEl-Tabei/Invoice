import { Component } from '@angular/core';
import { ScreenService } from '../../Services/screen-service';
import { CategoryService } from '../../Services/category-service';
import { Observable, shareReplay } from 'rxjs';
import { ApiResponse } from '../../Interfaces/api-response';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../Interfaces/category';
import { SubCategory } from '../../Interfaces/sub-category';
import { SubCategoryService } from '../../Services/sub-category-service';
import { UserService } from '../../Services/user-service';
import { Constants } from '../../Constants';
import { LoaderService } from '../../Services/loader-service';
import { CategoryUpdate } from '../../Interfaces/category-update';
import { FormsModule } from '@angular/forms';
import { ButtonComponent } from "../button-component/button-component";

@Component({
  selector: 'app-sub-categories-side-bar-component',
  imports: [AsyncPipe, FormsModule, ButtonComponent],
  templateUrl: './sub-categories-side-bar-component.html',
  styleUrl: './sub-categories-side-bar-component.css'
})
export class SubCategoriesSideBarComponent {
  categories$!: Observable<ApiResponse<Category[]>>;
  subCategories$!: Observable<ApiResponse<SubCategory[]>>;
  categoryId: string = '';
  isAdmin: boolean = false;
  onEdit: boolean = false;
  onDelete: boolean = false;
  onAdd: boolean = false;
  validSubCategory: boolean = true;
  categoryUpdate: CategoryUpdate = { concurrencyStamp: '', id: '', newName: '', oldName: '' };
  constructor(public screenService: ScreenService, private subCategoryService: SubCategoryService, private categoryService: CategoryService, private activedRoute: ActivatedRoute, private router: Router, public userService: UserService, public loaderService: LoaderService) { }
  ngOnInit() {
    this.userService.athenticatedUser$.subscribe(user => {
      this.isAdmin = user && user?.role === Constants.Roles.Admin;
    });
    this.categories$ = this.categoryService.getAll();
    this.activedRoute.queryParams.subscribe(p => {
      this.categoryId = p['id'];
      this.subCategories$ = this.subCategoryService.getSubCategoriesByCategoryId(this.categoryId).pipe(shareReplay(1));
    });
  }
  onAccordionClick(categoryId: string) {
    if (this.categoryId !== categoryId) {
      this.router.navigate([`/admin/categories/details`], { queryParams: { id: categoryId } })
      this.categoryId = categoryId;
    }
  }
  toggleEdit(isOn: boolean) {
    this.onEdit = isOn;
  }
  toggleDelete(isOn: boolean) {
    this.onDelete = isOn;
  }
  toggleAdd(isOn: boolean) {
    this.onAdd = isOn;
  }
  checkSubCategory() {}
  deleteSubCategory(event:Event) {}
  updateSubCategory(event:Event) {}
  addSubCategory(event:Event) {}
}
