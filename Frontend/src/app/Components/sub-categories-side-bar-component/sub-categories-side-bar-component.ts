import { Component } from '@angular/core';
import { ScreenService } from '../../Services/screen-service';
import { CategoryService } from '../../Services/category-service';
import { Observable, shareReplay } from 'rxjs';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { ApiResponse } from '../../Interfaces/api-response';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../Interfaces/category';
import { SubCategory } from '../../Interfaces/sub-category';
import { SubCategoryService } from '../../Services/sub-category-service';

@Component({
  selector: 'app-sub-categories-side-bar-component',
  imports: [AsyncPipe],
  templateUrl: './sub-categories-side-bar-component.html',
  styleUrl: './sub-categories-side-bar-component.css'
})
export class SubCategoriesSideBarComponent {
  categories$!: Observable<ApiResponse<Category[]>>;
  subCategories$!: Observable<ApiResponse<SubCategory[]>>;
  categoryId: string = '';
  constructor(public screenService: ScreenService, private subCategoryService: SubCategoryService, private categoryService: CategoryService, private activedRoute: ActivatedRoute, private router: Router) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAll();
    this.activedRoute.queryParams.subscribe(p => {
      this.categoryId = p['id'];
      this.subCategories$ = this.subCategoryService.getSubCategoriesByCategoryId(this.categoryId).pipe(shareReplay(1));
    });
  }
  onAccordionClick(categoryId: string) {
    this.router.navigate([`/admin/categories/details`], { queryParams: { id: categoryId } })
    this.categoryId = categoryId;
  }

}
