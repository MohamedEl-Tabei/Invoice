import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ScreenService } from './Services/screen-service';
import { UserService } from './Services/user-service';
import { Constants } from './Constants';
import { jwtDecode } from 'jwt-decode'
import { TokenPayload } from './Interfaces/token-payload';
import { LoaderComponent } from "./Components/loader-component/loader-component";
import { LoaderService } from './Services/loader-service';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LoaderComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  constructor(public screenService: ScreenService, private userService: UserService, public loaderService: LoaderService) { }
  ngOnInit() {
    //#region Check for existing token in local or session storage
    const tokenFromLocal = localStorage.getItem(Constants.localStorageKey.token)
    const tokenFromSession = sessionStorage.getItem(Constants.localStorageKey.token)
    const token = tokenFromLocal ? tokenFromLocal : tokenFromSession;

    if (token) {
      let data = jwtDecode<TokenPayload>(token)
      let isValidToken = data && data.exp && Date.now() <= data.exp * 1000;
      if (isValidToken)
        this.userService.userSignal.set({
          isAuthenticated: true,
          roles: data.roles || [data.role],
          token: token,
          userName: data.unique_name
        });

    }

    //#endregion
  }
}
