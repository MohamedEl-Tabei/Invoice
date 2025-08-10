import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./Components/nav-bar-component/nav-bar-component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,  NavBarComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Frontend';
}
