import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./Components/nav-bar-component/nav-bar-component";
import { ScreenService } from './Services/screen-service';
import { TTheme } from './Types/TTheme';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  public theme: TTheme = "light";

  constructor(private screenService: ScreenService) { }
  ngOnInit() {
    this.screenService.selectTheme$.subscribe(theme => this.theme = theme)
  }
}
