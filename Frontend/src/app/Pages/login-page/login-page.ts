import { Component } from '@angular/core';
import { UserService } from '../../Services/user-service';
import { Constants } from '../../Constants';
import { LogoComponent } from "../../Components/logo-component/logo-component";
import { InputDirective } from '../../Directives/input-directive';
import { LabelDirective } from '../../Directives/label-directive';
import { RouterLink } from '@angular/router';
import { UserUniqueInputData } from '../../Interfaces/user-unique-input-data';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AppValidators } from '../../Validators';
import { SpinnerDirective } from '../../Directives/spinner-directive';
import { ApiResponse } from '../../Interfaces/api-response';
import { UserAuthenticated } from '../../Interfaces/user-authenticated';
import { ScreenService } from '../../Services/screen-service';

@Component({
  selector: 'app-login-page',
  imports: [LogoComponent, InputDirective, LabelDirective, RouterLink, ReactiveFormsModule, SpinnerDirective],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  constructor(private userService: UserService,private screenService:ScreenService) { }

  //#region Properties
  isLoading: boolean = false;
  showPassword:boolean=false
  dataError: string = '';
  userUniqueInputData: UserUniqueInputData[] = Constants.UserUniqueInputData;
  selectedUserUniqueInputData: UserUniqueInputData = { label: this.userUniqueInputData[0].label, inputType: this.userUniqueInputData[0].inputType, placeholder: this.userUniqueInputData[0].placeholder, id: this.userUniqueInputData[0].id };
  loginForm: FormGroup = new FormGroup({
    uniqueInput: new FormControl<string>('', { validators: this.userUniqueInputData[0].validators }),
    password: new FormControl<string>('', { validators: AppValidators.password }),
    rememberMe: new FormControl<boolean>(false)
  });
  //#endregion
  //#region Set Methods
  setSelectedUserUniqueInputData(data: UserUniqueInputData) {
    this.loginForm.removeControl('uniqueInput');
    this.loginForm.addControl('uniqueInput', new FormControl<string>('', { validators: data.validators }));
    this.selectedUserUniqueInputData = data;
  }
  //#endregion
  //#region  error & nex Methods
  handleLoginError(response: any) {
    this.dataError = response.error.errors[0].message;
    this.isLoading = false;
  }
  handleLoginSuccess(response: ApiResponse<UserAuthenticated>) {
    this.isLoading = false;
    console.log(response);
  }
  //#endregion
  //#region Login Method
  login($event: Event) {
    $event.preventDefault();
    if (this.loginForm.valid) {
      this.isLoading = true;

      //#region Login by Email
      if (this.selectedUserUniqueInputData.id === 'email') {
        this.userService.loginByEmail({
          email: this.loginForm.value.uniqueInput,
          password: this.loginForm.value.password,
          rememberMe: this.loginForm.value.rememberMe
        }).subscribe({
          next: (response) => this.handleLoginSuccess(response),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
      //#region Login by Phone
      else if (this.selectedUserUniqueInputData.id === 'phone') {
        this.userService.loginByPhone({
          phone: this.loginForm.value.uniqueInput,
          password: this.loginForm.value.password,
          rememberMe: this.loginForm.value.rememberMe
        }).subscribe({
          next: (response) => this.handleLoginSuccess(response),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
      //#region Login by Name
      else if (this.selectedUserUniqueInputData.id === 'name') {
        this.userService.loginByUsername({
          name: this.loginForm.value.uniqueInput,
          password: this.loginForm.value.password,
          rememberMe: this.loginForm.value.rememberMe
        }).subscribe({
          next: (response) => this.handleLoginSuccess(response),
          error: (response) => this.handleLoginError(response)
        });
      }
      //#endregion
    }
    else if (this.loginForm.get('uniqueInput')?.hasError('required') || this.loginForm.get('password')?.hasError('required'))
      this.dataError = `Please enter ${this.selectedUserUniqueInputData.label} and Password`;
    else this.dataError = `Invalid ${this.selectedUserUniqueInputData.label} or Password`;
  }
  //#endregion
  //#region Component Lifecycle
  ngOnInit() {
    this.screenService.hideNavbar$.next(true);
  }
  ngOnDestroy() {
    this.screenService.hideNavbar$.next(false);
  }
  ngAfterViewChecked() {
    this.dataError="";
  }
  //#endregion
}
