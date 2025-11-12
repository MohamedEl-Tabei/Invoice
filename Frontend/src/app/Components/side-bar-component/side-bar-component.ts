import { Component, input } from '@angular/core';
import { ApiResponse } from '../../Interfaces/api-response';
import { Category } from '../../Interfaces/category';
import { CategoryService } from '../../Services/category-service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-side-bar-component',
  imports: [AsyncPipe],
  templateUrl: './side-bar-component.html',
  styleUrl: './side-bar-component.css'
})
export class SideBarComponent {
  categories$!:Observable<ApiResponse<Category[]>>
  constructor(private categoryService:CategoryService){}
  ngOnInit(){
    this.categories$=this.categoryService.getAll();
  }
}
