import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';

@Component({
  selector: 'app-category-details-page',
  imports: [],
  templateUrl: './category-details-page.html',
  styleUrl: './category-details-page.css'
})
export class CategoryDetailsPage {
  category!: CategoryForAdmin;
  constructor(private activeRoute: ActivatedRoute) {
    this.activeRoute.params.subscribe(p => {
      this.category = {
        id: p['id'],
        name: p['name'],
        concurrencyStamp: p['concurrencyStamp']
      }
    });
  }
}
