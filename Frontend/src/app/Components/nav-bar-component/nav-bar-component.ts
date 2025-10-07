import { Component } from '@angular/core';
import { LogoComponent } from "../logo-component/logo-component";
import { RouterLink, RouterLinkActive } from '@angular/router';
import { TTheme } from '../../Types/TTheme';
import { ScreenService } from '../../Services/screen-service';
import { Constants } from '../../Constants';
import { UserService } from '../../Services/user-service';
import { UserAuthenticated } from '../../Interfaces/user-authenticated';
import { LinkApp } from '../../Interfaces/link-app';

@Component({
  selector: 'app-nav-bar-component',
  imports: [LogoComponent, RouterLink, RouterLinkActive],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css'
})
export class NavBarComponent {
  public theme: TTheme = Constants.Theme.light;
  public Constants = Constants;
  public isHidden = false;
  public links:LinkApp[] = [{ href: "", text: "Home" }, { href: "admin/categories", text: "Categories" }, { href: "admin/history", text: "History" }]
  public authenticatedUser: false | UserAuthenticated = false;
  constructor(private screenService: ScreenService, private userService: UserService) { }
  ngOnInit() {
    const storedTheme = localStorage.getItem(Constants.localStorageKey.theme) as TTheme;
    if (storedTheme) this.theme = storedTheme;
    this.screenService.selectTheme$.next(this.theme);
    this.screenService.hideNavbar$.subscribe((isHidden: boolean) => this.isHidden = isHidden);
    this.userService.athenticatedUser$.subscribe((data) => this.authenticatedUser = data)
  }
  toggleTheme() {
    this.theme = this.theme === Constants.Theme.light ? Constants.Theme.dark : Constants.Theme.light;
    localStorage.setItem(Constants.localStorageKey.theme, this.theme);
    this.screenService.selectTheme$.next(this.theme)
  }
  logOut() {
    localStorage.removeItem(Constants.localStorageKey.token)
    sessionStorage.removeItem(Constants.localStorageKey.token)
    this.userService.athenticatedUser$.next(false)
  }
}
