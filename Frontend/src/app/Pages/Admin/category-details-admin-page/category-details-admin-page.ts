import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputDirective } from '../../../Directives/input-directive';
import { CategoryService } from '../../../Services/category-service';
import { ToastrService } from 'ngx-toastr';
import { Constants } from '../../../Constants';
import { LoaderService } from '../../../Services/loader-service';
import { ScreenService } from '../../../Services/screen-service';
import { Subscription, switchMap } from 'rxjs';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { Category } from '../../../Interfaces/Models/category';
import { CategoryForm } from '../../../Interfaces/Forms/category-form';
import { AppValidators } from '../../../Validators';

@Component({
  selector: 'app-category-details-admin-page',
  imports: [FormsModule, InputDirective, ButtonComponent, ReactiveFormsModule],
  templateUrl: './category-details-admin-page.html',
  styleUrl: './category-details-admin-page.css'
})
export class CategoryDetailsAdminPage {
  category: Category = { id: '', name: '', concurrencyStamp: '' };
  showEdit = false;
  showDelete = false;
  getByIdSubscription!: Subscription;
  updateSubscription!: Subscription;
  deleteSubscription!: Subscription;
  updateForm = new FormGroup<CategoryForm>({
    name: new FormControl<string>('', { nonNullable: true, validators: AppValidators.categoryName })
  });
  constructor(private activeRoute: ActivatedRoute, public loaderService: LoaderService, private categoryService: CategoryService, private router: Router, private toastrService: ToastrService, public screenService: ScreenService) { }
  //#region lifecycle
  ngOnInit() {
    this.getByIdSubscription = this.activeRoute.queryParams.pipe(switchMap(p => {
      this.category.id = p['id'];
      return this.categoryService.getById(p['id'])
    }
    )).subscribe({
      next: (response) => {
        this.category.concurrencyStamp = response.data.concurrencyStamp;
        this.category.name = response.data.name;
        this.category.id = response.data.id;
      },
      error: (err) => {
        this.router.navigate(['/NotFound']);
      }
    });
  }
  ngOnDestroy() {
    this.getByIdSubscription?.unsubscribe();
    this.updateSubscription?.unsubscribe();
    this.deleteSubscription?.unsubscribe();
  }
  //#endregion
  //#region show toggles
  toggleShowEdit(isOn: boolean) {
    this.showEdit = isOn;
    this.updateForm.controls.name.setValue(this.category.name);

  }
  toggleShowDelete(isOn: boolean) {
    this.showDelete = isOn;
  }
  //#endregion
  //#region update
  updateCategory(event: Event) {
    event.preventDefault();
    if (this.updateForm.valid&&this.updateForm.controls.name.value!==this.category.name) {
      const newName = this.updateForm.controls.name.value;
      this.updateSubscription = this.categoryService.updateCategory({ newName, ...this.category }).subscribe({
        next: (response) => {
          this.toastrService.success("Category updated successfully", '', Constants.toastrConfig);
          this.category.concurrencyStamp = response.data;
          this.category.name = newName;
          this.toggleShowEdit(false);
        },
        error: (response) => {
          if (response.status == 409) this.toastrService.error("This category was updated by someone else. Please refresh and try again.", '', Constants.toastrConfig);
        }
      })
    }
    else if(this.updateForm.controls.name.value!==this.category.name){
      this.toastrService.error("Category name can only contain letters and spaces", '', { ...Constants.toastrConfig, closeButton: true, disableTimeOut: true });
    }
  }
  //#endregion
  //#region delete
  deleteCategory(event: Event) {
    event.preventDefault();
    this.deleteSubscription= this.categoryService.deleteCategory({ ...this.category }).subscribe(
      {
        next: (response) => {
          this.toastrService.success(response.data, '', Constants.toastrConfig);
          this.back();
        },
        error: (response) => {
          if (response.status == 409) this.toastrService.error("This category was updated by someone else. Please refresh and try again.", '', { ...Constants.toastrConfig, closeButton: true, disableTimeOut: true });
          this.toggleShowDelete(false)
        }
      }
    )
  }
  //#endregion
  //#region navigation
  back() {
    this.router.navigateByUrl("admin/categories");
  }
  //#endregion

}