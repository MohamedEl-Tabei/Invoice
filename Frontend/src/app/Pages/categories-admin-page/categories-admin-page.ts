import { Component } from '@angular/core';
import { CategoryService } from '../../Services/category-service';
import { CategoryForAdmin } from '../../Interfaces/category-for-admin';

@Component({
  selector: 'app-categories-admin-page',
  imports: [],
  templateUrl: './categories-admin-page.html',
  styleUrl: './categories-admin-page.css'
})
export class CategoriesAdminPage {
  categories!: CategoryForAdmin[] 
  constructor(private categoryService: CategoryService) { }
  ngOnInit(){
    this.categoryService.getAllForAdmin().subscribe({
      next:(response)=>this.categories=response.data
    })
  }

}
