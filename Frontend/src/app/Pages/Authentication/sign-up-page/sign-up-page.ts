import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputDirective } from '../../../Directives/input-directive';
import { LabelDirective } from '../../../Directives/label-directive';
import { SpinnerDirective } from '../../../Directives/spinner-directive';
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
import { ApiError } from '../../../Interfaces/api-error';
import { ButtonComponent } from "../../../Components/button-component/button-component";

@Component({
  selector: 'app-sign-up-page',
  imports: [LogoComponent, ReactiveFormsModule, InputDirective, LabelDirective, SpinnerDirective, PhoneErrorDirective, UserNameErrorDirective, PasswordErrorDirective, EmailErrorDirective, RouterLink, ConfirmPasswordErrorDirective, ButtonComponent],
  templateUrl: './sign-up-page.html',
  styleUrl: './sign-up-page.css'
})
export class SignUpPage {
  constructor(private screenServices: ScreenService, private userService: UserService, private router: Router) { }
  //#region Properties
  SignUpForm: FormGroup = new FormGroup({
    userName: new FormControl<string>("", AppValidators.name),
    email: new FormControl<string>("", AppValidators.email),
    phoneNumber: new FormControl<string>("", AppValidators.phone),
    password: new FormControl<string>("", AppValidators.password),
    confirmPassword: new FormControl<string>("", { validators: [Validators.required] }),
    role: new FormControl<TRole>("Customer"),
  });
  isLoading: boolean = false;
  roles = Constants.Roles.List;
  showPassword: boolean = false;
  showConfirmPassword: boolean = false
  //#endregion
  //#region Sign Up Method
  signUp(event: Event) {
    event.preventDefault()
    if (this.SignUpForm.valid) {
      this.isLoading = true
      this.userService.signUp({
        userName: this.SignUpForm.value.userName,
        email: this.SignUpForm.value.email,
        phoneNumber: this.SignUpForm.value.phoneNumber,
        role: this.SignUpForm.value.role,
        password: this.SignUpForm.value.password,
        confirmPassword: this.SignUpForm.value.confirmPassword
      }).subscribe(
        {
          next: response => {
            this.isLoading = false;
            this.router.navigateByUrl("/")
          },
          error: response => {
            this.isLoading = false
            let errors: ApiError[] = response.error.errors;
            for (let i = 0; i < errors.length; i++) {
              let control = this.SignUpForm.get(errors[i].propertyName)
              control?.setErrors({ apiError: errors[i].message })
            }
          }
        }
      )

    }
  }
  //#endregion
  //#region Component Lifecycle
  ngOnInit() {
    this.screenServices.hideNavbar$.next(true)
  }
  ngOnDestroy() {
    this.screenServices.hideNavbar$.next(false)
  }
  //#endregion
}
