import { Component } from '@angular/core';
import { UserService } from '../../../Services/user-service';
import { Constants } from '../../../Constants';
import { LogoComponent } from "../../../Components/logo-component/logo-component";
import { InputDirective } from '../../../Directives/input-directive';
import { LabelDirective } from '../../../Directives/label-directive';
import { Router, RouterLink } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AppValidators } from '../../../Validators';
import { ScreenService } from '../../../Services/screen-service';
import { ButtonComponent } from "../../../Components/button-component/button-component";
import { UserLoginIdentifier } from '../../../Interfaces/DTOs/user-login-identifier';
import { LoginForm } from '../../../Interfaces/Forms/login-form';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login-page',
  imports: [LogoComponent, InputDirective, LabelDirective, RouterLink, ReactiveFormsModule, ButtonComponent],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  constructor(private userService: UserService, private screenService: ScreenService, private router: Router) { }
  //#region subscriptions
  loinByEmailSubscription: Subscription | null = null;
  loinByPhoneSubscription: Subscription | null = null;
  loinByUsernameSubscription: Subscription | null = null;
  //#endregion
  showPassword: boolean = false
  dataError: string = '';
  userLoginIdentifiers: UserLoginIdentifier[] = Constants.userLoginIdentifiers;
  selecteduserLoginIdentifier: UserLoginIdentifier = { label: this.userLoginIdentifiers[0].label, identifier: this.userLoginIdentifiers[0].identifier, placeholder: this.userLoginIdentifiers[0].placeholder, id: this.userLoginIdentifiers[0].id };
  //#region login form controls  
  loginForm = new FormGroup<LoginForm>({
    identifier: new FormControl<string>('', { validators: this.userLoginIdentifiers[0].validators, nonNullable: true }),
    password: new FormControl<string>('', { validators: AppValidators.password, nonNullable: true }),
    rememberMe: new FormControl<boolean>(false, { nonNullable: true }),
  });
  //#endregion
  //#region Set Selected Login Type Method
  setSelectedLoginType(data: UserLoginIdentifier) {
    this.loginForm.get('identifier')?.setValue('');
    if (data.validators) this.loginForm.get("identifier")?.setValidators(data.validators);
    this.selecteduserLoginIdentifier = data;
    this.clearDataError();
  }
  //#endregion
  //#region  error & success Login Methods
  handleLoginError(response: any) {
    this.dataError = response.error.errors[0].message;
  }
  handleLoginSuccess() {
    this.router.navigateByUrl("/")
  }
  //#endregion
  //#region Login Method
  login($event: Event) {
    $event.preventDefault();
    if (this.loginForm.valid) {
      const data = this.loginForm.getRawValue();
      //#region Login by Email
      if (this.selecteduserLoginIdentifier.id === 'email') {
        this.loinByEmailSubscription = this.userService.loginByEmail({ ...data, email: data.identifier }).subscribe({
          next: (response) => this.handleLoginSuccess(),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
      //#region Login by Phone
      else if (this.selecteduserLoginIdentifier.id === 'phone') {
        this.loinByPhoneSubscription = this.userService.loginByPhone({ ...data, phoneNumber: data.identifier }).subscribe({
          next: (response) => this.handleLoginSuccess(),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
      //#region Login by Name
      else if (this.selecteduserLoginIdentifier.id === 'name') {
        this.loinByUsernameSubscription = this.userService.loginByUsername({ ...data, userName: data.identifier }).subscribe({
          next: (response) => this.handleLoginSuccess(),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
    }
    else if (this.loginForm.get('uniqueInput')?.hasError('required') || this.loginForm.get('password')?.hasError('required'))
      this.dataError = `Please enter ${this.selecteduserLoginIdentifier.label} and Password`;
    else this.dataError = `Invalid ${this.selecteduserLoginIdentifier.label} or Password`;
  }
  //#endregion
  //#region Component Lifecycle
  ngOnInit() {
    this.screenService.hideNavbarSignal.set(true);
  }
  ngOnDestroy() {
    this.screenService.hideNavbarSignal.set(false);
    this.loinByEmailSubscription?.unsubscribe();
    this.loinByPhoneSubscription?.unsubscribe();
    this.loinByUsernameSubscription?.unsubscribe();
  }

  //#endregion
  clearDataError() {
    if (this.dataError) this.dataError = ''
  }
}
