import { Component } from '@angular/core';
import { LogoComponent } from "../logo-component/logo-component";
import { RouterLink, RouterLinkActive } from '@angular/router';
import { TTheme } from '../../Types/TTheme';
import { ScreenService } from '../../Services/screen-service';
import { Constants } from '../../Constants';
import { UserService } from '../../Services/user-service';
import { LinkApp } from '../../Interfaces/link-app';

@Component({
  selector: 'app-nav-bar-component',
  imports: [LogoComponent, RouterLink, RouterLinkActive],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css'
})
export class NavBarComponent {
  public Constants = Constants;
  public links: LinkApp[] = [
    { href: "", text: "Home" },
    { href: "test", text: "Study" },
    { href: "admin/categories", text: "Categories" },
    { href: "admin/subcategories", text: "Subcategories" },
    { href: "admin/history", text: "History" }
  ]
  constructor(public screenService: ScreenService, public userService: UserService) { }
  ngOnInit() {
    const storedTheme = localStorage.getItem(Constants.localStorageKey.theme) as TTheme;
    if (storedTheme)
      this.screenService.selectThemeSignal.set(storedTheme);
  }
  toggleTheme() {
    let theme = this.screenService.selectThemeSignal();
    theme = theme === Constants.Theme.light ? Constants.Theme.dark : Constants.Theme.light;
    localStorage.setItem(Constants.localStorageKey.theme, theme);
    this.screenService.selectThemeSignal.set(theme)
  }
  logOut() {
    localStorage.removeItem(Constants.localStorageKey.token)
    sessionStorage.removeItem(Constants.localStorageKey.token)
    this.userService.userSignal.set({
      isAuthenticated: false,
      userName: "",
      role: Constants.Roles.Customer,
      token: ""
    })
  }
}
