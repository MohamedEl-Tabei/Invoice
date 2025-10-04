import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./Components/nav-bar-component/nav-bar-component";
import { ScreenService } from './Services/screen-service';
import { TTheme } from './Types/TTheme';
import { UserService } from './Services/user-service';
import { Constants } from './Constants';
import { jwtDecode } from 'jwt-decode'
import { UserAuthenticated } from './Interfaces/user-authenticated';
import { TokenPayload } from './Interfaces/token-payload';
import { SubCategoriesSideBarComponent } from "./Components/sub-categories-side-bar-component/sub-categories-side-bar-component";
import { BehaviorSubject } from 'rxjs';
import { AsyncPipe } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent, SubCategoriesSideBarComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  public theme: TTheme = "light";
  constructor(public screenService: ScreenService, private userService: UserService) { }
  ngOnInit() {
    this.screenService.selectTheme$.subscribe(theme => this.theme = theme)
    //#region  Auto login
    const tokenFromLocal = localStorage.getItem(Constants.localStorageKey.token)
    const tokenFromSession = sessionStorage.getItem(Constants.localStorageKey.token)
    const token = tokenFromLocal ? tokenFromLocal : tokenFromSession;

    if (token) {
      let data = jwtDecode<TokenPayload>(token)
      let userAuthenticated: UserAuthenticated | false = false;
      let isValidToken = data && data.exp && Date.now() <= data.exp * 1000;
      if (isValidToken) userAuthenticated = {
        role: data.role,
        token: token,
        userName: data.unique_name
      }
      this.userService.athenticatedUser$.next(userAuthenticated)
    }

    //#endregion
  }
}
