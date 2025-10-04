import { Component } from '@angular/core';
import { ScreenService } from '../../Services/screen-service';
import { CategoryService } from '../../Services/category-service';
import { Observable } from 'rxjs';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { ApiResponse } from '../../Interfaces/api-response';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sub-categories-side-bar-component',
  imports: [AsyncPipe],
  templateUrl: './sub-categories-side-bar-component.html',
  styleUrl: './sub-categories-side-bar-component.css'
})
export class SubCategoriesSideBarComponent {
  categories$!: Observable<ApiResponse<CategoryForAdmin[]>>;
  categoryId: string = '';
  constructor(public screenService: ScreenService, private categoryService: CategoryService, private activedRoute: ActivatedRoute, private router: Router) { }
  ngOnInit() {
    this.categories$ = this.categoryService.getAllForAdmin();
    this.activedRoute.queryParams.subscribe(p => {
      this.categoryId = p['id'];
    });
  }
  onAccordionClick(categoryId: string) {
    this.router.navigate([`/admin/categories/details`], { queryParams: { id: categoryId } })
    this.categoryId = categoryId;
  }

}
