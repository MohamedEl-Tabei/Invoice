import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputDirective } from '../../../Directives/input-directive';
import { LabelDirective } from '../../../Directives/label-directive';
import { LogoComponent } from '../../../Components/logo-component/logo-component';
import { Router, RouterLink } from '@angular/router';
import { TRole } from '../../../Types/TRole';
import { PasswordErrorDirective } from '../../../Directives/password-error-directive';
import { AppValidators } from '../../../Validators';
import { ScreenService } from '../../../Services/screen-service';
import { Constants } from '../../../Constants';
import { UserService } from '../../../Services/user-service';
import { EmailErrorDirective } from '../../../Directives/email-error-directive';
import { UserNameErrorDirective } from '../../../Directives/user-name-error-directive';
import { PhoneErrorDirective } from '../../../Directives/phone-error-directive';
import { ConfirmPasswordErrorDirective } from "../../../Directives/confirm-password-error-directive";
import { ApiError } from '../../../Interfaces/DTOs/api-error';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { SignUpForm } from '../../../Interfaces/Forms/sign-up-form';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-sign-up-page',
  imports: [LogoComponent, ReactiveFormsModule, InputDirective, LabelDirective, PhoneErrorDirective, UserNameErrorDirective, PasswordErrorDirective, EmailErrorDirective, RouterLink, ConfirmPasswordErrorDirective, ButtonComponent],
  templateUrl: './sign-up-page.html',
  styleUrl: './sign-up-page.css'
})
export class SignUpPage {
  constructor(private screenServices: ScreenService, private userService: UserService, private router: Router) { }
  //#region Form Controls
  signUpForm = new FormGroup<SignUpForm>({
    userName: new FormControl<string>("", { validators: AppValidators.name, nonNullable: true }),
    email: new FormControl<string>("", { validators: AppValidators.email, nonNullable: true }),
    phoneNumber: new FormControl<string>("", { validators: AppValidators.phone, nonNullable: true }),
    password: new FormControl<string>("", { validators: AppValidators.password, nonNullable: true }),
    confirmPassword: new FormControl<string>("", { validators: [Validators.required], nonNullable: true }),
  });

  //#endregion
  roles = Constants.Roles.List;
  showPassword: boolean = false;
  signUpSubscribtion: Subscription | null = null;
  routes = Constants.Routes;
  //#region Sign Up Method
  signUp(event: Event) {
    event.preventDefault()
    if (this.signUpForm.valid) {
      const data = this.signUpForm.getRawValue()
      this.signUpSubscribtion = this.userService.signUp({ ...data }).subscribe(
        {
          next: response => {
            this.router.navigateByUrl("/")
          },
          error: response => {
            let errors: ApiError[] = response.error.errors;
            for (let i = 0; i < errors.length; i++) {
              let control = this.signUpForm.get(errors[i].propertyName)
              control?.setErrors({ apiError: errors[i].message })
            }
          }
        }
      )

    }
  }
  //#endregion
  //#region Component Lifecycle

  ngOnDestroy() {
    this.signUpSubscribtion?.unsubscribe();
  }
  //#endregion
}
