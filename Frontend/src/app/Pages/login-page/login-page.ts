import { Component } from '@angular/core';
import { UserService } from '../../Services/user-service';
import { LoginBy } from '../../Interfaces/login-by';
import { UserLoginByEmail } from '../../Interfaces/user-login-by-email';
import { Constants } from '../../Constants';
import { LogoComponent } from "../../Components/logo-component/logo-component";
import { InputDirective } from '../../Directives/input-directive';
import { LabelDirective } from '../../Directives/label-directive';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login-page',
  imports: [LogoComponent,InputDirective,LabelDirective,RouterLink],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css'
})
export class LoginPage {
  constructor(private userServices: UserService) { }
  password: string = '';
  dataError: string = 'er';
  rememberMe: boolean = false;
  loginTypes: LoginBy[] = Constants.loginTypes;
  selectedLoginType: LoginBy = { by: this.loginTypes[0].by, inputType: this.loginTypes[0].inputType, placeholder: this.loginTypes[0].placeholder, id: this.loginTypes[0].id, value: '' };
  setSelectedLoginType(loginType: LoginBy) {
    this.selectedLoginType = loginType;
  }
  loginByEmail($event: Event) {
    const data: UserLoginByEmail = {
      email: this.selectedLoginType.value,
      password: this.password,
      rememberMe: this.rememberMe
    };
    $event.preventDefault();
    this.userServices.loginByEmail(data).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (response) => {
        this.dataError = response.error.errors[0].message;
      }
    });
  }
}
