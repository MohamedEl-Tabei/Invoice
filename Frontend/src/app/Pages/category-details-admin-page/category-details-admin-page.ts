import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { InputDirective } from '../../Directives/input-directive';
import { CategoryService } from '../../Services/category-service';
import { CategoryUpdate } from '../../Interfaces/category-update';
import { ToastrService } from 'ngx-toastr';
import { Constants } from '../../Constants';
import { LoaderService } from '../../Services/loader-service';
import { CategoryDelete } from '../../Interfaces/category-delete';
import { ScreenService } from '../../Services/screen-service';
import { Subscription, switchMap } from 'rxjs';

@Component({
  selector: 'app-category-details-admin-page',
  imports: [FormsModule, InputDirective,],
  templateUrl: './category-details-admin-page.html',
  styleUrl: './category-details-admin-page.css'
})
export class CategoryDetailsAdminPage {
  category: CategoryUpdate = { id: '', newName: '', oldName: '', concurrencyStamp: '' };
  validCategory = false;
  onEdit = false;
  onDelete = false;
  getByIdSubscription!: Subscription;
  constructor(private activeRoute: ActivatedRoute, public loaderService: LoaderService, private categoryService: CategoryService, private router: Router, private toastrService: ToastrService, public screenService: ScreenService) { }
  ngOnInit() {
    this.screenService.showSidebar.set(true)
    this.getByIdSubscription = this.activeRoute.queryParams.pipe(switchMap(p => {
      this.category.id = p['id'];
      return this.categoryService.getById(p['id'])
    }
    )).subscribe({
      next: (response) => {
        this.category.concurrencyStamp = response.data.concurrencyStamp;
        this.category.oldName = response.data.name;
        this.category.newName = response.data.name;
      },
      error: (err) => {
        this.router.navigate(['/NotFound']);
      }
    });


  }
  checkCategory() {
    if (!this.category.newName.trim().length || this.category.newName == this.category.oldName) this.validCategory = false;
    else if (!/^[a-z A-Z]+$/.test(this.category.newName)) {
      this.toastrService.error("Category name can only contain letters and spaces", '', Constants.toastrConfig);
      this.validCategory = false
    }
    else {
      this.validCategory = true
    }
  }
  toggleEdit(isOn: boolean) {
    this.onEdit = isOn;
    if (!isOn) {
      this.category.newName = this.category.oldName;
      this.validCategory = false;
    }
  }
  toggleDelete(isOn: boolean) {
    this.onDelete = isOn;
  }
  updateCategory(event: Event) {
    event.preventDefault();
    this.categoryService.updateCategory(this.category).subscribe({
      next: (response) => {
        this.toastrService.success("Category updated successfully", '', Constants.toastrConfig);
        this.category.concurrencyStamp = response.data;
        this.category.oldName = this.category.newName;
        this.toggleEdit(false);
      },
      error: (response) => {

        if (response.status == 409) this.toastrService.error("This category was updated by someone else. Please refresh and try again.", '', Constants.toastrConfig);
        else this.toastrService.error(response.error.errors[0].message, '', Constants.toastrConfig);
      }
    })
  }
  deleteCategory(event: Event) {
    event.preventDefault();
    let categoryDelete: CategoryDelete = {
      id: this.category.id,
      concurrencyStamp: this.category.concurrencyStamp
    }
    this.categoryService.deleteCategory(categoryDelete).subscribe(
      {
        next: (response) => {
          this.toastrService.success(response.data, '', Constants.toastrConfig);
          this.router.navigateByUrl("admin/categories");
        },
        error: (response) => {
          if (response.status == 409) this.toastrService.error("This category was updated by someone else. Please refresh and try again.", '', Constants.toastrConfig);
          else this.toastrService.error(response.error.errors[0].message, '', Constants.toastrConfig);
          this.toggleDelete(false)
        }
      }
    )
  }
  ngOnDestroy() {
    this.screenService.showSidebar.set(false)
    this.getByIdSubscription?.unsubscribe();
  }
}
