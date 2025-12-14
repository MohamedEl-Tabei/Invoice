import { Component, input } from '@angular/core';
import { LogoComponent } from "../logo-component/logo-component";
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { TTheme } from '../../Types/TTheme';
import { ScreenService } from '../../Services/screen-service';
import { Constants } from '../../Constants';
import { UserService } from '../../Services/user-service';
import { LinkApp } from '../../Interfaces/link-app';
import { TRole } from '../../Types/TRole';

@Component({
  selector: 'app-nav-bar-component',
  imports: [LogoComponent, RouterLink, RouterLinkActive],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css'
})
export class NavBarComponent {
  role = input<TRole>(Constants.Roles.Guest);
  public Constants = Constants;
  public links!: LinkApp[];
  constructor(public screenService: ScreenService, public userService: UserService, private router: Router) { }
  ngOnInit() {
    switch (this.role()) {
      case Constants.Roles.Admin:
        this.links = [
          { href: Constants.Routes.admin.category, text: "Category" },
          { href: Constants.Routes.admin.subcategory, text: "Subcategory" },
          { href: Constants.Routes.admin.history, text: "History" }
        ]
        break;
      default:
    }
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
    this.router.navigateByUrl("/")
    localStorage.removeItem(Constants.localStorageKey.token)
    sessionStorage.removeItem(Constants.localStorageKey.token)
    this.userService.userSignal.set({
      isAuthenticated: false,
      userName: "",
      roles: [Constants.Roles.Guest],
      token: ""
    })
  }
}
