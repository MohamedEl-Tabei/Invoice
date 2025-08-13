import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { InputDirective } from '../../Directives/input-directive';
import { LabelDirective } from '../../Directives/label-directive';
import { SpinnerDirective } from '../../Directives/spinner-directive';
import { LogoComponent } from '../../Components/logo-component/logo-component';
import { RouterLink } from '@angular/router';
import { TRole } from '../../Types/TRole';
import { PasswordErrorDirective } from '../../Directives/password-error-directive';
import { AppValidators } from '../../Validators';
import { ScreenService } from '../../Services/screen-service';
import { Constants } from '../../Constants';

@Component({
  selector: 'app-sign-up-page',
  imports: [LogoComponent, ReactiveFormsModule, InputDirective, LabelDirective, SpinnerDirective, PasswordErrorDirective, RouterLink],
  templateUrl: './sign-up-page.html',
  styleUrl: './sign-up-page.css'
})
export class SignUpPage {
  constructor(private screenServices: ScreenService) { }
  //#region Properties
  SignUpForm: FormGroup = new FormGroup({
    userName: new FormControl<string>(""),
    email: new FormControl<string>(""),
    phoneNumber: new FormControl<string>(""),
    password: new FormControl<string>("", AppValidators.password),
    confirmPassword: new FormControl<string>(""),
    role: new FormControl<TRole>("Customer"),
  });
  isLoading: boolean = false;
  roles=Constants.Roles.List
  //#endregion
  //#region Sign Up Method
  signUp(event: Event) {
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
