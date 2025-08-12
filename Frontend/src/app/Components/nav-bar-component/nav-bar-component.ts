import { Component } from '@angular/core';
import { LogoComponent } from "../logo-component/logo-component";
import { RouterLink } from '@angular/router';
import { TTheme } from '../../Types/TTheme';
import { ScreenService } from '../../Services/screen-service';
import { Constants } from '../../Constants';

@Component({
  selector: 'app-nav-bar-component',
  imports: [LogoComponent, RouterLink],
  templateUrl: './nav-bar-component.html',
  styleUrl: './nav-bar-component.css'
})
export class NavBarComponent {
  public theme: TTheme = Constants.Theme.light;
  public Constants = Constants;
  public isHidden = false;
  constructor(private screenService: ScreenService) { }
  ngOnInit() {
    const storedTheme = localStorage.getItem('theme') as TTheme;
    if (storedTheme) this.theme = storedTheme;
    this.screenService.selectTheme$.next(this.theme);
    this.screenService.hideNavbar$.subscribe((isHidden: boolean) => this.isHidden = isHidden);
  }
  toggleTheme() {
    this.theme = this.theme === Constants.Theme.light ? Constants.Theme.dark : Constants.Theme.light;
    localStorage.setItem('theme', this.theme);
    this.screenService.selectTheme$.next(this.theme)
  }
}
