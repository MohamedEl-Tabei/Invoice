import { Component } from '@angular/core';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-details-admin-page',
  imports: [],
  templateUrl: './category-details-admin-page.html',
  styleUrl: './category-details-admin-page.css'
})
export class CategoryDetailsAdminPage {
  category!: CategoryForAdmin;
  constructor(private activeRoute: ActivatedRoute) {
    this.activeRoute.queryParams.subscribe(p => {
      this.category = {
        id: p['id'],
        name: p['name'],
        concurrencyStamp: p['concurrencyStamp']
      }
    });
  }
}
