import { Component } from '@angular/core';
import { Logo } from "../../Components/logo/logo";
import { RouterLink } from '@angular/router';
import { LoginBy } from '../../Interfaces/login-by';
import { CommonModule } from '@angular/common';
import { Constants } from '../../Constants';
import { User } from '../../Services/user';
import { UserLoginByEmail } from '../../Interfaces/user-login-by-email';

@Component({
  selector: 'app-login',
  imports: [Logo, RouterLink, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  constructor(private userServices: User) { }
  password: string = '';
  rememberMe: boolean = false;
  loginTypes: LoginBy[] = Constants.loginTypes;
  selectedLoginType: LoginBy = { by: this.loginTypes[0].by, inputType: this.loginTypes[0].inputType, placeholder: this.loginTypes[0].placeholder, id: this.loginTypes[0].id,value: '' };
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
      error: (error) => {
        console.error('Login failed', error);
      }
    });
  }
}
