import { Component } from '@angular/core';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { InputDirective } from '../../Directives/input-directive';

@Component({
  selector: 'app-category-details-admin-page',
  imports: [FormsModule,InputDirective],
  templateUrl: './category-details-admin-page.html',
  styleUrl: './category-details-admin-page.css'
})
export class CategoryDetailsAdminPage {
  category!: CategoryForAdmin;
  onEdit = false;
  constructor(private activeRoute: ActivatedRoute) {
    this.activeRoute.queryParams.subscribe(p => {
      this.category = {
        id: p['id'],
        name: p['name'],
        concurrencyStamp: p['concurrencyStamp']
      }
    });
  }
  toggleEdit(isOn: boolean) {
    this.onEdit = isOn;
  }
}
